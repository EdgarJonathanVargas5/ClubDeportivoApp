namespace ClubDeportivoApp.Views;

public class MainView
{
    public string MostrarMenuPrincipal()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===================================");
        Console.WriteLine("        CLUB DEPORTIVO APP         ");
        Console.WriteLine("===================================");
        Console.WriteLine("1. Registrar Jugador");
        Console.WriteLine("2. Registrar Entrenador");
        Console.WriteLine("3. Registrar Equipo");
        Console.WriteLine("4. Asociar Jugador a Equipo");
        Console.WriteLine("5. Listar todos los Equipos");
        Console.WriteLine("6. Listar Equipo por código");
        Console.WriteLine("7. Expulsar a Jugador del torneo");
        Console.WriteLine("8. Listar todos los Participantes");
        Console.WriteLine("9. Listar todos los Entrenadores");
        Console.WriteLine("10. Salir");
        Console.WriteLine("===================================");
        Console.ResetColor();
        Console.Write("Seleccione una opción: ");
        return Console.ReadLine() ?? "";
    }

    public void MostrarMensaje(string mensaje)
    {
        Console.WriteLine($"\n{mensaje}");
        PresionarTecla();
    }
    public void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{mensaje}");
        Console.ResetColor();
        PresionarTecla();
    }
    public void MostrarExito(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{mensaje}");
        Console.ResetColor();
        PresionarTecla();
        
    }
    public void MostrarDespedida()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nHasta luego que tenga un bonito dia! \n");
        Console.ResetColor();
        Console.ReadKey();
    }
    private void PresionarTecla()
    {
        Console.WriteLine("\nPresione cualquier tecla para volver al menu...");
        Console.ReadKey();
    }
}
