using System;
using System.IO;
using System.Security.Cryptography;

namespace Shaparak.PaymentFacilitation.Infrastructure {

    public static class PemUtil {
        
        private const string HEADER_PRIVATE_KEY = "-----BEGIN RSA PRIVATE KEY-----";
        private const string FOOTER_PRIVATE_KEY = "-----END RSA PRIVATE KEY-----";

        public static void SignFile(
            string sourceFilePath, 
            string privateKeyFilePath,
            string targetFilePath)
        {
            string fileContent = File.ReadAllText(sourceFilePath);
            string signedContent = Encrypt(fileContent, privateKeyFilePath);
            using (StreamWriter writer = File.CreateText(targetFilePath))
            {
                writer.Write(signedContent);
                writer.Flush();
                writer.Close();
            }
        }

        public static string SignFile(string sourceFilePath, string privateKeyFilePath)
        {
            string fileContent = File.ReadAllText(sourceFilePath);
            string signedContent = Encrypt(fileContent, privateKeyFilePath);
            return signedContent;
        }

        public static string Encrypt(string content, string privateKeyFilePath)
        {
            string pem = File.ReadAllText(privateKeyFilePath);
            byte[] buffer = getBytesFromPemFile(pem);
            var rsa = new RSACryptoServiceProvider();
            var rsaParam = rsa.ExportParameters(false);
            rsaParam.Modulus = buffer;
            rsa.ImportParameters(rsaParam);
            byte[] base64Bytes = Convert.FromBase64String(content);
            byte[] encryptedMessageByte = rsa.Encrypt(base64Bytes, false);

            return Convert.ToBase64String(encryptedMessageByte);
        }

        private static byte[] getBytesFromPemFile(string pemString)
        {
            int headerLen = HEADER_PRIVATE_KEY.Length;
            int start = pemString.IndexOf(HEADER_PRIVATE_KEY, StringComparison.Ordinal) + headerLen;
            int end = pemString.IndexOf(FOOTER_PRIVATE_KEY, start, StringComparison.Ordinal) - start;
            
            if (start < 0 || end < 0) 
                return null;
            
            return Convert.FromBase64String(pemString.Substring(start, end));
        }

    }
}
