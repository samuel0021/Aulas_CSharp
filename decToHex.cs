using System;

namespace treinoObjetos
{
    public class Solution
    {
        Dictionary<int, char> hexa = new Dictionary<int, char>
        {
            {10, 'A'}, {11, 'B'}, {12, 'C'}, {13, 'D'}, {14, 'E'}, {15, 'F'}
        };

        public string decToHex(int n)
        {
            string hex = "";
            int resto;

            while(n > 0)
            {
                resto = n % 16;

                if (resto >= 10)
                {
                    if (hexa.TryGetValue(resto, out char hexChar))
                    {
                        hex = (hexChar) + hex;
                    }
                    else
                    {
                        hex = resto + hex;
                    }
                }
                else hex = resto + hex;

                n /= 16;
            }

            return hex;
        }

        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.Write("\nDigite um número decimal: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("\nNúmero em hexadecimal: " + solution.decToHex(num));
        }
    }
}
