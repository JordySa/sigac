using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace sigac.Helper
{
    public class Encrypt
    {
        public const string KeySecret = "C@l1D@dGest!0n";

        public static string EncryptCadena(string value, string secret)
        {
            //Encrypting 
            byte[] initial_text_bytes = Encoding.UTF8.GetBytes(value);
            byte[] secret_word_bytes = Encoding.UTF8.GetBytes(secret)
;
            byte[] encrypted_bytes = new byte[initial_text_bytes.Length];




            int secret_word_index = 0;
            for (int i = 0; i < initial_text_bytes.Length; i++)
            {
                if (secret_word_index == secret_word_bytes.Length)
                {
                    secret_word_index = 0;
                }
                encrypted_bytes[i] = (byte)(initial_text_bytes[i] + secret_word_bytes[secret_word_index]);
                secret_word_index++;
            }

            return Convert.ToBase64String(encrypted_bytes);
        }

        public static string DecryptCadena(string value, string secret)
        {
            //Decrypting
            byte[] initial_text_bytes = Convert.FromBase64String(value);
            byte[] secret_word_bytes = Encoding.UTF8.GetBytes(secret)
;
            byte[] encrypted_bytes = new byte[initial_text_bytes.Length];

            int secret_word_index = 0;
            for (int i = 0; i < initial_text_bytes.Length; i++)
            {
                if (secret_word_index == secret_word_bytes.Length)
                {
                    secret_word_index = 0;
                }
                encrypted_bytes[i] = (byte)(initial_text_bytes[i] - secret_word_bytes[secret_word_index]);
                secret_word_index++;
            }

            return Encoding.UTF8.GetString(encrypted_bytes);

        }
    }

}