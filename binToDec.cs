using System;

namespace treinoObjetos
{
    public class Solution
    {
        public int binToDec(string n)
        {
            int dec = 0, j = 0, digito;

            for(int i = n.Length - 1; i >= 0; i--)
            {
                digito = n[i] - '0';
                dec += digito * ((int)Math.Pow(2, j));
                j++;
            }

            return dec;
        }

        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.Write("\nDigite um número em binário: ");
            string num = Console.ReadLine();

            Console.WriteLine("\nNúmero em decimal: " + solution.binToDec(num));
        }
    }
}
