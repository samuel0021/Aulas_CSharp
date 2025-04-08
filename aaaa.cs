
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
