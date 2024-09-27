using System;
using System.Collections.Generic;

public class Cliente
{
    public string Nome { get; set; }
    public string Documento { get; set; }
}

public class Quarto
{
    public int Numero { get; set; }
    public string Tipo { get; set; }
    public bool Disponivel { get; set; } = true;
}

public class Reserva
{
    public Cliente Cliente { get; set; }
    public Quarto Quarto { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime DataSaida { get; set; }
}

public class Hotel
{
    private List<Quarto> Quartos = new List<Quarto>();
    private List<Reserva> Reservas = new List<Reserva>();

    public void AdicionarQuarto(Quarto quarto)
    {
        Quartos.Add(quarto);
    }

    public void RealizarReserva(Cliente cliente, Quarto quarto, DateTime dataEntrada, DateTime dataSaida)
    {
        if (quarto.Disponivel)
        {
            Reservas.Add(new Reserva { Cliente = cliente, Quarto = quarto, DataEntrada = dataEntrada, DataSaida = dataSaida });
            quarto.Disponivel = false;
            Console.WriteLine("Reserva realizada com sucesso!");
        }
        else
        {
            Console.WriteLine("Quarto não disponível.");
        }
    }

    public void ExibirReservas()
    {
        foreach (var reserva in Reservas)
        {
            Console.WriteLine($"Cliente: {reserva.Cliente.Nome}, Quarto: {reserva.Quarto.Numero}, Entrada: {reserva.DataEntrada.ToShortDateString()}, Saída: {reserva.DataSaida.ToShortDateString()}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Hotel hotel = new Hotel();

        // Adicionar quartos
        hotel.AdicionarQuarto(new Quarto { Numero = 101, Tipo = "Simples" });
        hotel.AdicionarQuarto(new Quarto { Numero = 102, Tipo = "Duplo" });

        // Criar cliente
        Cliente cliente = new Cliente { Nome = "João", Documento = "123456789" };

        // Realizar reserva
        hotel.RealizarReserva(cliente, hotel.Quartos[0], DateTime.Now, DateTime.Now.AddDays(2));

        // Exibir reservas
        hotel.ExibirReservas();
    }
}
