using System;
using System.Linq;

namespace ToLowerCase
{
    /// <summary>
    /// Covert string to lower case
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = "HeLlo";
            var output = ToLowerCase(input);
            Console.WriteLine(output);
        }

        /// <summary>
        /// replace version
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToLowerCase(string str)
        {
            var arrString = str.Distinct();
            foreach(var item in arrString)
            {
                if(item >= 'A' && item <= 'Z')
                {
                    var replace = (char)(item - 'A' + 'a');
                    str = str.Replace(item, replace);
                }
            }
            return str;
        }

        public static string ToLowerCase1(string str)
        {
            var arrString = str.ToCharArray();
            for (var i = 0; i < arrString.Length; i++)
            {
                if (arrString[i] >= 'A' && arrString[i] <= 'Z')
                {
                    arrString[i] = (char)(arrString[i] - 'A' + 'a');
                }
            }
            return new string(arrString);
        }
    }
}
