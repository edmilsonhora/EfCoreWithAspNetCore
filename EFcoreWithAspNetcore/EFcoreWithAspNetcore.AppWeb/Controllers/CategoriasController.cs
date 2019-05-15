using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFcoreWithAspNetcore.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EFcoreWithAspNetcore.AppWeb.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            MyContext mC = new MyContext();
            var f = mC.ProdutoPhotos.FirstOrDefault();
            return File(f.Binario, f.Tipo);
        }

        public IActionResult Edit(int id=0)
        {
            return View(new Categoria());
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
           
            var p = categoria;
            return View(new Categoria());
        }
    }
}