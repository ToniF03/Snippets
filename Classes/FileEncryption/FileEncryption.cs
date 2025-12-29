using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Secure file/string encryption helper.
/// - Uses AES-GCM (authenticated encryption) when available.
/// - Does NOT contain hard-coded keys. Keys should be loaded from a protected file
///   (DPAPI / ProtectedData on Windows) or from an environment variable as Base64.
/// Usage:
///  - Create key file: FileEncryption.CreateAndSaveProtectedKey(pathToProtectedKeyFile);
///  - Load key: var key = FileEncryption.LoadKeyFromProtectedFile(path);
///  - Encrypt: var b64 = FileEncryption.EncryptToBase64("secret", key);
///  - Decrypt: var plain = FileEncryption.DecryptFromBase64(b64, key);
///
/// Note: This code targets modern .NET that provides `AesGcm`. For older frameworks,
/// use a vetted library or upgrade. On Windows this uses DPAPI via ProtectedData to
/// protect the raw key blob.
/// </summary>
public static class FileEncryption
{
    private const int KeySize = 32; // 256 bits
    private const int NonceSize = 12; // 96 bits recommended for GCM
    private const int TagSize = 16; // 128-bit tag

    /// <summary>
    /// Generates a new random 256-bit key and saves it protected with DPAPI to `protectedKeyPath`.
    /// The resulting file will contain the DPAPI-protected key bytes. This file should be
    /// stored in a location with restricted permissions (e.g. user profile) and backed up securely.
    /// </summary>
    public static void CreateAndSaveProtectedKey(string protectedKeyPath)
    {
        if (string.IsNullOrWhiteSpace(protectedKeyPath)) throw new ArgumentNullException(nameof(protectedKeyPath));

        var key = new byte[KeySize];
        RandomNumberGenerator.Fill(key);

        // Protect key for current user (Windows DPAPI)
        var protectedKey = ProtectedData.Protect(key, null, DataProtectionScope.CurrentUser);

        Directory.CreateDirectory(Path.GetDirectoryName(protectedKeyPath) ?? ".");
        File.WriteAllBytes(protectedKeyPath, protectedKey);
    }

    /// <summary>
    /// Loads and unprotects a DPAPI-protected key file created by CreateAndSaveProtectedKey.
    /// Throws if the key length is unexpected.
    /// </summary>
    public static byte[] LoadKeyFromProtectedFile(string protectedKeyPath)
    {
        if (string.IsNullOrWhiteSpace(protectedKeyPath)) throw new ArgumentNullException(nameof(protectedKeyPath));
        if (!File.Exists(protectedKeyPath)) throw new FileNotFoundException("Protected key file not found.", protectedKeyPath);

        var protectedKey = File.ReadAllBytes(protectedKeyPath);
        var key = ProtectedData.Unprotect(protectedKey, null, DataProtectionScope.CurrentUser);
        if (key == null || key.Length != KeySize) throw new CryptographicException("Invalid key length or corrupted key file.");
        return key;
    }

    /// <summary>
    /// Attempts to load key from environment variable `envVarName` (Base64) first,
    /// then falls back to a DPAPI-protected file at `protectedKeyPath`. Throws if none found.
    /// </summary>
    public static byte[] LoadKeyFromEnvironmentOrFile(string envVarName, string protectedKeyPath)
    {
        if (!string.IsNullOrEmpty(envVarName))
        {
            var env = Environment.GetEnvironmentVariable(envVarName);
            if (!string.IsNullOrEmpty(env))
            {
                try
                {
                    var key = Convert.FromBase64String(env);
                    if (key.Length == KeySize) return key;
                }
                catch { /* ignore and fallback */ }
            }
        }

        if (!string.IsNullOrEmpty(protectedKeyPath) && File.Exists(protectedKeyPath))
        {
            return LoadKeyFromProtectedFile(protectedKeyPath);
        }

        throw new InvalidOperationException("No encryption key found. Create one using CreateAndSaveProtectedKey or set an environment variable.");
    }

    /// <summary>
    /// Encrypts the provided UTF-8 string and returns a Base64 string containing: nonce|tag|ciphertext
    /// (concatenated bytes). Always uses a fresh random nonce per encryption.
    /// </summary>
    public static string EncryptToBase64(string plainText, byte[] key)
    {
        if (plainText == null) throw new ArgumentNullException(nameof(plainText));
        var plaintextBytes = Encoding.UTF8.GetBytes(plainText);
        var combined = EncryptBytes(plaintextBytes, key);
        return Convert.ToBase64String(combined);
    }

    /// <summary>
    /// Encrypts raw bytes and returns combined output: nonce (12) + tag (16) + ciphertext.
    /// </summary>
    public static byte[] EncryptBytes(byte[] plaintext, byte[] key)
    {
        if (plaintext == null) throw new ArgumentNullException(nameof(plaintext));
        if (key == null || key.Length != KeySize) throw new ArgumentException("Key must be 32 bytes.", nameof(key));

        var nonce = new byte[NonceSize];
        RandomNumberGenerator.Fill(nonce);

        var ciphertext = new byte[plaintext.Length];
        var tag = new byte[TagSize];

        using (var aesGcm = new AesGcm(key))
        {
            aesGcm.Encrypt(nonce, plaintext, ciphertext, tag, null);
        }

        var combined = new byte[NonceSize + TagSize + ciphertext.Length];
        Buffer.BlockCopy(nonce, 0, combined, 0, NonceSize);
        Buffer.BlockCopy(tag, 0, combined, NonceSize, TagSize);
        Buffer.BlockCopy(ciphertext, 0, combined, NonceSize + TagSize, ciphertext.Length);
        return combined;
    }

    /// <summary>
    /// Decrypts a Base64 string created by EncryptToBase64 and returns the UTF-8 plain text.
    /// </summary>
    public static string DecryptFromBase64(string base64Data, byte[] key)
    {
        if (base64Data == null) throw new ArgumentNullException(nameof(base64Data));
        var combined = Convert.FromBase64String(base64Data);
        var plain = DecryptBytes(combined, key);
        return Encoding.UTF8.GetString(plain);
    }

    /// <summary>
    /// Decrypts combined bytes produced by EncryptBytes. Expects nonce + tag + ciphertext.
    /// </summary>
    public static byte[] DecryptBytes(byte[] combined, byte[] key)
    {
        if (combined == null) throw new ArgumentNullException(nameof(combined));
        if (key == null || key.Length != KeySize) throw new ArgumentException("Key must be 32 bytes.", nameof(key));
        if (combined.Length < NonceSize + TagSize) throw new CryptographicException("Invalid encrypted data.");

        var nonce = new byte[NonceSize];
        var tag = new byte[TagSize];
        var ciphertextLen = combined.Length - NonceSize - TagSize;
        var ciphertext = new byte[ciphertextLen];

        Buffer.BlockCopy(combined, 0, nonce, 0, NonceSize);
        Buffer.BlockCopy(combined, NonceSize, tag, 0, TagSize);
        Buffer.BlockCopy(combined, NonceSize + TagSize, ciphertext, 0, ciphertextLen);

        var plaintext = new byte[ciphertextLen];
        using (var aesGcm = new AesGcm(key))
        {
            aesGcm.Decrypt(nonce, ciphertext, tag, plaintext, null);
        }

        return plaintext;
    }
}
