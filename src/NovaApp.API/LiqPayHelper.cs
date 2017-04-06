using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace NovaApp.API
{
    public static class LiqPayHelper
    {
        public static string GetSignature(string liqPayBase64String, string secretKey)
        {
            var liqPayPrivateKey = secretKey;
            var sigRawString = $"{liqPayPrivateKey}{liqPayBase64String}{liqPayPrivateKey}";

            var buffer = Encoding.UTF8.GetBytes(sigRawString);
            var sha1 = SHA1.Create();
            var hash = sha1.ComputeHash(buffer);
            var signature = Convert.ToBase64String(hash);

            return signature;
        }

        public static string GetBase64String<TDataObject>(this TDataObject dataObject) where TDataObject : class
        {
            var dataString = JsonConvert.SerializeObject(dataObject);
            var plainTextBytes = Encoding.UTF8.GetBytes(dataString);
            var base64String = Convert.ToBase64String(plainTextBytes);
            return base64String;
        }

        public static TDataObject GetBase64String<TDataObject>(string base64Data) where TDataObject : class
        {
            var plaingTextBytes = Convert.FromBase64String(base64Data);
            var plainText = Encoding.UTF8.GetString(plaingTextBytes);
            var result = JsonConvert.DeserializeObject<TDataObject>(plainText);

            return result;
        }
    }
}