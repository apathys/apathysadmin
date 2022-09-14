﻿using System; 
using System.Security.Cryptography;
using System.Text; 

namespace Common
{
    public class MD5Helper
    {
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String GetMD5(String str) 
        {
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
           return BitConverter.ToString(output).Replace("-", "");
        }
    }
}
