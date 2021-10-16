using System;
using System.Security.Cryptography;
using System.Text;

namespace PrisonManagementSystem.Config
{
    public static class AuthUtils
    {
        public static string GetSHA1HashData(string data)
        {
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();

            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));        

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.AppendFormat("{0:x2}", hashData[i]);
            }

            // return hexadecimal string
            return returnValue.ToString();
        }

        public static string GetSecretCode(string appName, string accessKeys)
        {
            var credentials = accessKeys.Split(';');

            foreach (var item in credentials)
            {
                var credential = item.Split(',');
                if (credential.Length > 0 && credential[0] == appName)
                {
                    return credential[1];
                }
            }

            return null;
        }

        public static bool IsDateExpired(DateTime requestTimestamp)
        {
            if (requestTimestamp < DateTime.Now.AddMinutes(-5))
            {
                return true;
            }
            return false;
        }

        public static bool IsDateFutureDate(DateTime requestTimestamp)
        {
            if (requestTimestamp > DateTime.Now.AddMinutes(5))
            {
                return true;
            }
            return false;
        }
    }
}
