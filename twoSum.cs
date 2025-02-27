using System;

namespace treinoObjetos
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int sum;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    sum = nums[i] + nums[j];

                    if (sum == target)
                    {
                        int[] index = { nums[i], nums[j] };

                        return new int[] { i, j };
                    }
                }
            }
            return new int[0];
        }
        static void Main(string[] args)
        {
            Console.Write("\nDigite a quantidade de números: ");
            int qtd = int.Parse(Console.ReadLine());

            int[] nums = new int[qtd];

            for (int i = 0; i < qtd; i++)
            {
                Console.Write("\nDigite o " + (i + 1) +"º número: ");
                nums[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("\nDigite o alvo da soma: ");
            int alvo = int.Parse(Console.ReadLine());

            Solution sol = new Solution();

            int[] resultado = sol.TwoSum(nums, alvo);

            Console.Write("\nResultado: ");
            foreach (int i in resultado)
            {
                Console.Write(i + " ");
            }
        }
    }
}
