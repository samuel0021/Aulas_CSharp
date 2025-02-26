using System;

namespace treinoObjetos
{
    public class Solution
    {
        public static int[] nums1 = { 1, 2 };
        public static int[] nums2 = { 3, 4, 5 };

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;

            int[] mergedArray = new int[m + n];

            for (int i = 0; i < m; i++)
            {
                mergedArray[i] = nums1[i];
            }
            for (int i = 0; i < n; i++)
            {
                mergedArray[m + i] = nums2[i];
            }

            Array.Sort(mergedArray);

            int len = mergedArray.Length;
            if (len % 2 == 0)
            {
                return (mergedArray[len / 2 - 1] + mergedArray[len / 2]) / 2.0;
            }

            return mergedArray[len / 2];

        }


        static void Main(string[] args)
        {
            Solution sol = new Solution();

            double resultado = sol.FindMedianSortedArrays(Solution.nums1, Solution.nums2);

            Console.WriteLine("Mediana dos elementos: " + resultado);
        }
    }
}
