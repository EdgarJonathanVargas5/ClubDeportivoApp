using ClubDeportivoApp.Models;

namespace ClubDeportivoApp.Views;

public class ParticipanteView
{
    public Jugador FormularioNuevoJugador()
    {
        Console.Clear();
        Console.WriteLine("==== REGISTRO DE JUGADOR ====\n");
        int dni = LeerInt("DNI: ");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine() ?? "";
        DateOnly fechaNac = LeerDateOnly("Fecha de nacimiento (MM/DD/YYYY): ");
        Console.Write("Posición de juego: ");
        string posicion = Console.ReadLine() ?? "";

        return new Jugador(dni, nombre, apellido, fechaNac, posicion);
    }

    public Entrenador FormularioNuevoEntrenador()
    {
        Console.Clear();
        Console.WriteLine("==== REGISTRO DE ENTRENADOR ====\n");
        int dni = LeerInt("DNI: ");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine() ?? "";
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine() ?? "";

        return new Entrenador(dni, nombre, apellido, telefono);
    }

    public int PedirDni(string mensaje)
    {
        return LeerInt(mensaje);
    }

    public void ListarParticipantes(List<Participante> participantes)
    {
        Console.Clear();
        Console.WriteLine("===========================================================================");
        Console.WriteLine("                            Participantes                                  ");
        Console.WriteLine("===========================================================================");
        Console.WriteLine("{0,-8} | {1, -20} | {2, -20} | {3, -20}", "DNI", "Apellido", "Nombre", "Rol");
        foreach (var p in participantes)
        {
            Console.WriteLine("{0,-8} | {1, -20} | {2, -20} | {3, -20}", p.Dni, p.Apellido, p.Nombre, p.GetType().Name);
        }
    }

    public void ListarEntrenadores(List<Entrenador> entrenadores)
    {
        Console.Clear();
        Console.WriteLine("=================================================================================");
        Console.WriteLine("                                  Entrenadores                                   ");
        Console.WriteLine("=================================================================================");
         Console.WriteLine("{0,-8} | {1, -20} | {2, -20} | {3, -11}", "DNI", "Apellido", "Nombre", "Telefono");
        foreach (var e in entrenadores)
        {
            Console.WriteLine("{0,-8} | {1, -20} | {2, -20} | {3, -11}", e.Dni, e.Apellido, e.Nombre, e.Telefono);
        }
    }

    private int LeerInt(string mensaje)
    {
        Console.Write(mensaje);
        int.TryParse(Console.ReadLine(), out int valor);
        return valor;
    }

    private DateOnly LeerDateOnly(string mensaje)
    {
        Console.Write(mensaje);
        DateOnly.TryParse(Console.ReadLine(), out DateOnly valor);
        return valor;
    }
}
