using System;
using System.Linq;
using System.Collections.Generic;

namespace JogoDaForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JogoDaForca jogo = new JogoDaForca();            

            bool jogarNovamente = true;

            while (jogarNovamente)
            {
                jogo.Iniciar();

                Console.WriteLine("\n\nDeseja jogar novamente? \n\n - Sim ( 1 )\n - Não ( 2 )");
                Console.Write("\nOpção: ");
                int resposta;

                while (!int.TryParse(Console.ReadLine(), out resposta) || resposta < 1 || resposta > 2)
                {
                    JogoDaForca.Mensagem("Digite apenas 1 ou 2!");
                }

                jogarNovamente = (resposta == 1);
                Console.Clear();
            }

            Console.WriteLine("Jogo encerrado.");
        }
    }
}
