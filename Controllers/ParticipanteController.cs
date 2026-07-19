using ClubDeportivoApp.Data;
using ClubDeportivoApp.Models;
using ClubDeportivoApp.Views;

namespace ClubDeportivoApp.Controllers;

public class ParticipanteController
{
    private readonly ParticipanteView _view;
    private readonly MainView _mainView;

    public ParticipanteController(ParticipanteView view, MainView mainView)
    {
        _view = view;
        _mainView = mainView;
    }

    public void RegistrarJugador()
    {
        Jugador nuevoJugador = _view.FormularioNuevoJugador();

        if (nuevoJugador.Dni <= 0 || string.IsNullOrWhiteSpace(nuevoJugador.Nombre))
        {
            _mainView.MostrarError("Error: Datos del jugador inválidos.");
            return;
        }

        using (var db = new ClubDbContext())
        {
            if (db.Participantes.Any(p => p.Dni == nuevoJugador.Dni))
            {
                _mainView.MostrarError("Error: Ya existe un participante con ese DNI.");
                return;
            }
            db.Jugadores.Add(nuevoJugador);
            db.SaveChanges();
        }
        _mainView.MostrarExito("Jugador registrado con éxito.");
    }

    public void RegistrarEntrenador()
    {
        Entrenador nuevoEntrenador = _view.FormularioNuevoEntrenador();

        using (var db = new ClubDbContext())
        {
            if (db.Participantes.Any(p => p.Dni == nuevoEntrenador.Dni))
            {
                _mainView.MostrarError("Error: Ya existe un participante con ese DNI.");
                return;
            }
            db.Entrenadores.Add(nuevoEntrenador);
            db.SaveChanges();
        }
        _mainView.MostrarExito("Entrenador registrado con éxito.");
    }

    public void ExpulsarJugador()
    {
        int dni = _view.PedirDni("Ingresar el DNI del jugador a expulsar: ");

        using (var db = new ClubDbContext())
        {
            var jugador = db.Jugadores.FirstOrDefault(j => j.Dni == dni);
            if (jugador == null)
            {
                _mainView.MostrarError("Error: No se encontró al jugador.");
                return;
            }
            db.Jugadores.Remove(jugador);
            db.SaveChanges();
        }
        _mainView.MostrarExito("Jugador expulsado y removido de su equipo con éxito.");
    }

    public void ListarTodosLosParticipantes()
    {
        using (var db = new ClubDbContext())
        {
            if (!db.Participantes.Any())
            {
                _mainView.MostrarError("No se registraron participantes en el sistema.");
                return;
            }
            var lista = db.Participantes.OrderBy(p => p.Apellido).ToList();
            _view.ListarParticipantes(lista);
        }
        _mainView.MostrarMensaje("Fin de la lista.");
    }

    public void ListarTodosLosEntrenadores()
    {
        using (var db = new ClubDbContext())
        {
            if (!db.Entrenadores.Any())
            {
                _mainView.MostrarError("No se registraron entrenadores en el sistema.");
                return;
            }
            var lista = db.Entrenadores.OrderBy(e => e.Apellido).ToList();
            _view.ListarEntrenadores(lista);
        }
        _mainView.MostrarMensaje("Fin de la lista.");
    }
}
