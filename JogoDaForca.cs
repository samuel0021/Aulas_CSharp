using System;
using System.Linq;
using System.Collections.Generic;

namespace JogoDaForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string palavra, entrada;
            int tent = 5;
            int qtdLetras;
            char resposta;

            List<string> palavras = new List<string>
            {
                "abacaxi", "computador", "janela", "livro", "telefone",
                "girassol", "elefante", "montanha", "bicicleta", "oceano",
                "planeta", "violino", "sapato", "chave", "cadeira",
                "grama", "relogio", "avião", "nuvem", "cenoura"
            };

            Random rand = new Random();
            palavra = palavras[rand.Next(palavras.Count)];

            qtdLetras = palavra.Length;


            char[] letras = new char[qtdLetras];
            List<char> letrasErradas = new List<char>();
            List<char> letrasJaUsadas = new List<char>();

            for (int i = 0; i < qtdLetras; i++)
            {
                letras[i] = '_';
            }

            while (new string(letras) != palavra && tent > 0)
            {
                Console.Clear();

                Console.WriteLine("\nJogo da Forca");

                Console.WriteLine("\nA palavra tem " + qtdLetras + " letras\n");

                Console.WriteLine("Palavra: " + string.Join(" ", letras) + "\n");
                Console.WriteLine("Tentativas: " + tent);
                Console.WriteLine("Letras erradas: " + string.Join(" ", letrasErradas));

                Console.Write("\nDigite uma letra: ");
                entrada = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(entrada) || entrada.Length != 1)
                {
                    Console.WriteLine("\nDigite apenas uma letra!\nAperte qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                    continue;
                }

                resposta = entrada[0];

                if (letrasJaUsadas.Contains(resposta))
                {
                    Console.WriteLine("\nVocê já tentou essa letra!\nAperte qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                    continue;
                }

                bool letraValida = false;

                for (int i = 0; i < qtdLetras; i++)
                {
                    if (resposta == palavra[i])
                    {
                        letras[i] = resposta;
                        letraValida = true;
                        letrasJaUsadas.Add(resposta);
                    }
                }
                if (letraValida == false)
                {
                    Console.WriteLine("\nLetra errada!\nAperte qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                    letrasErradas.Add(resposta);
                    letrasJaUsadas.Add(resposta);
                    tent--;
                }
            }
            if (tent <= 0)
            {
                Console.Clear();
                Console.WriteLine("Palavra: " + string.Join(" ", letras));
                Console.WriteLine("Tentativas: " + tent);
                Console.WriteLine("\nAs tentativas acabaram!\nPerdeu!");
                Console.WriteLine("A palavra era " + palavra);
            }
            else
            {
                Console.Clear();

                Console.WriteLine("Palavra: " + string.Join(" ", letras));
                Console.WriteLine("Tentativas: " + tent);
                Console.WriteLine("\nParabéns!");
            }
        }
    }
}

