﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckDriverApp.Common
{
    public  static class PasswordType
    {
        public static string Key = "adef@@kfxcbv@";
        public static string ConvertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }
      /*  public static string  ConvertToDecrypt(string base64EncodData)
        {
            if (string.IsNullOrEmpty(base64EncodData))
                return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
            

        }*/
    }
}
