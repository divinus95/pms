using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonManagementSystem.Config
{

    public static class EncryptionHelper
    {
        public static string EncryptID(long id)
        {
            try
            {
                return Cipher.Encrypt(id.ToString(), AppConstants.EncryptionKey);
            }
            catch
            {
                return null;
            }
        }

        public static long DecryptID(string encryptedId)
        {
            try
            {
                long id;
                bool success = Int64.TryParse(Cipher.Decrypt(encryptedId, AppConstants.EncryptionKey), out id);

                return success ? id : 0;
            }
            catch
            {
                return 0;
            }
        }

        public static string EncryptConnectionString(string connString)
        {
            try
            {
                return Cipher.Encrypt(connString, AppConstants.EncryptionKey);
            }
            catch
            {
                return null;
            }
        }

        public static string DecryptConnectionString(string encrypted_connString)
        {
            try
            {
                return Cipher.Decrypt(encrypted_connString, AppConstants.EncryptionKey);

            }
            catch
            {
                return null;
            }
        }

        public static string EncryptText(string rawText)
        {
            try
            {
                return Cipher.Encrypt(rawText, AppConstants.EncryptionKey);
            }
            catch
            {
                return null;
            }
        }


        public static string DecryptText(string encryptedText)
        {
            try
            {
                return Cipher.Decrypt(encryptedText, AppConstants.EncryptionKey);

            }
            catch
            {
                return null;
            }
        }
    }
}
