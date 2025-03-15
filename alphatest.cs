namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "HELLO WORLD";

            foreach(char c in text){
                for(char x = 'A'; x <= 'Z'; x++)
                {
                    Console.WriteLine(x);
                    if(x == c)
                    {
                        
                    }
                }
            }

            Console.WriteLine(text);
        }
    }
}
