﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CobolToCSharp
{
    public static class CustomExtensions
    {
        public static void Merge<TKey,TValue>(this Dictionary<TKey, TValue> SourceDic, Dictionary<TKey, TValue> Dic)
        {
            foreach (var Key in Dic.Keys)
            {
                if (!SourceDic.ContainsKey(Key))
                    SourceDic.Add(Key, Dic[Key]);
            }
        }
        public static string RegexUpperLower(this string Regex)
        {
            string result = string.Empty;
            foreach (char C in Regex)
            {
                if (C >= 'A' && C < 'Z')
                {
                    result += $"[{C}{C.ToString().ToLower()}]";
                }
                else
                {
                    result += C;
                }

            }
            return result;
        }
        public static string RegexReplace(this string source, string oldValue,string newValue)
        {
            return new Regex(oldValue.RegexUpperLower()).Replace(source, newValue);            
        }
    }
}
