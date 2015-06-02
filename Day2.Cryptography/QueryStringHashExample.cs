using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Day2.Cryptography
{
    class QueryStringHashExample
    {
        static void Example()
        {
            //sender
            var queryString = "http://localhost/api?name=filan&surname=fisteku";
            var timeStamp = HttpUtility.UrlEncode(DateTime.UtcNow.ToString());
            var salt = "M@g1c";
            queryString += "&timestamp=" + timeStamp;

            var hashMaterial = queryString + salt;
            var alg = SHA256.Create();
            var hash = alg.ComputeHash(UTF8Encoding.UTF8.GetBytes(hashMaterial));
            var hashBase64 = Convert.ToBase64String(hash);

            queryString += "&hash=" + HttpUtility.UrlEncode(hashBase64);

            //receiver

            var uri = new Uri(queryString);
            var keyValues = HttpUtility.ParseQueryString(uri.Query);

            var rcvText = "http://localhost/api?";
            for (var i = 0; i < keyValues.AllKeys.Length - 1; i++)
            {
                rcvText += keyValues.Keys[i] + "=" + HttpUtility.UrlEncode(keyValues[i]);
                if (i < keyValues.AllKeys.Length - 2) rcvText += "&";
            }

            var rcvTextByte = UTF8Encoding.UTF8.GetBytes(rcvText + salt);
            var rcvHash = alg.ComputeHash(rcvTextByte);

            var senderHashBase64 = keyValues["hash"];
            var senderHash = Convert.FromBase64String(senderHashBase64);

        }
    }
}
