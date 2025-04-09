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
                Console.WriteLine(newText + x);
                Thread.Sleep(50);
                    
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
