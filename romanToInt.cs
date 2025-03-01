using System;

namespace treinoObjetos
{
    public class Solution
    {
        public int RomanToInt(string s)
        {
            int num = 0;

            Dictionary<char, int> numeros = new Dictionary<char, int>
            {
                {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
                {'C', 100}, {'D', 500}, {'M', 1000}
            };

            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1 && numeros[s[i]] < numeros[s[i + 1]])
                {
                    num -= numeros[s[i]];
                }
                else
                {
                    num += numeros[s[i]];
                }
            }
            return num;
        }
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.Write("\nDigite um número em algarismos romanos: ");
            string num = Console.ReadLine().ToUpper();

            Console.WriteLine("\n" + solution.RomanToInt(num));
        }
    }
}
