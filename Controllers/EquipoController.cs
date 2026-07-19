using Microsoft.EntityFrameworkCore;
using ClubDeportivoApp.Data;
using ClubDeportivoApp.Models;
using ClubDeportivoApp.Views;

namespace ClubDeportivoApp.Controllers;

public class EquipoController
{
    private readonly EquipoView _view;
    private readonly MainView _mainView;

    public EquipoController(EquipoView view, MainView mainView)
    {
        _view = view;
        _mainView = mainView;
    }

    public void RegistrarEquipo()
    {
        var datos = _view.FormularioNuevoEquipo();

        using (var db = new ClubDbContext())
        {
            if (db.Equipos.Any(e => e.Codigo == datos.codigo))
            {
                _mainView.MostrarError("Error: Ya existe un equipo con ese código.");
                return;
            }

            var entrenador = db.Entrenadores.FirstOrDefault(e => e.Dni == datos.dniEntrenador);
            if (entrenador == null)
            {
                _mainView.MostrarError("Error: El entrenador no existe.");
                return;
            }

            if (db.Equipos.Any(e => e.EntrenadorId == entrenador.Id))
            {
                _mainView.MostrarError("Error: El entrenador ya dirige otro equipo.");
                return;
            }

            Equipo nuevoEquipo = new Equipo(datos.codigo, datos.nombre, datos.color, entrenador);
            db.Equipos.Add(nuevoEquipo);
            db.SaveChanges();
        }
        _mainView.MostrarExito("Equipo registrado con éxito.");
    }

    public void AsociarJugador()
    {
        var datos = _view.FormularioAsociacion();

        using (var db = new ClubDbContext())
        {
            var jugador = db.Jugadores.FirstOrDefault(j => j.Dni == datos.dniJugador);
            var equipo = db.Equipos.FirstOrDefault(e => e.Codigo == datos.codigoEquipo);

            if (jugador == null || equipo == null)
            {
                _mainView.MostrarError("Error: Jugador o Equipo no encontrados.");
                return;
            }

            if (jugador.EquipoId != null)
            {
                _mainView.MostrarError("Error: El jugador ya pertenece a un equipo.");
                return;
            }

            jugador.EquipoId = equipo.Id;
            db.SaveChanges();
        }
        _mainView.MostrarExito("Jugador asociado con éxito.");
    }

    public void ListarTodosLosEquipos()
    {
        using (var db = new ClubDbContext())
        {
            if (!db.Equipos.Any())
            {
                _mainView.MostrarError("No se registraron equipos en el sistema.");
                return;
            }
            var equipos = db.Equipos.Include(e => e.Entrenador).ToList();
            _view.ListarEquipos(equipos);
        }
        _mainView.MostrarMensaje("Fin de la lista.");
    }

    public void ListarEquipoPorCodigo()
    {
        int codigo = _view.PedirCodigoEquipo();

        using (var db = new ClubDbContext())
        {
            var equipo = db.Equipos
                .Include(e => e.Entrenador)
                .Include(e => e.Jugadores)
                .FirstOrDefault(e => e.Codigo == codigo);

            if (equipo == null)
            {
                _mainView.MostrarError("Error: Equipo no encontrado.");
                return;
            }
            _view.MostrarDetalleEquipo(equipo);
        }
        _mainView.MostrarMensaje("");
    }
}
