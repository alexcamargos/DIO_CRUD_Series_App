using System;

using DIO_CRUD_Series_App.Classes;
using DIO_CRUD_Series_App.Enum;


namespace DIO_CRUD_Series_App
{
    class Program
    {
        static SerieRepositorio repositorioSeries = new SerieRepositorio();


        static void Main(string[] args)
        {

            // Adicionando novas séries em tempo de execução para facilitar o desenvolvimento e teste do sistema.
            Serie newSerie01 = new Serie(id: repositorioSeries.RetornarProximoId(),
                                         genero: (Genero)12,
                                         titulo: "CSI: Crime Scene Investigation",
                                         anoLancamento: 2000,
                                         descricao: "A série é centrada nas investigações do grupo de cientistas forenses do departamento de criminalística da polícia de Las Vegas, Nevada.");
        
            repositorioSeries.InserirSerie(newSerie01);

            Serie newSerie02 = new Serie(id: repositorioSeries.RetornarProximoId(),
                                         genero: (Genero)3,
                                         titulo: "Dois Homens e Meio",
                                         anoLancamento: 2003,
                                         descricao: "Charlie Harper (Charlie Sheen), é um compositor de jingles, que mora numa bela casa na praia de Malibu, em Los Angeles.");
        
            repositorioSeries.InserirSerie(newSerie02);

            Serie newSerie03 = new Serie(id: repositorioSeries.RetornarProximoId(),
                                         genero: (Genero)3,
                                         titulo: "Big Bang: A Teoria",
                                         anoLancamento: 2007,
                                         descricao: "Leonard Hofstadter (Johnny Galecki) e Sheldon Cooper (Jim Parsons) são dois brilhantes físicos que dividem o mesmo apartamento.");
        
            repositorioSeries.InserirSerie(newSerie03);

            Serie newSerie04 = new Serie(id: repositorioSeries.RetornarProximoId(),
                                         genero: (Genero)15,
                                         titulo: "Lost",
                                         anoLancamento: 2004,
                                         descricao: "Os sobreviventes de um voo que estava milhas fora do curso caem em uma ilha que abriga um sistema de segurança monstruoso, uma série de abrigos subterrâneos e um grupo de sobrevivencialistas violentos escondidos nas sombras.");
        
            repositorioSeries.InserirSerie(newSerie04);
            // Final da lista de séries cadastradas em tempo de execução.

            string userInputResult = UserInputMenu();

            while (userInputResult.ToUpper() != "X")
            {
                // TODO: Teste implementação com ClearsConsoleBuffer e PressAnyKey depois de cada chamada de menu
                /*
                ClearsConsoleBuffer();
                ListarSerieMenu();
                PressAnyKey();
                break;
                */
                switch (userInputResult)
                {
                    case "1":
                        ClearsConsoleBuffer();
                        ListarSerieMenu();
                        break;
                    case "2":
                        ClearsConsoleBuffer();
                        InserirSerieMenu();
                        break;
                    case "3":
                        ClearsConsoleBuffer();
                        AtualizarSerieMenu();
                        break;
                    case "4":
                        ClearsConsoleBuffer();
                        ExcluirSerieMenu();
                        break;
                    case "5":
                        ClearsConsoleBuffer();
                        VisualizarSerieMenu();
                        break;
                    case "C":
                        ClearsConsoleBuffer();
                        break;
                    default:  
                        throw new ArgumentOutOfRangeException();
                }

                userInputResult = UserInputMenu();
            }

            Console.WriteLine("DIO_CRUD_Series_App: Presione qualquer tecla para fechar!");
            Console.ReadLine();
        }

        private static void ListarSerieMenu()
        {
            WriteAppTitle();

            Console.WriteLine("SÉRIES CADASTRADAS NO SISTEMAS.");
            Console.WriteLine("-------------------------------");

            var lista = repositorioSeries.ListarSerie();

            if (lista.Count == 0)
            {
                Console.WriteLine("\n\n\n\nNenhuma série cadastrada. Atualise o sistema!");
                PressAnyKey();
                return;
            }

            foreach (var serie in lista)
            {
                var serieExcluida = serie.Excluido();

                if (!serieExcluida)
                {
                    Console.WriteLine($"#ID {serie.Id()}: {serie.Titulo()}");
                }

            }
            PressAnyKey();
        }

