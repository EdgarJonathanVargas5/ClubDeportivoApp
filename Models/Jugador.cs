namespace ClubDeportivoApp.Models;

public class Jugador : Participante
{
    public DateOnly FechaNacimiento { get; set; }
    public string PosicionDeJuego { get; set; } = string.Empty;

    public int? EquipoId { get; set; }
    public Equipo? Equipo { get; set; }

    public Jugador() : base() { }

    public Jugador(int dni, string nombre, string apellido, DateOnly fechaNacimiento, string posicionDeJuego)
        : base(dni, nombre, apellido)
    {
        FechaNacimiento = fechaNacimiento;
        PosicionDeJuego = posicionDeJuego;
    }
}
