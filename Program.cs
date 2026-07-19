using ClubDeportivoApp.Controllers;

namespace ClubDeportivoApp;

class Program
{
    static void Main(string[] args)
    {
        AppController app = new AppController();
        app.Iniciar();
    }
}
