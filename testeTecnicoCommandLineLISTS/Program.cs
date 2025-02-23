/*
 Teste técnico - Processo Seletivo | Maxiprod
 Nome: Samuel Parra Vieira 
 */

using System;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace testeTecnicoCommandLine
{
    internal class Program
    {
        //listas que vão guardar as informações das pessoas
        static List<string> nomes = new List<string>();
        static List<int> idades = new List<int>();
        static List<int> ids = new List<int>();

        //variável para gerar um id único para cada pessoa
        static int idsCont = 0;
        static int totalPessoas = 0;

        //listas que vão guardar as informações das transações com quantidades maiores, pois, podem várias transações por pessoa cadastrada
        static List<string> descricoes = new List<string>();
        static List<string> tipos = new List<string>();
        static List<double> valores = new List<double>();
        static List<int> idsTransacoes = new List<int>();
        static List<string> pessoaCorrespondente = new List<string>();
        static List<int> idsPessoaCorrespondente = new List<int>();
        static int totalTransacoes = 0;
        static double totalGeralDespesas = 0;
        static double totalGeralReceitas = 0;
        static double saldoLiquidoTotal = 0;

        static void Main(string[] args)
        {
            //inicializa já com pessoas e transações cadastradas para facilitar na hora de testar
            //duas pessoas
            nomes.Add("Samuel");
            idades.Add(23);
            ids.Add(idsCont);
            totalPessoas++;
            idsCont++;

            nomes.Add("Luna");
            idades.Add(22);
            ids.Add(idsCont);
            totalPessoas++;
            idsCont++;

            //duas transações para cada pessoa
            tipos.Add("Receita");
            valores.Add(1000);
            descricoes.Add("Salário");
            idsTransacoes.Add(0);
            pessoaCorrespondente.Add("Samuel");
            idsPessoaCorrespondente.Add(0);
            totalTransacoes++;

            tipos.Add("Despesa");
            valores.Add(100);
            descricoes.Add("Contas");
            idsTransacoes.Add(1);
            pessoaCorrespondente.Add("Samuel");
            idsPessoaCorrespondente.Add(0);
            totalTransacoes++;

            tipos.Add("Receita");
            valores.Add(2000);
            descricoes.Add("Salário");
            idsTransacoes.Add(2);
            pessoaCorrespondente.Add("Luna");
            idsPessoaCorrespondente.Add(1);
            totalTransacoes++;

            tipos.Add("Despesa");
            valores.Add(300);
            descricoes.Add("Contas");
            idsTransacoes.Add(3);
            pessoaCorrespondente.Add("Luna");
            idsPessoaCorrespondente.Add(1);
            totalTransacoes++;

            for (int i = 0; i < totalTransacoes; i++)
            {
                if (tipos[i] == "Receita")
                {
                    totalGeralReceitas += valores[i];
                }

                if (tipos[i] == "Despesa")
                {
                    totalGeralDespesas += valores[i];
                }
            }
            saldoLiquidoTotal = totalGeralReceitas - totalGeralDespesas;

            /////////////////////////////////////////////////////////////////////

            string op;

            //loop que repete até que o usuário digite uma opção válida
            while (true)
            {
                limpaTela();

                Console.WriteLine("\n\t --- Bem vindo! --- \n\n");

                Console.WriteLine(" 1 - Pessoas");
                Console.WriteLine(" 2 - Transações");
                Console.WriteLine(" 3 - Consulta de totais");
                Console.WriteLine("\n 0 - Sair");

                Console.Write("\n - Opção: ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        limpaTela();
                        menuPessoas();
                        break;

                    case "2":
                        limpaTela();
                        menuTransacoes();
                        break;

                    case "3":
                        limpaTela();
                        consultaTotais();
                        break;

                    case "0":
                        limpaTela();
                        Console.WriteLine("\n\n\tPrograma encerrado");
                        return;

                    default:
                        Console.WriteLine("\nOpção inválida!\nPressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void menuPessoas()
        {
            string op;

            while (true)
            {
                limpaTela();

                Console.WriteLine("\n\t --- Pessoas --- \n\n");

                Console.WriteLine(" 1 - Cadastrar");
                Console.WriteLine(" 2 - Listar");
                Console.WriteLine(" 3 - Deletar");
                Console.WriteLine("\n 0 - Voltar");

                Console.Write("\n - Opção: ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        limpaTela();
                        cadPessoa();
                        break;

                    case "2":
                        limpaTela();
                        listaPessoa();
                        break;

                    case "3":
                        limpaTela();
                        delPessoa();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("\nOpção inválida!\nPressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void cadPessoa()
        {
            Console.WriteLine("\n\t --- Cadastrar Pessoa --- \n\n");

            //adiciona os valores digitados às suas respectivas listas e atualiza o contador de pessoas 
            Console.Write("\t Nome completo: ");
            nomes.Add(Console.ReadLine());

            Console.Write("\t         Idade: ");
            idades.Add(int.Parse(Console.ReadLine()));

            ids.Add(idsCont);

            idsCont++;
            totalPessoas = ids.Count;

            Console.WriteLine("\n\nPessoa cadastrada com sucesso!\n\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
            limpaTela();
        }

        static void listaPessoa()
        {
            //verifica se existem pessoas cadastradas
            if (totalPessoas == 0)
            {
                Console.WriteLine("\nNenhuma pessoa cadastrada!\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\n\t\t --- Clientes Cadastrados --- \n\n");

            //percorre as listas para mostrar as pessoas cadastradas
            for (int i = 0; i < ids.Count; i++)
            {
                Console.WriteLine("\t\t\t   ID: " + ids[i]);
                Console.WriteLine("\t\t\t Nome: " + nomes[i]);
                Console.WriteLine("\t\t\tIdade: " + idades[i]);
                Console.WriteLine("\t\t-------------------------------");
            }
            Console.WriteLine("\nFim da lista.\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void delPessoa()
        {
            //variável para a pessoa que será excluída
            int idExc;

            //verifica se existem pessoas cadastradas
            if (totalPessoas == 0)
            {
                Console.WriteLine("\nNenhuma pessoa cadastrada!\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            //mostra as pessoas cadastradas para melhor visualização antes de deletar
            Console.WriteLine("\n\n\t\t --- Exclusão de Pessoas ---\n");

            for (int i = 0; i < ids.Count; i++)
            {
                Console.WriteLine("\t\t\t   ID: " + ids[i]);
                Console.WriteLine("\t\t\t Nome: " + nomes[i]);
                Console.WriteLine("\t\t-------------------------------");
            }

            Console.Write("\nDigite o ID da pessoa que deseja excluir: ");
            idExc = int.Parse(Console.ReadLine());

            //variavel para achar o índice certo a partir do id único da pessoa, porque o id é diferente do índice na lista
            int index = ids.IndexOf(idExc);

            //verifica se o id digitado é válido
            if (index == -1)
            {
                Console.WriteLine("\nPessoa não existente.");
                Console.WriteLine("\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                limpaTela();
                return;
            }
            //chama a função para excluir as transações antes da pessoa senão dá erro
            delTransacao(index);

            ids.RemoveAt(index);
            nomes.RemoveAt(index);
            idades.RemoveAt(index);

            //atualiza o contador de pessoas a partir da quantidade de ids na lista
            totalPessoas = ids.Count;

            Console.WriteLine("\n\nPessoa excluída com sucesso!\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void delTransacao(int idExc)
        {
            //percorre a lista ao contrário porque tava dando erro tentando percorrer do começo
            //porque a lista estava sendo alterada durante o loop e não acessava os dados certos
            for (int i = idsTransacoes.Count - 1; i >= 0; i--)
            {
                if (idsPessoaCorrespondente[i] == idExc)
                {
                    if (tipos[i] == "Despesa")
                    {
                        totalGeralDespesas -= valores[i];
                    }

                    else if (tipos[i] == "Receita")
                    {
                        totalGeralReceitas -= valores[i];
                    }

                    descricoes.RemoveAt(i);
                    tipos.RemoveAt(i);
                    valores.RemoveAt(i);
                    idsTransacoes.RemoveAt(i);
                    pessoaCorrespondente.RemoveAt(i);
                    idsPessoaCorrespondente.RemoveAt(i);
                }
            }
            //atualiza o contador de transações a partir da quantidade de ids na lista
            totalTransacoes = idsTransacoes.Count;
        }

        static void menuTransacoes()
        {
            string op;

            //loop que repete até que o usuário digite uma opção válida
            while (true)
            {
                limpaTela();

                Console.WriteLine("\n\t --- Transações --- \n\n");

                Console.WriteLine(" 1 - Cadastrar");
                Console.WriteLine(" 2 - Listar");
                Console.WriteLine("\n 0 - Voltar");

                Console.Write("\n - Opção: ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        limpaTela();
                        cadTransacao();
                        break;

                    case "2":
                        limpaTela();
                        listaTransacao();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("\nOpção inválida!\nPressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void cadTransacao()
        {
            int id;

            Console.WriteLine("\n\t --- Cadastrar Transação --- \n\n");

            //verifica se tem pessoas cadastradas para criar uma transação
            if (totalPessoas <= 0)
            {
                Console.WriteLine("Nenhuma pessoa no sistema para cadastrar uma transação.\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            //mostra as pessoas cadastradas para facilitar a visualização
            for (int i = 0; i < totalPessoas; i++)
            {
                Console.WriteLine("\t\t   ID: " + ids[i]);
                Console.WriteLine("\t\t Nome: " + nomes[i]);
                Console.WriteLine("\t-------------------------------");
            }
            Console.Write("\nDigite o ID da pessoa que deseja cadastrar uma transação: ");
            id = int.Parse(Console.ReadLine());

            //variavel para achar o índice certo a partir do id único da pessoa
            int index = ids.IndexOf(id);

            if (index == -1)
            {
                Console.WriteLine("\nID não encontrado! Pressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            limpaTela();

            Console.WriteLine("\n\t --- Cadastrar Transação --- \n\n");
            Console.WriteLine("\n Pessoa selecionada: " + nomes[index]);

            //copia o nome e id da pessoa para os arrays correspondentes
            pessoaCorrespondente.Add(nomes[index]);
            idsPessoaCorrespondente.Add(ids[index]);

            idsTransacoes.Add(totalTransacoes);

            if (idades[index] >= 18)
            {
                maior18(index);
            }
            else
            {
                menor18(index);
            }
        }

        //deixa a pessoa escolher se vai cadastrar uma receita ou despesa
        static void maior18(int index)
        {
            string tipo;

            Console.WriteLine("\n Tipo da transação:");
            Console.WriteLine("\n  1 - Despesa\n  2 - Receita");
            Console.Write("\n\t - Opção: ");
            tipo = Console.ReadLine();

            Console.Write("\n Valor da transação: ");
            valores.Add(double.Parse(Console.ReadLine()));

            //adiciona os valores às variáveis de totais gerais para serem exibidos na tela de consulta totais
            if (tipo == "1")
            {
                tipos.Add("Despesa");
                totalGeralDespesas += valores[index];
            }
            if (tipo == "2")
            {
                tipos.Add("Receita");
                totalGeralReceitas += valores[index];
            }

            Console.Write("\n Descrição da transação: ");
            descricoes.Add(Console.ReadLine());

            totalTransacoes = idsTransacoes.Count;

            Console.WriteLine("\nTransação cadastrada com sucesso!\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
            limpaTela();
        }

        //cadastra apenas despesas
        static void menor18(int index)
        {
            tipos.Add("Despesa");

            Console.Write("\n Valor da transação: ");
            valores.Add(double.Parse(Console.ReadLine()));

            totalGeralDespesas += valores[index];

            Console.Write("\n Descrição da transação: ");
            descricoes.Add(Console.ReadLine());

            totalTransacoes = idsTransacoes.Count;

            Console.WriteLine("\nTransação cadastrada com sucesso!\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
            limpaTela();
        }

        static void listaTransacao()
        {
            Console.WriteLine("\n\t\t --- Transações Cadastradas --- \n\n");

            //verifica se tem transações cadastradas
            if (totalTransacoes == 0)
            {
                Console.WriteLine("\nNenhuma transação cadastrada!\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < idsTransacoes.Count; i++)
            {
                Console.WriteLine("\t\t   ID da transação: " + idsTransacoes[i]);
                Console.WriteLine("\t\t ID do responsável: " + idsPessoaCorrespondente[i]);
                Console.WriteLine("\t\t       Responsável: " + pessoaCorrespondente[i]);
                Console.WriteLine("\t\t              Tipo: " + tipos[i]);
                Console.WriteLine("\t\t             Valor: R$ " + valores[i]);
                Console.WriteLine("\t\t         Descrição: " + descricoes[i]);
                Console.WriteLine("\t\t-------------------------------");
            }
            Console.WriteLine("\nFim da lista.\nPressione qualquer tecla para voltar...");
            Console.ReadKey();

        }

        static void consultaTotais()
        {
            //verificador de transações
            bool temTransacoes = false;

            //variaveis para calcular os totais parcialmente
            double totalReceitas = 0;
            double totalDespesas = 0;
            int qtdTransacoes = 0;
            int qtdReceitas = 0;
            int qtdDespesas = 0;

            //variáveis que vão calcular os totais gerais a partir dos parciais
            totalGeralReceitas = 0;
            totalGeralDespesas = 0;
            saldoLiquidoTotal = 0;

            //loop externo para percorrer todas as pessoas cadastradas
            for (int i = 0; i < ids.Count; i++)
            {
                //guarda o indice certo na lista já que o id único pode ser diferente da sua posição
                int idPessoa = ids[i];

                //atualiza o verificador sempre que estiver acessando outra pessoa
                temTransacoes = false;

                //loop interno apenas para ver se a pessoa tem transações cadastradas
                for (int j = 0; j < idsPessoaCorrespondente.Count; j++)
                {
                    if (idsPessoaCorrespondente[j] == idPessoa)
                    {
                        temTransacoes = true;
                        break;
                    }
                }

                if (!temTransacoes)
                {
                    continue;
                }

                //as variáveis zeram toda vez que o loop passa por outra pessoa para calcular as parciais de cada uma
                totalReceitas = 0;
                totalDespesas = 0;
                qtdTransacoes = 0;
                qtdReceitas = 0;
                qtdDespesas = 0;

                //outro loop interno, dessa vez para percorrer todas as transações de cada pessoa
                for (int j = 0; j < totalTransacoes; j++)
                {
                    if (idsPessoaCorrespondente[j] == idPessoa)
                    {
                        if (tipos[j] == "Receita")
                        {
                            totalReceitas += valores[j];
                            qtdReceitas++;
                        }
                        else if (tipos[j] == "Despesa")
                        {
                            totalDespesas += valores[j];
                            qtdDespesas++;
                        }
                        qtdTransacoes++;
                    }
                }
                //calcula o saldo líquido de cada pessoa
                double saldoLiquido = totalReceitas - totalDespesas;

                //soma os totais parcias nas variáveis de totais gerais para serem exibidos no final
                totalGeralReceitas += totalReceitas;
                totalGeralDespesas += totalDespesas;
                saldoLiquidoTotal += saldoLiquido;

                //mostra os dados da pessoa atual antes que as variáveis sejam zeradas para calcular os totais de outra pessoa
                Console.WriteLine("             Pessoa: " + nomes[i]);
                Console.WriteLine("                 ID: " + ids[i]);
                Console.WriteLine("         Transações: " + qtdTransacoes);
                Console.WriteLine("           Receitas: " + qtdReceitas);
                Console.WriteLine("           Despesas: " + qtdDespesas);
                Console.WriteLine(" Total das Receitas: R$ " + totalReceitas);
                Console.WriteLine(" Total das Despesas: R$ " + totalDespesas);
                Console.WriteLine("      Saldo Líquido: R$ " + saldoLiquido);
                Console.WriteLine("--------------------------------------------------");
            }

            //totais finais
            Console.WriteLine("\n\n\t --- Total Geral --- \n");
            Console.WriteLine("   Total das receitas: R$ " + totalGeralReceitas);
            Console.WriteLine("   Total das despesas: R$ " + totalGeralDespesas);
            Console.WriteLine("  Saldo líquido total: R$ " + saldoLiquidoTotal);

            Console.WriteLine("\n\nFim da lista. \nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        //não é exatamente necessário mas gosto de fazer isso pro código ficar mais fácil de ler
        static void limpaTela()
        {
            Console.Clear();
        }
    }
}
