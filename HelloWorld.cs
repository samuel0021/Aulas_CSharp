using System;
using System.Threading;

internal class Program
{
    static void Main(string[] args)
    {
        string text = "HELLO WORLD";
        string newText = "";
        
        foreach(char c in text)
        {
            for(char x = 'A'; x <= 'Z'; x++)
            {
                Console.Clear();
                Console.WriteLine("\n" + newText + x + "\n");
                Thread.Sleep(10);

                if (c == ' ' || x == c)
                {
                    newText += c == ' ' ? ' ' : c;
                    break;
                }
            }
        }
    }
}

//-------------------------------------------------------

for (int i = 32; i <= 90 || i >= 97 || i <= 122; i++)
{
    char x = (char)i;

    Console.Clear();
    Console.Write("\n" + newText + x + "\n");
    Thread.Sleep(10);

    if (x == c)
    {
        newText += c;
        break;
    }

}
////////////////////////////////////////////////////////////////

using System;
using System.Threading;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "*helL]O WORLD!";
            string newText = "";

            foreach (char c in text)
            {
                if (((int)c < 65 || (int)c > 90) && ((int)c <97 || (int)c > 122))
                {
                    for (int i = 32; i <= 64 || i >= 91 || i <= 96; i++)
                    {
                        char x = (char)i;

                        //Console.Clear();
                        Console.WriteLine("\n" + newText + x);
                        Thread.Sleep(10);

                        if (x == c)
                        {
                            newText += c;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 65; i <= 122; i++)
                    {
                        if ((i >= 65 && i <= 90) || (i >= 97 && i <= 122))
                        { 
                            char x = (char)i;

                            //Console.Clear();
                            Console.WriteLine("\n" + newText + x);
                            Thread.Sleep(10);

                            if (x == c)
                            {
                                newText += c;
                                break;
                            }
                        }                        
                    }
                }
            }
        }
    }
}
