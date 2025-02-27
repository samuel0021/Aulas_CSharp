using System;

namespace treinoObjetos
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            int len = x.ToString().Length;
            int[] arrayNum = new int[len];
            int[] revNum = new int[len];

            if (x < 0) return false;

            for (int i = len - 1; i >= 0; i--)
            {
                arrayNum[i] = x % 10;
                x /= 10;
            }

            Array.Copy(arrayNum, revNum, arrayNum.Length);
            Array.Reverse(revNum);

            for (int i = 0; i < len; i++)
            {
                if (arrayNum[i] != revNum[i])
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.Write("\nDigite um número: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("\n" + solution.IsPalindrome(num));
        }
    }
}
