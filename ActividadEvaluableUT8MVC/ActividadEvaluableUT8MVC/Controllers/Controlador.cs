using Microsoft.AspNetCore.Mvc;

namespace ActividadEvaluableUT8MVC.Controllers
{
    public class Controlador : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome()
        {
            return "Este es el método de bienvenida";
        }
    }
}
