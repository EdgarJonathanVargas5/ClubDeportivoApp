namespace ClubDeportivoApp.Models;

public class Equipo
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string ColorIdentificador { get; set; } = string.Empty;

    public int EntrenadorId { get; set; }
    public Entrenador Entrenador { get; set; } = null!;

    public List<Jugador> Jugadores { get; set; } = new List<Jugador>();

    public Equipo() { }

    public Equipo(int codigo, string nombre, string colorIdentificador, Entrenador entrenador)
    {
        Codigo = codigo;
        Nombre = nombre;
        ColorIdentificador = colorIdentificador;
        Entrenador = entrenador;
        EntrenadorId = entrenador.Id;
    }
}

