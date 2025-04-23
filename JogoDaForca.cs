namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nJogo da Forca");

            string palavra;
            int chances = 5;
            int qtdLetras;
            char letra;

            palavra = "samuel";
            qtdLetras = palavra.Length;

            Console.WriteLine("\nA palavra tem " + qtdLetras + " letras");

            
            for (int i = 0; i < palavra.Length; i++)
            {
                do
                {
                    Console.WriteLine("\nTentativas: " + chances);
                    Console.Write("Digite a " + (i + 1) + "ª letra: ");
                    letra = char.Parse(Console.ReadLine().ToLower());

                    if (letra != palavra[i])
                    {
                        chances--;

                        if (chances <= 0)
                        {
                            Console.WriteLine("As tentativas acabaram!");
                            break;
                        }
                    }
                    else continue;
                }
                while (letra != palavra[i]);
            }
        }
    }
}
