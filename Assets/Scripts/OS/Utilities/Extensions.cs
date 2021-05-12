using System;
using System.Collections;
using UnityEngine;

namespace OS.Utilities
{
    public static class Extensions
    {
        /// <summary>
        /// Turns string in to a camel case one.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string str)
        {                    
            if(!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return Char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }

        /// <summary>
        /// Finds and replaces tag in text.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <param name="tag">Tag to replace.</param>
        /// <param name="replacement">Replacement value.</param>
        /// <returns></returns>
        public static string ReplaceTag(this string text, int tag, string replacement)
        {
            return text.Replace($"#{tag}", replacement);
        }
        
        public static bool CheckParentRecursive(this GameObject gameObject, GameObject search)
        {
            Transform parent = gameObject.transform.parent; 
            
            if (parent == null)
            {
                return false;
            }

            return parent.gameObject == search || parent.gameObject.CheckParentRecursive(search);
        }

        public static bool IsNullOrEmpty(this IList list)
        {
            return list == null || list.Count == 0;
        }
    }
}
