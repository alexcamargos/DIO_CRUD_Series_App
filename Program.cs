using System;

using DIO_CRUD_Series_App.Classes;
using DIO_CRUD_Series_App.Enum;


namespace DIO_CRUD_Series_App
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();

        static void Main(string[] args)
        {
            string userInputResult = UserInputMenu();

            while (userInputResult.ToUpper() != "X")
            {
                switch (userInputResult)
                {
                    case "1":
                        ListarSerieMenu();
                        break;
                    case "2":
                        InserirSerieMenu();
                        break;
                    case "3":
                        AtualizarSerieMenu();
                        break;
                    case "4":
                        ExcluirSerieMenu();
                        break;
                    case "5":
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

            Console.WriteLine("DIO_CRUD_Series_App agradece sua visita!");
            Console.ReadLine();
        }

        private static void ListarSerieMenu()
        {
            ClearsConsoleBuffer();

            Console.WriteLine("Séries cadastradas no sistemas.\n");

            var lista = repositorioSerie.ListarSerie();

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
            Console.WriteLine("Inserir nova série!");

            var newGenero = ShowGenderSelection();

            Console.Write("Digite o Título da Série: ");
            string newTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int newAnoLancamento = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string newDescricao = Console.ReadLine();

            Serie newSerie = new Serie(id: repositorioSerie.RetornarProximoId(),
                                       genero: (Genero)newGenero,
                                       titulo: newTitulo,
                                       anoLancamento: newAnoLancamento,
                                       descricao: newDescricao);

            repositorioSerie.InserirSerie(newSerie);
        }

        // TODO: Implementar a opção de editar apenas um dos campos de informação, mantendo os dados já gravados.
        private static void AtualizarSerieMenu()
        {
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

            repositorioSerie.AtualizarSerie(idSerie, atualizaSerie);
        }

        private static void ExcluirSerieMenu()
        {
            Console.WriteLine("Informe o ID da série que deseja exluir: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorioSerie.ExcluirSerie(idSerie);
        }

        private static void VisualizarSerieMenu()
        {
            
            Console.WriteLine("Informe o ID da série que deseja visualizar: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornarSeriePorId(idSerie);

            Console.WriteLine(serie);

            PressAnyKey();
        }

        private static string UserInputMenu()
        {
            string userInputResult;

            ClearsConsoleBuffer();

            Console.WriteLine("\nDIO_CRUD_Series_App\n");

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
            Console.WriteLine("\n\nPressione qualquer tecla para continuar");
            Console.ReadLine();
        }

        private static void ClearsConsoleBuffer()
        {
            Console.Clear();
        }
    }
}
