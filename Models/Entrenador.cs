namespace ClubDeportivoApp.Models;

public class Entrenador : Participante
{
    public string Telefono { get; set; } = string.Empty;
    public Equipo? EquipoDirigido { get; set; }

    public Entrenador() : base() { }

    public Entrenador(int dni, string nombre, string apellido, string telefono) 
        : base(dni, nombre, apellido)
    {
        Telefono = telefono;
    }
}
