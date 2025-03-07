using System;
using System.Collections.Generic;

namespace substrings
{
    internal class Program
    {
        public class Solution
        {
            public int LengthOfLastWord(string s)
            {
                string[] substrings = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string lastWord = substrings[substrings.Length - 1];
                char[] characters = lastWord.ToCharArray();
                int lastLength = 0;

                if (substrings.Length == 0) return 0;

                for (int i = 0; i < characters.Length; i++)
                {
                    if (char.IsLetterOrDigit(characters[i]))
                    {
                        lastLength++;
                    }
                }
                return lastLength;
            }
        }

        static void Main(string[] args)
        {
            Solution solution = new Solution();

            int length = solution.LengthOfLastWord("Preciso de um novo emprego!");

            Console.WriteLine("\nO comprimento da última string é: " + length);
        }
    }
}
