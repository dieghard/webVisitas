using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace webVisitas.Controllers
{
    public class AgregarVisitaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AgregarVisitaController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {

            string webRootPath = _webHostEnvironment.WebRootPath;

            try
            {

                string autor_observaciones = HttpContext.Request.Form["FirstName"] + "\nComentario: " + HttpContext.Request.Form["observaciones"];
                string lineaSeparadora = "\n_____________________________________________________________________________________________________________\n";
                string fecha = System.DateTime.Now.ToString("yyyyMMdd");
                string hora = System.DateTime.Now.ToString("HH:mm:ss");

                System.IO.StreamWriter archivo = new StreamWriter(Path.Combine(webRootPath, "archivo.txt") , true);
                archivo.WriteLine("\nFecha: " + fecha + "\nHora: " + hora + "\nAutor: " + autor_observaciones + lineaSeparadora);
                archivo.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return View();
        }

    }
}