        private static void InserirSerieMenu()
        {
            WriteAppTitle();

            Console.WriteLine("INSERIR NOVA SÉRIE.");
            Console.WriteLine("-------------------");

            var newGenero = ShowGenderSelection();

            Console.Write("Digite o Título da Série: ");
            string newTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int newAnoLancamento = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string newDescricao = Console.ReadLine();

            Serie newSerie = new Serie(id: repositorioSeries.RetornarProximoId(),
                                       genero: (Genero)newGenero,
                                       titulo: newTitulo,
                                       anoLancamento: newAnoLancamento,
                                       descricao: newDescricao);

            repositorioSeries.InserirSerie(newSerie);

            Console.WriteLine("Cadastro efetuado com sucesso.");
            PressAnyKey();
        }

        // TODO: Implementar a opção de editar apenas um dos campos de informação, mantendo os dados já gravados.
        private static void AtualizarSerieMenu()
        {
            WriteAppTitle();
            Console.WriteLine("ATUALIZAR SÉRIE.");
            Console.WriteLine("----------------");

            Console.WriteLine("Informe o ID da série que deseja atualizar: ");
            int idSerie = int.Parse(Console.ReadLine());

            var newGenero = ShowGenderSelection();

            Console.Write("Digite o Título da Série: ");
            string newTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int newAnoLancamento = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string newDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: idSerie,
                                            genero: (Genero)newGenero,
                                            titulo: newTitulo,
                                            anoLancamento: newAnoLancamento,
                                            descricao: newDescricao);

            repositorioSeries.AtualizarSerie(idSerie, atualizaSerie);

            Console.WriteLine($"{newTitulo} foi atualizada com sucesso.");
            PressAnyKey();
        }

        private static void ExcluirSerieMenu()
        {
            WriteAppTitle();
            Console.WriteLine("EXCLUIR SÉRIE.");
            Console.WriteLine("-------------");

            Console.WriteLine("Informe o ID da série que deseja excluir: ");
            int idSerie = int.Parse(Console.ReadLine());

            Console.WriteLine(repositorioSeries.RetornarSeriePorId(idSerie));

            Console.WriteLine("Deseja realmente excluir a serie?");
            Console.WriteLine("S - Sim\nN - Não");
            var confirmaExcluir = Console.ReadLine();

            if (confirmaExcluir.ToUpper() == "S")
            {
                repositorioSeries.ExcluirSerie(idSerie);

                Console.WriteLine("Série excluída com sucesso.");
                PressAnyKey();
            }
            else
            {
                return;
            }
        }

        private static void VisualizarSerieMenu()
        {

            WriteAppTitle();
            Console.WriteLine("VISUALIZAR SÉRIE.");
            Console.WriteLine("-----------------");
            
            Console.WriteLine("Informe o ID da série que deseja visualizar: ");
            int idSerie = int.Parse(Console.ReadLine());

            // var serie = repositorioSeries.RetornarSeriePorId(idSerie);

            Console.WriteLine(repositorioSeries.RetornarSeriePorId(idSerie));

            PressAnyKey();
        }
        
        // TODO: Acrescentar o título do programa em todas as janelas.
        private static void WriteAppTitle()
        {
            Console.WriteLine("\nDIO_CRUD_Series_App\n");
            Console.WriteLine("Copyright 2021 - Alexsander Lopes Camargos.\n");
            Console.WriteLine("Desafio de Projeto: Criando um APP simples de cadastro de séries em .NET.\n\n");
        }
        
        private static string UserInputMenu()
        {
            string userInputResult;

            ClearsConsoleBuffer();
            WriteAppTitle();

            Console.WriteLine("Menu de opções:\n");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            Console.WriteLine();

            userInputResult = Console.ReadLine();

            return userInputResult;
        }

        private static int ShowGenderSelection()
        {
            ClearsConsoleBuffer();
            
            foreach (int i in Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Genero.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genderSelection = int.Parse(Console.ReadLine());

            return genderSelection;
        }

        private static void PressAnyKey()
        {
            Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        private static void ClearsConsoleBuffer()
        {
            Console.Clear();
        }
    }
}