using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Cryptography
{
    class RsaAsymetricExample
    {
        public static void Example()
        {
            //sender
            //sender

            byte[] senderBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            //known by both pairs
            var asymetricKey = new RSACryptoServiceProvider();

            var symmetricKey = Aes.Create();

            var encrypted = AesEncryptExample.Encrypt(senderBytes, symmetricKey);

            var encrypedKey = asymetricKey.Encrypt(symmetricKey.Key, true);

            //receiver

            var decryptedKey = asymetricKey.Decrypt(encrypedKey, true);
            //var decrypteKey = Aes.Create();
            //decrypteKey.Key = decryptedKey;
            var decrypted = AesEncryptExample.Decrypt(symmetricKey, encrypted);
            

        }
    }
}
