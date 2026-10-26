using System.Globalization;

namespace ProjBloco_TP3_Item4;

public class Program
{
    public static void Main(string[] args)
    {
        GestorArquivo gestor = new GestorArquivo();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== Events Digital Wallet ===");
            Console.WriteLine("1 - Cadastrar evento");
            Console.WriteLine("2 - Listar eventos");
            Console.WriteLine("3 - Sair");
            Console.Write("\nEscolha uma opção: ");

            string? opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("=== CADASTRAR EVENTO ===");

                    Console.Write("ID do evento: ");
                    int eventoId = int.Parse(Console.ReadLine()!);

                    Console.Write("Nome do evento: ");
                    string nome = Console.ReadLine()!;

                    Console.Write("Data e hora de início (dd/MM/yyyy HH:mm): ");
                    DateTime dataHoraInicio = DateTime.ParseExact(
                        Console.ReadLine()!,
                        "dd/MM/yyyy HH:mm",
                        CultureInfo.GetCultureInfo("pt-BR"));

                    Console.Write("Data e hora de fim (dd/MM/yyyy HH:mm): ");
                    DateTime dataHoraFim = DateTime.ParseExact(
                        Console.ReadLine()!,
                        "dd/MM/yyyy HH:mm",
                        CultureInfo.GetCultureInfo("pt-BR"));

                    Evento novoEvento = new Evento
                    {
                        EventoId = eventoId,
                        Nome = nome,
                        DataHoraInicio = dataHoraInicio,
                        DataHoraFim = dataHoraFim
                    };

                    gestor.SalvarEvento(novoEvento);

                    Console.WriteLine("\nEvento cadastrado com sucesso!");
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("=== EVENTOS CADASTRADOS ===\n");

                    List<Evento> eventos = gestor.LerEventos();

                    if (eventos.Count == 0)
                    {
                        Console.WriteLine("Nenhum evento cadastrado.");
                    }
                    else
                    {
                        foreach (Evento evento in eventos)
                        {
                            Console.WriteLine($"ID: {evento.EventoId}");
                            Console.WriteLine($"Nome: {evento.Nome}");
                            Console.WriteLine(
                                $"Início: {evento.DataHoraInicio:dd/MM/yyyy HH:mm}");
                            Console.WriteLine(
                                $"Fim: {evento.DataHoraFim:dd/MM/yyyy HH:mm}");
                            Console.WriteLine();
                        }
                    }

                    break;

                case "3":
                    executando = false;
                    Console.WriteLine("\nEncerrando programa...");
                    break;

                default:
                    Console.WriteLine("\nOpção inválida!");
                    break;
            }

            if (executando)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}