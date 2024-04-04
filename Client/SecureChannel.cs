using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Client
{
    public class SecureChannel
    {
        private AesManaged _aes;
        private byte[] _key = new byte[] { 0x73, 0x6f, 0x72, 0x72, 0x79, 0x69, 0x6b, 0x77, 0x65, 0x65, 0x74, 0x6e, 0x69, 0x65, 0x74, 0x77, 0x61, 0x74, 0x65, 0x72, 0x6d, 0x69, 0x73, 0x6d, 0x65, 0x74, 0x6d, 0x69, 0x6a, 0x77, 0x61, 0x73 };
        private byte[] _IV = new byte[] { 0x6a, 0x65, 0x6d, 0x6f, 0x65, 0x64, 0x65, 0x72, 0x69, 0x73, 0x65, 0x65, 0x6e, 0x6b, 0x75, 0x74 };

        public SecureChannel()
        {
            _aes = new AesManaged();
            _aes.Padding = PaddingMode.Zeros;
        }

        public byte[] Encrypt(string plainText)
        {
            byte[] encrypted;
                // Create encryptor
                ICryptoTransform encryptor = _aes.CreateEncryptor(_key, _IV);
                // Create MemoryStream
                using MemoryStream ms = new MemoryStream();
                // Create crypto stream using the CryptoStream class. This class is the key to encryption
                // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream
                // to encrypt
                using CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                // Create StreamWriter and write data to a stream
                using (StreamWriter sw = new StreamWriter(cs))
                    sw.Write(plainText);
                encrypted = ms.ToArray();
            // Return encrypted data
            return encrypted;
        }
        public string Decrypt(byte[] cipherText)
        {
            // Create a decryptor
            ICryptoTransform decryptor = _aes.CreateDecryptor(_key, _IV);
            // Create the streams used for decryption.
            using MemoryStream ms = new MemoryStream(cipherText);
            // Create crypto stream
            using CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            // Read crypto stream
            using StreamReader reader = new StreamReader(cs);
            string plaintext = reader.ReadToEnd();
            return plaintext;
        }
    }
}