FileEncryption

Description: Simple AES encrypt/decrypt helper.

File: `FileEncryption.cs`

Details:
- Provides static `Encrypt(string)` and `Decrypt(byte[])` methods using AES.
- Current implementation uses hardcoded `key` and `iv` strings — this is insecure and intended only for examples or throwaway data.

Usage example:
```csharp
byte[] cipher = FileEncryption.Encrypt("secret text");
string clear = FileEncryption.Decrypt(cipher);
```

Security notes:
- Replace hardcoded keys with a secure key-management strategy (DPAPI, certificate store, or a secure KMS).
- Do not use this implementation for production-sensitive data without proper key handling.
