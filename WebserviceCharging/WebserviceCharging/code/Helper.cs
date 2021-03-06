﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebserviceCharging.code
{
    public class Helper
    {
        private static string createMD5(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static string createSign(string string_sign, string secret)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(createMD5(string_sign));
            sb.Append(createMD5(secret));

            return createMD5(sb.ToString());
        }
    }
}