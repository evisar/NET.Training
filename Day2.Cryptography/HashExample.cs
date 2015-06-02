using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Cryptography
{
    class HashExample
    {
        public static void Example()
        {
            //sender
            var text = "Welcome to the beautiful island of Jamaica.";
            var senderArr = UTF8Encoding.UTF8.GetBytes(text);

            var senderArrBase64Text = Convert.ToBase64String(senderArr);


            var alg = SHA256.Create();
            var senderHash = alg.ComputeHash(senderArr);

            //receiver

            var receiveArrBase64 = Convert.FromBase64String(senderArrBase64Text);
            var receiverHash = alg.ComputeHash(receiveArrBase64);


            var receiveText = UTF8Encoding.UTF8.GetString(receiveArrBase64);

            Console.WriteLine(receiveText);
        }
    }
}
