using System.Globalization;

namespace ProjBloco_TP3_Item4;

public class GestorArquivo
{
    private const string NomeArquivo = "eventos.csv";

    public void SalvarEvento(Evento evento)
    {
        using StreamWriter writer = new StreamWriter(NomeArquivo, true);

        writer.WriteLine(
            $"{evento.EventoId};{evento.Nome};" +
            $"{evento.DataHoraInicio.ToString("O", CultureInfo.InvariantCulture)};" +
            $"{evento.DataHoraFim.ToString("O", CultureInfo.InvariantCulture)}");
    }

    public List<Evento> LerEventos()
    {
        List<Evento> eventos = new List<Evento>();

        if (!File.Exists(NomeArquivo))
        {
            return eventos;
        }

        using StreamReader reader = new StreamReader(NomeArquivo);

        string? linha;

        while ((linha = reader.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(linha))
            {
                continue;
            }

            string[] partes = linha.Split(';');

            if (partes.Length == 4)
            {
                eventos.Add(new Evento
                {
                    EventoId = int.Parse(partes[0]),
                    Nome = partes[1],
                    DataHoraInicio = DateTime.Parse(
                        partes[2], CultureInfo.InvariantCulture),
                    DataHoraFim = DateTime.Parse(
                        partes[3], CultureInfo.InvariantCulture)
                });
            }
        }

        return eventos;
    }
}