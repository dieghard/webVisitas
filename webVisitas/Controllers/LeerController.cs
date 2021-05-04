using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace webVisitas.Controllers
{
    public class LeerController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LeerController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string data;

            try
            {
             
                string path = Path.Combine(webRootPath, "archivo.txt");
                data = System.IO.File.ReadAllText(path, Encoding.UTF8);
            }
            catch (Exception e)
            {
                data = "Exception: " + e.Message;
            }

            // Por las dudas, ajusto el CrLf al de Enironment
            data = data.Replace("\n", Environment.NewLine);
            return View(null, data);
        }
    }
}
