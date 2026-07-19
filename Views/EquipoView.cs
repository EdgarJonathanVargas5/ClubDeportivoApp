using ClubDeportivoApp.Models;

namespace ClubDeportivoApp.Views;

public class EquipoView
{
    public (int codigo, string nombre, string color, int dniEntrenador) FormularioNuevoEquipo()
    {
        Console.Clear();
        Console.WriteLine("==== REGISTRO DE EQUIPO ====");
        Console.Write("Código: ");
        int.TryParse(Console.ReadLine(), out int codigo);
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Color identificador: ");
        string color = Console.ReadLine() ?? "";
        Console.Write("DNI del entrenador: ");
        int.TryParse(Console.ReadLine(), out int dniEntrenador);

        return (codigo, nombre, color, dniEntrenador);
    }

    public (int dniJugador, int codigoEquipo) FormularioAsociacion()
    {
        Console.Clear();
        Console.WriteLine("==== ASOCIAR JUGADOR A EQUIPO ====");
        Console.Write("DNI del jugador: ");
        int.TryParse(Console.ReadLine(), out int dniJugador);
        Console.Write("Código del equipo: ");
        int.TryParse(Console.ReadLine(), out int codigoEquipo);

        return (dniJugador, codigoEquipo);
    }

    public int PedirCodigoEquipo()
    {
        Console.Write("Código del equipo: ");
        int.TryParse(Console.ReadLine(), out int codigo);
        return codigo;
    }

    public void ListarEquipos(List<Equipo> equipos)
    {
        Console.Clear();
        Console.WriteLine("==================================================================================");
        Console.WriteLine("                                     Equipos                                      ");
        Console.WriteLine("==================================================================================");
        Console.WriteLine("{0,-8} | {1, -15} | {2, -15} | {3, -15}", "Codigo", "Nombre", "Color", "Entrenador");
        foreach (var e in equipos)
        {
            string prof = e.Entrenador != null ? $"{e.Entrenador.Nombre} {e.Entrenador.Apellido}" : "Sin asignar";
            Console.WriteLine("{0,-8} | {1, -15} | {2, -15} | {3, -15}", e.Codigo, e.Nombre, e.ColorIdentificador, prof);
        }
    }

    public void MostrarDetalleEquipo(Equipo equipo)
    {
        Console.Clear();
        Console.WriteLine($"Equipo : {equipo.Nombre} | Entrenador: {equipo.Entrenador.Nombre} {equipo.Entrenador.Apellido}");
        var jugadores = equipo.Jugadores.OrderBy(j => j.Apellido).ToList();
        Console.WriteLine("===========================================================================================================================");
        Console.WriteLine("                                                       Jugadores                                                           ");
        Console.WriteLine("===========================================================================================================================");
        Console.WriteLine("{0,-8} | {1, -20} | {2, -20} | {3, -20} | {4, -15}", "DNI", "Apellido", "Nombre", "Posicion de juego", "Fecha de nacimiento");
        foreach (var j in jugadores)
        {
            Console.WriteLine("{0,-8} | {1, -20} | {2, -20} | {3, -20} | {4, -15}", j.Dni, j.Apellido, j.Nombre, j.PosicionDeJuego, j.FechaNacimiento);
        }
    }
}
