using System;

namespace treinoObjetos
{
    public class Solution
    {
        public int decToBin(int n)
        {

            return n;
        }

        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine("\nDigite um número decimal: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("\nNúmero em binário: " + solution.decToBin(num));
        }
    }
}
