using System;
using DIO_AppCadastroSeries_DotNet.Classes;

namespace DIO_AppCadastroSeries_DotNet
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            repositorio.Inserir(new Serie(id: repositorio.ProximoId(),genero: (Genero) 1, titulo: "LOTR", descricao: "Melhor de todos", ano: 2000));

            Console.Clear();
            var opcao = "";
            do
            {
                montarMenu();
                Console.Write("Selecione a opção: ");
                opcao = Console.ReadLine().ToUpper();
                Console.Clear();

                switch(opcao)
                {
                    case "1" :
                        listarSeries();
                        break;
                    case "2" :
                        inserirSerie();
                        break;
                    case "3" :
                        atualizarSerie();
                        break;
                    case "4" :
                        excluirSerie();
                        break;
                    case "5" :
                        visualisarSerie();
                        break;
                    case "6" :
                        marcarSerieVisualizada();
                        break;
                    case "7" :
                        listarSerieVisualizada();
                        break;
                    case "8" :
                        listarSerieNaoVisualizada();
                        break;
                    case "X" :
                        Console.WriteLine("Obrigado por usar nossos serviços");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor selecione outra opção\n");
                        break;
                }

            }while(opcao != "X");
            
        }

        private static void listarSerieNaoVisualizada()
        {
            var listaSeries = repositorio.ListarSerieNaoVisualizada();
            Console.WriteLine("=== LISTAGEM DE SÉRIES NÃO VISUALIZADAS ===");
            if (listaSeries.Count == 0)
            {   
                Console.WriteLine(" Sem registros informados");
            }
            else
            {
                listaSeries.ForEach(x => {Console.WriteLine(x.retornaTitulo());});
            }
            Console.WriteLine("===========================================\n");
        }

        private static void listarSerieVisualizada()
        {
            var listaSeries = repositorio.ListarSerieVisualizada();
            Console.WriteLine("=== LISTAGEM DE SÉRIES VISUALIZADAS ===");
            if (listaSeries.Count == 0)
            {   
                Console.WriteLine(" Sem registros informados");
            }
            else
            {
                listaSeries.ForEach(x => {Console.WriteLine(x.retornaTitulo());});
            }
            Console.WriteLine("========================================\n");
        }

        private static void marcarSerieVisualizada()
        {
            Console.Write("\nInforme o código da série: ");
            var codigo = Int32.Parse(Console.ReadLine());
            
            if (repositorio.ValidarSerie(codigo))
            {
                Console.Write( $"Deseja realmente marcar a série {repositorio.RetornarPorId(codigo).retornaTitulo()} como vista?\n[S] Sim [N] Não : ");    
                var opcao = Console.ReadLine().ToUpper();
                if (opcao.Equals("S"))
                {
                    repositorio.MarcarLida(codigo);
                    Console.WriteLine("Registro alterado com sucesso.\n");
                }
                else
                {
                    Console.WriteLine("Operação cancelada\n");
                }
            }
            else
            {
                Console.WriteLine("Não foi encontrado uma série com o código informado\n");
            }
        }

        private static void atualizarSerie()
        {
            var serie = carrregarDadosSerie(false);
            if (!(serie == null))
            {
                repositorio.Atualizar(serie.Id, serie);
                Console.WriteLine("Série atualizada com sucesso!");
            }
        }

        private static void inserirSerie()
        { 
            var serie = carrregarDadosSerie(true);
            if (!(serie == null))
            {
                repositorio.Inserir(serie);
                Console.WriteLine("Série inserida com sucesso!");
            }
        }

        private static void visualisarSerie()
        {
            Console.Write("\nInforme o código da série: ");
            var codigo = Int32.Parse(Console.ReadLine());
             if (repositorio.ValidarSerie(codigo))
            {
                Console.Write( $"{repositorio.RetornarPorId(codigo)}\n\n");    
            }
            else
            {
                Console.WriteLine("Não foi encontrado uma série com o código informado\n");
            }
        }

        private static void excluirSerie()
        {
            Console.Write("\nInforme o código da série: ");
            var codigo = Int32.Parse(Console.ReadLine());
            
            if (repositorio.ValidarSerie(codigo))
            {
                Console.Write( $"Deseja realmente excluir a série {repositorio.RetornarPorId(codigo).retornaTitulo()}?\n[S] Sim [N] Não : ");    
                var opcao = Console.ReadLine().ToUpper();
                if (opcao.Equals("S"))
                {
                    repositorio.Excluir(codigo);
                    Console.WriteLine("Registro excluído com sucesso.\n");
                }
                else
                {
                    Console.WriteLine("Operação cancelada\n");
                }
            }
            else
            {
                Console.WriteLine("Não foi encontrado uma série com o código informado\n");
            }
            
        }

        private static void listarSeries()
        {
            var listaSeries = repositorio.Listar();
            Console.WriteLine("=== LISTAGEM DE SÉRIES ===");
            if (listaSeries.Count == 0)
            {   
                Console.WriteLine(" Sem registros informados");
            }
            else
            {
                listaSeries.ForEach(x => {Console.WriteLine(x.retornaTitulo());});
            }
            Console.WriteLine("===========================\n");

        }

        static Serie carrregarDadosSerie(bool inserindo)
        {
            int codigo = -1;
            if (inserindo)
            {
                Console.WriteLine("=== CADASTRAR SÉRIE ===");
                codigo = repositorio.ProximoId();
            }
            else
            {
                Console.WriteLine("=== ALTERAR SÉRIE ===");
                Console.Write("Informe o código da série: ");
                codigo = Int32.Parse(Console.ReadLine());             

                if (!repositorio.ValidarSerie(codigo))
                {
                    Console.WriteLine("Não foi encontrado uma série com o código informado\n");
                    return null;
                }
            }

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
            }
            Console.Write("Selecione o gênero da serie: ");
            int genero = Int16.Parse(Console.ReadLine());

            Console.Write("Informe o título: ");
            string titulo = Console.ReadLine();

            Console.Write("Informe a descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Informe o ano: ");
            int ano = Int16.Parse(Console.ReadLine());

    
            return new Serie(id: codigo, genero: (Genero) genero,
                        titulo: titulo,
                        descricao: descricao,
                        ano : ano);

        }

        static void montarMenu()
        {
            Console.WriteLine("=========== Cadastro de Séries ===========");
            Console.WriteLine(" 1 - Listar Séries");
            Console.WriteLine(" 2 - Inserir nova série");
            Console.WriteLine(" 3 - Atualizar série");
            Console.WriteLine(" 4 - Excluir série");
            Console.WriteLine(" 5 - Visualizar série");
            Console.WriteLine(" 6 - Marcar série como visualizada");
            Console.WriteLine(" 7 - Listar séries visualizadas");
            Console.WriteLine(" 8 - Listar séries não visualizadas");
            Console.WriteLine(" X - Sair");
        }
    }
}
