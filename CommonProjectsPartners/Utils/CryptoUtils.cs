using System;
using System.Security.Cryptography;
using System.Text;

namespace CommonProjectsPartners.Utils;

public static class CryptoUtils
{
    private const string SECURITY_KEY = "Projects$Partners";
    public static string Decrypt(string cipherString, bool useHashing = true)
    {
        byte[] keyArray;
        var toEncryptArray = Convert.FromBase64String(cipherString);

        if (useHashing)
        {
            var hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(SECURITY_KEY));
            hashmd5.Clear();
        }
        else
        {
            keyArray = UTF8Encoding.UTF8.GetBytes(SECURITY_KEY);
        }

        var tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;

        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        var cTransform = tdes.CreateDecryptor();
        var resultArray = cTransform.TransformFinalBlock(
            toEncryptArray, 0, toEncryptArray.Length);
        tdes.Clear();
        return UTF8Encoding.UTF8.GetString(resultArray);
    }
    public static string Encrypt(string toEncrypt, bool useHashing = true)
    {
        byte[] keyArray;
        var toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        if (useHashing)
        {
            var hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(SECURITY_KEY));
            hashmd5.Clear();
        }
        else
            keyArray = UTF8Encoding.UTF8.GetBytes(SECURITY_KEY);

        var tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;

        tdes.Padding = PaddingMode.PKCS7;

        var cTransform = tdes.CreateEncryptor();
        var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        tdes.Clear();
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }
    //  Géneration du password pour l'utilisateur web
    public static string CreatePassword(int length)
    {
        var valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        var special = "*$-+?_&=!%{}/";
        var res = new StringBuilder();
        var rnd = new Random();
        while (0 < length--)
        {
            res.Append(valid[rnd.Next(valid.Length)]);
        }
        res.Append(special[rnd.Next(special.Length)]);
        return res.ToString();
    }
}