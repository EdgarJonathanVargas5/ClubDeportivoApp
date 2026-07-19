namespace ClubDeportivoApp.Models;

public abstract class Participante : IParticipante
{
    public int Id { get; set; }
    public int Dni { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;

    public Participante() { }

    public Participante(int dni, string nombre, string apellido)
    {
        Dni = dni;
        Nombre = nombre;
        Apellido = apellido;
    }
}


