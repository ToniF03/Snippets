using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Provides AES encryption and decryption functionality for text data.
/// Uses a symmetric encryption algorithm with a fixed key and initialization vector.
/// WARNING: The hardcoded key and IV should be replaced with secure key management in production.
/// </summary>
public static class FileEncryption
{
    // AES encryption key - MUST be exactly 32 characters (256 bits)
    private static readonly string key = "Your32CharKeyHere1234567890abcd";
    
    // Initialization Vector - MUST be exactly 16 characters (128 bits)
    private static readonly string iv = "Your16CharIVHere";

    /// <summary>
    /// Encrypts plain text using AES encryption algorithm.
    /// </summary>
    /// <param name="plainText">The text to encrypt.</param>
    /// <returns>Encrypted data as a byte array.</returns>
    public static byte[] Encrypt(string plainText)
    {
        // Create AES encryption instance
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);  // Convert key string to bytes
        aes.IV = Encoding.UTF8.GetBytes(iv);    // Convert IV string to bytes

        // Create encryptor and encrypt the data
        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(plainText);  // Write plain text to crypto stream
        }
        return ms.ToArray();  // Return encrypted bytes
    }

    /// <summary>
    /// Decrypts encrypted data back to plain text using AES decryption.
    /// </summary>
    /// <param name="cipherData">The encrypted byte array to decrypt.</param>
    /// <returns>The decrypted plain text string.</returns>
    public static string Decrypt(byte[] cipherData)
    {
        // Create AES decryption instance
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);  // Convert key string to bytes
        aes.IV = Encoding.UTF8.GetBytes(iv);    // Convert IV string to bytes

        // Create decryptor and decrypt the data
        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream(cipherData);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return sr.ReadToEnd();  // Return decrypted text
    }
}
