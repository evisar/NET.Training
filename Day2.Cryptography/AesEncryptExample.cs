using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Cryptography
{
    public class AesEncryptExample
    {
        static void Example()
        {
            //sender

            var senderBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            //known by both pairs
            var symmetricKey = Aes.Create();

            byte[] encryptedBytes = Encrypt(senderBytes, symmetricKey);

            //receiver

            Decrypt(symmetricKey, encryptedBytes);

        }

        public static byte[] Decrypt(Aes symmetricKey, byte[] encryptedBytes)
        {
            byte[] decryptedBytes = null;

            var decryptor = symmetricKey.CreateDecryptor(symmetricKey.Key, symmetricKey.IV);
            using (MemoryStream msEncrypt = new MemoryStream(encryptedBytes))
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader swDEscrypt = new StreamReader(csEncrypt))
                    {
                        //Write all data to the stream.
                        var decryptedBase64 = swDEscrypt.ReadToEnd();
                        decryptedBytes = Convert.FromBase64String(decryptedBase64);
                    }
                }
            }

            return decryptedBytes;
        }

        public static byte[] Encrypt(byte[] senderBytes, Aes symmetricKey)
        {
            var encryptor = symmetricKey.CreateEncryptor(symmetricKey.Key, symmetricKey.IV);

            byte[] encryptedBytes = null;

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        var senderBytesBase64 = Convert.ToBase64String(senderBytes);
                        swEncrypt.Write(senderBytesBase64);
                    }
                    encryptedBytes = msEncrypt.ToArray();
                }
            }
            return encryptedBytes;
        }
    }
}
