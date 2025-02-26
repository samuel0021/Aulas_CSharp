using System;

namespace treinoObjetos
{
    public class Solution
    {
        public static int[] nums1 = { 2, 1 };
        public static int[] nums2 = { 4, 3 };

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

            sortArray(mergedArray);

            Console.WriteLine("Array ordenado: ");
            for (int i = 0; i < mergedArray.Length; i++)
            {
                Console.Write(mergedArray[i] + " ");
            }
            Console.ReadKey();

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

        static void sortArray(int[] array)
        {
            int temp;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
