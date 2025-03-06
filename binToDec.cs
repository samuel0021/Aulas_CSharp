using System;

namespace treinoObjetos
{
    public class Solution
    {
        public int binToDec(string n)
        {
            int bin = 0;
            int j = 0;
            int num;

            for(int i = n.Length - 1; i >= 0; i--)
            {
                num = Convert.ToInt32(n[i]) - '0';
                bin += num * ((int)Math.Pow(2, j));
                j++;
            }

            return bin;
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
