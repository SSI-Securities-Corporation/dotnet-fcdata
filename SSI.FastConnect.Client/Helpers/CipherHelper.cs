using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SSI.FastConnect.Client.Helpers
{
    public class CipherHelper
    {
        public static byte[] DecryptText(byte[] input, string password, byte[] randBytes)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            var bytesDecrypted = AES_Decrypt(input, passwordBytes, randBytes);
            return bytesDecrypted;
        }

        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes, byte[] saltBytes)
        {
            byte[] decryptedBytes;
            using (var ms = new MemoryStream())
            {
                using (var aes = new AesManaged())
                {
                    aes.KeySize = CommonConstant.RIJNDAEL_KEY_SIZE;
                    aes.BlockSize = CommonConstant.RIJNDAEL_BLOCK_SIZE;
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, CommonConstant.ITERATIONS);
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }

        public static byte[] EncryptText(byte[] input, string password, byte[] randBytes)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            var bytesEncrypted = AES_Encrypt(input, passwordBytes, randBytes);
            return bytesEncrypted;
        }

        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes, byte[] saltBytes)
        {
            byte[] encryptedBytes;
            using (var ms = new MemoryStream())
            {
                using (var aes = new AesCryptoServiceProvider())
                {
                    aes.KeySize = CommonConstant.RIJNDAEL_KEY_SIZE;
                    aes.BlockSize = CommonConstant.RIJNDAEL_BLOCK_SIZE;
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, CommonConstant.ITERATIONS);
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }

        public static string Encryption(byte[] data2Encrypt, string pubKey = "")
        {
            var base64Encrypted = "";
            try
            {
                if (string.IsNullOrEmpty(pubKey))
                {
                    throw new ArgumentNullException(nameof(pubKey));
                }
                if (data2Encrypt.Length == 0)
                {
                    throw new ArgumentNullException(nameof(data2Encrypt));
                }
                pubKey = Encoding.UTF8.GetString(Convert.FromBase64String(pubKey));
                using (var rsa = new RSACryptoServiceProvider(CommonConstant.RSA_KEY_SIZE))
                {
                    try
                    {
                        RsaKeyExtensions.FromXmlString(rsa, pubKey);
                        var encryptedData = rsa.Encrypt(data2Encrypt, true);
                        base64Encrypted = Convert.ToBase64String(encryptedData);
                    }
                    finally
                    {
                        rsa.PersistKeyInCsp = false;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return base64Encrypted;
        }
    }
}
