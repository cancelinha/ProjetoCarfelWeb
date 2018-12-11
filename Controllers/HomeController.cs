using Microsoft.AspNetCore.Mvc;

namespace Senai.CheckPoint.Controllers {
    public class HomeController : Controller {
        public IActionResult Index () {
            return View ();
        }

        public IActionResult Catalogo () {
            return View ();
        }
        public IActionResult Sobre () {
            return View ();
        }
        public IActionResult ProdutosCarfel () {
            return View ();
        }
        public IActionResult FaleConosco () {
            return View ();
        }
        public IActionResult Ajuda () {
            return View ();
        }
        public IActionResult Logout () {
            return View ();

        }
    }
}