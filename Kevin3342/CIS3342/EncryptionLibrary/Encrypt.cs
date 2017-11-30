using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace EncryptionLibrary
{
    public class Encrypt
    {
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };

        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };


        public string encryptString(string plainText)
        {
            string encryptedString = "";

            UTF8Encoding encoder = new UTF8Encoding();

            Byte[] textBytes = encoder.GetBytes(plainText);

            RijndaelManaged rmEncryption = new RijndaelManaged();
            MemoryStream myMemoryStream = new MemoryStream();
            CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

            myEncryptionStream.Write(textBytes, 0, textBytes.Length);
            myEncryptionStream.FlushFinalBlock();

            myMemoryStream.Position = 0;
            Byte[] encryptedBytes = new Byte[myMemoryStream.Length];
            myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);

            myEncryptionStream.Close();
            myMemoryStream.Close();

            encryptedString = Convert.ToBase64String(encryptedBytes);

            return encryptedString;
        }

        public string decryptString(string encryptedString)
        {
            string plainText = "";

            Byte[] encryptedStringBytes = Convert.FromBase64String(encryptedString);
            UTF8Encoding encoder = new UTF8Encoding();

            RijndaelManaged rmEncryption = new RijndaelManaged();
            MemoryStream myMemoryStream = new MemoryStream();
            CryptoStream myDecryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateDecryptor(key, vector), CryptoStreamMode.Write);

            myDecryptionStream.Write(encryptedStringBytes, 0, encryptedStringBytes.Length);
            myDecryptionStream.FlushFinalBlock();

            myMemoryStream.Position = 0;
            Byte[] textBytes = new Byte[myMemoryStream.Length];
            myMemoryStream.Read(textBytes, 0, textBytes.Length);

            myDecryptionStream.Close();
            myMemoryStream.Close();

            plainText = encoder.GetString(textBytes);

            return plainText;
        }
    }

   
}
