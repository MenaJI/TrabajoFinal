

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class Encriptador
{
    public static string EncryptString(string plainText)
    {
        
        byte[] key = new byte[]{ 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F }; 
        byte[] iv = new byte[]{ 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F }; 
        
        RijndaelManaged rijndaelCipher = new RijndaelManaged();

        
        rijndaelCipher.KeySize = 256;
        rijndaelCipher.Key = key;
        rijndaelCipher.IV = iv;

        
        MemoryStream memoryStream = new MemoryStream();

        
        ICryptoTransform rijndaelEncryptor = rijndaelCipher.CreateEncryptor();

        CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelEncryptor, CryptoStreamMode.Write);

        byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);

        cryptoStream.Write(plainBytes, 0, plainBytes.Length);

        cryptoStream.FlushFinalBlock();

        byte[] cipherBytes = memoryStream.ToArray();

        memoryStream.Close();
        cryptoStream.Close();

        string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);

        return cipherText;
    }


    public static string DecryptString(string cipherText)
    {
        RijndaelManaged rijndaelCipher = new RijndaelManaged();
        byte[] key = new byte[]{ 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F }; 
        byte[] iv = new byte[]{ 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F }; 
        
        rijndaelCipher.Key = key;
        rijndaelCipher.IV = iv;

        
        MemoryStream memoryStream = new MemoryStream();
        
        ICryptoTransform rijndaelDecryptor = rijndaelCipher.CreateDecryptor();

        CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelDecryptor, CryptoStreamMode.Write);

        string plainText = String.Empty;

        try
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);


            cryptoStream.FlushFinalBlock();

            byte[] plainBytes = memoryStream.ToArray();

            plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
        }
        finally
        {
            memoryStream.Close();
            cryptoStream.Close();
        }
        
        return plainText;
    }
}