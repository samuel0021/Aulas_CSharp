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
                Console.WriteLine(newText + x);
                Thread.Sleep(10);
                    
                if(c == ' ')
                { 
                    newText += ' ';
                    break;
                }
                if(x == c)
                {
                    newText += c;
                    break;
                }
            }
        }
    }
}
