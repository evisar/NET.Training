using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Cryptography
{
    class CustomDigitalSignature
    {
        public static void Example()
        {

            byte[] senderBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            //known by both pairs
            var asymetricKey = new RSACryptoServiceProvider();

            var hashAlg = SHA1.Create();

            var signature = asymetricKey.SignData(senderBytes, hashAlg);

            //receiver


            var signatureOk = asymetricKey.VerifyData(senderBytes, hashAlg, signature);
        }
    }
}
