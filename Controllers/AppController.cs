using ClubDeportivoApp.Views;

namespace ClubDeportivoApp.Controllers;

public class AppController
{
    private readonly MainView _mainView;
    private readonly ParticipanteController _participanteController;
    private readonly EquipoController _equipoController;

    public AppController()
    {
        _mainView = new MainView();
        
        var participanteView = new ParticipanteView();
        var equipoView = new EquipoView();

        _participanteController = new ParticipanteController(participanteView, _mainView);
        _equipoController = new EquipoController(equipoView, _mainView);
    }

    public void Iniciar()
    {
        bool salir = false;
        while (!salir)
        {
            string opcion = _mainView.MostrarMenuPrincipal();

            switch (opcion)
            {
                case "1": 
                    _participanteController.RegistrarJugador(); 
                    break;
                case "2": 
                    _participanteController.RegistrarEntrenador(); 
                    break;
                case "3":       
                    _equipoController.RegistrarEquipo(); 
                    break;
                case "4": 
                    _equipoController.AsociarJugador(); 
                    break;
                case "5": 
                    _equipoController.ListarTodosLosEquipos(); 
                    break;
                case "6": 
                    _equipoController.ListarEquipoPorCodigo(); 
                    break;
                case "7": 
                    _participanteController.ExpulsarJugador(); 
                    break;
                case "8": 
                    _participanteController.ListarTodosLosParticipantes(); 
                    break;
                case "9": 
                    _participanteController.ListarTodosLosEntrenadores(); 
                    break;
                case "10":
                    salir = true;
                    _mainView.MostrarDespedida();
                    break;
                default:
                    _mainView.MostrarMensaje("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
    }
}