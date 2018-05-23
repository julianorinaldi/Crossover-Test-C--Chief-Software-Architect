using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SwapEvenSwapOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a1 = { "abcd", "cdab", "dcba", "abcde" };
            string[] b1 = { "cdab", "abcd", "abcd", "cdabe" };
            var result = twins(a1, b1);

            foreach (var str in result)
            {
                Console.WriteLine($"{str}");
            }

            Console.ReadKey();
        }


        static string[] twins(string[] a, string[] b)
        {
            const int maxElements = 10 * 10 * 10;
            if ((a == null || b == null) ||
                (a.Length < 1 || b.Length < 1) || (a.Length > maxElements || b.Length > maxElements))
                throw new Exception("The element needed: 1 ≤ n ≤ 10^3");

            if (a.Length != b.Length)
                throw new Exception("The array a and b contains amount diferences elements");

            List<string> result = new List<string>();
            for (int i = 0; i < a.Length; i++)
            {
                if ((a[i].Length < 1 && a[i].Length > 100) || (b[i].Length < 1 && b[i].Length > 100))
                    throw new Exception("The each elements needed: 1 ≤ length(a[i]), length(b[i]) ≤ 100");

                if (!Regex.IsMatch(a[i], "[a-z]+") || !Regex.IsMatch(b[i], "[a-z]+"))
                    throw new Exception("Strings a[i] and b[i] only can contain lowercase letters (i.e., a through z).");

                if (a[i].Length != b[i].Length)
                {
                    result.Add("No");
                    continue;
                }

                for (int j = 0; j < a[i].Length; j++)
                {
                    var a_j = a[i][j];
                    bool is_a_Even = j % 2 == 0;

                    for (int k = j; k < b[i].Length; k++)
                    {
                        bool is_b_Even = k % 2 == 0;
                        if (b[i][k] == a_j && is_a_Even == is_b_Even)
                        {
                            var b_charArray = b[i].ToCharArray();
                            var b_j = b[i][j];
                            b_charArray[j] = b[i][k];
                            b_charArray[k] = b_j;
                            b[i] = new string(b_charArray);
                            break;
                        }
                    }
                }

                result.Add(a[i] == b[i] ? "Yes" : "No");
            }


            return result.ToArray();
        }
    }
}
