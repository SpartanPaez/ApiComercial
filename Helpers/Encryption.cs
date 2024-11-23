using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.DataProtection;

namespace ApiComercial.Helpers
{
    public class Encryption
    {
        private readonly IDataProtector _dataprovider;
        public  Encryption(IDataProtectionProvider provider)
        {
            _dataprovider = provider.CreateProtector("ApiComercial");
        }
        public string Encrypt(string text)
        {
            return  _dataprovider.Protect(text);
        }
        public string Decrypt(string text)
        {
            return _dataprovider.Unprotect(text);
        }
        //Devolver el valor de Encrypt para inyectarlo en el controllador
        public static string GetEncrypt(string text)
        {
            Encryption encryption = new Encryption(DataProtectionProvider.Create("ApiComercial"));
            return encryption.Encrypt(text);
        }

      
        
        /// encripta y devuelve el string con una longitu de 256 caracteres con guiones
        /// </summary>
        /// <param name="strText">texto a encriptar</param>
        /// <param name="strEncrKey">llave de encriptacion</param>
        /// <returns></returns>
        public static string Encrypt4(string strText, string strEncrKey)
        {
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X4}", b);
                }
                string cadena = ret.ToString();
                string cadena2 = "";
                int contador = 0;
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (contador == 4)
                    {
                        cadena2 += "-";
                        contador = 0;
                    }
                    cadena2 += cadena[i];
                    contador++;
                }
                return cadena2;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        
        
    }
}