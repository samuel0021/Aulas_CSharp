using System;
using System.Collections.Generic;

namespace JogoDaForca
{
    public class JogoDaForca
    {
        private int Tentativas;
        private string Palavra, NomeTemaAtual, Dificuldade;
        private char[] Letras;
        private List<char> LetrasErradas = new List<char>();
        private List<char> LetrasUsadas = new List<char>();
        private List<string> Tema = new List<string>();

        public void Iniciar()
        {
            Tema = EscolherTema();
            Tentativas = EscolherDificuldade();

            Palavra = EscolherPalavraAleatoria(Tema);
            Letras = new string('_', Palavra.Length).ToCharArray();

            while (new string(Letras) != Palavra && Tentativas > 0)
            {
                Console.Clear();
                MostrarStatus();

                char entrada = LerEntrada();

                if (LetrasUsadas.Contains(entrada))
                {
                    Mensagem("Você já tentou essa letra!");
                    continue;
                }

                LetrasUsadas.Add(entrada);

                if (Palavra.Contains(entrada))
                {
                    RevelarLetra(entrada);
                }
                else
                {
                    LetrasErradas.Add(entrada);
                    Tentativas--;
                    Mensagem("Letra errada!");
                }
            }

            FinalizarJogo();
        }

        private string EscolherPalavraAleatoria(List<string> temas)
        {
            Random rand = new Random();
            return temas[rand.Next(temas.Count)];
        }

        private char LerEntrada()
        {
            Console.Clear();

            MostrarStatus();

            Console.Write("\nDigite uma letra: ");
            string entrada = Console.ReadLine().ToLower();

            if (string.IsNullOrWhiteSpace(entrada) || entrada.Length != 1)
            {
                Mensagem("Digite apenas uma letra!");
                return LerEntrada();
            }

            return entrada[0];
        }

        private void RevelarLetra(char letra)
        {
            for (int i = 0; i < Palavra.Length; i++)
            {
                if (Palavra[i] == letra)
                {
                    Letras[i] = letra;
                }
            }
        }

        private int EscolherDificuldade()
        {
            Console.Clear();

            int dificuldade;

            Console.WriteLine("\n   Escolha a dificuldade do jogo: ");
            Console.WriteLine("\n - Fácil   ( 1 )\n - Médio   ( 2 )\n - Difícil ( 3 )");
            Console.Write("\nOpção: ");

            while (!int.TryParse(Console.ReadLine(), out dificuldade) || dificuldade < 1 || dificuldade > 3)
            {
                Mensagem("Digite apenas um número de 1 a 3!");
                return EscolherDificuldade();
            }

            switch (dificuldade)
            {
                case 1:
                    Dificuldade = "Fácil";
                    Tentativas = 7;
                    break;

                case 2:
                    Dificuldade = "Médio";
                    Tentativas = 5;
                    break;

                case 3:
                    Dificuldade = "Difícil";
                    Tentativas = 3;
                    break;
            }

            return Tentativas;
        }

        private List<string> EscolherTema()
        {
            Console.Clear();

            int tema;
            List<string> listaEscolhida = null;

            Console.WriteLine("\n   Escolha o tema da palavra: ");
            Console.WriteLine("\n - Comidas ( 1 ) - Lugares ( 2 )" +
                              "\n - Animais ( 3 ) - Objetos ( 4 )" +
                              "\n - Espaço  ( 5 ) - Extras  ( 6 )" +
                              "\n - Tecnologia ( 7 ) - Meios de Transporte ( 8 )" +
                              "\n - Cores ( 9 ) - Instrumentos Musicais ( 10 )\n");

            Console.Write("\nOpção: ");

            while (!int.TryParse(Console.ReadLine(), out tema) || tema < 1 || tema > 6)
            {
                Mensagem("Digite apenas um número de 1 a 6!");
                return EscolherTema();
            }

            switch (tema)
            {
                case 1:
                    NomeTemaAtual = "Comidas";
                    listaEscolhida = Temas.comidas;
                    break;
                case 2:
                    NomeTemaAtual = "Lugares";
                    listaEscolhida = Temas.lugares;
                    break;
                case 3:
                    NomeTemaAtual = "Animais";
                    listaEscolhida = Temas.animais;
                    break;
                case 4:
                    NomeTemaAtual = "Objetos";
                    listaEscolhida = Temas.objetos;
                    break;
                case 5:
                    NomeTemaAtual = "Espaço";
                    listaEscolhida = Temas.espaco;
                    break;
                case 6:
                    NomeTemaAtual = "Extras";
                    listaEscolhida = Temas.extras;
                    break;
                case 7:
                    NomeTemaAtual = "Tecnologia";
                    listaEscolhida = Temas.tecnologia;
                    break;
                case 8:
                    NomeTemaAtual = "Meios de Transporte";
                    listaEscolhida = Temas.transportes;
                    break;
                case 9:
                    NomeTemaAtual = "Cores";
                    listaEscolhida = Temas.cores;
                    break;
                case 10:
                    NomeTemaAtual = "Instrumentos Musicais";
                    listaEscolhida = Temas.instrumentosMusicais;
                    break;
            }


            return listaEscolhida;
        }

        private void MostrarStatus()
        {
            Console.WriteLine("\nJogo da Forca");
            Console.WriteLine("\nTema: " + NomeTemaAtual);
            Console.WriteLine("Dificuldade: " + Dificuldade);
            Console.WriteLine("\nA palavra tem " + Palavra.Length + " letras\n");
            Console.WriteLine("Palavra: " + string.Join(" ", Letras));
            Console.WriteLine("\nTentativas: " + Tentativas);
            Console.WriteLine("Letras erradas: " + string.Join(" ", LetrasErradas));
        }

        private void Mensagem(string texto)
        {
            Console.WriteLine($"\n{texto}\nAperte qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private void FinalizarJogo()
        {
            Console.Clear();
            Console.WriteLine("Palavra: " + string.Join(" ", Letras));
            Console.WriteLine("Tentativas restantes: " + Tentativas);

            if (Tentativas > 0)
                Console.WriteLine("\nParabéns! Você acertou!");
            else
                Console.WriteLine("\nParabéns! Você perdeu!");

            Console.WriteLine("\nA palavra era: " + Palavra);
        }
    }
}
