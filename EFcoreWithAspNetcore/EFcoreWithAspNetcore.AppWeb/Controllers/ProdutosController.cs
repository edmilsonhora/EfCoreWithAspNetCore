using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFcoreWithAspNetcore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

namespace EFcoreWithAspNetcore.AppWeb.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            var provider = new FileExtensionContentTypeProvider();

            var f = Directory.GetFiles("Imagens")[0];
            var r = System.IO.File.ReadAllBytes(f);
            FileInfo fi = new FileInfo(f);
            
            provider.TryGetContentType(f, out string contentType);

            ProdutoPhoto ph = new ProdutoPhoto();
            ph.Binario = r;
            ph.EhPrincipal = true;
            ph.Extensao = fi.Extension;
            ph.Tamanho = (int) fi.Length;
            ph.NomeDoArquivo = fi.Name;
            ph.Tipo = contentType;

            //Categoria c = new Categoria();
            //c.Descricao = "Brinquedos";

            MyContext mC = new MyContext();
            Produto p = new Produto();
            p.Categoria = mC.Categorias.FirstOrDefault();
            p.EhAtivo = true;
            p.Nome = "Homem Formiga";
            p.Preco = 69.80m;
            p.QtdEmEstoque = 15;
            p.Photos.Add(ph);
           
           
           
            mC.Produtos.Add(p);

            mC.SaveChanges();




            return View(new List<Produto>());
        }

        public IActionResult Edit(int id)
        {
            return View(new Produto());
        }
        [HttpPost]
        public IActionResult Edit(Produto produto, IFormFile files)
        {
            
            var p = produto;

            return View(new Produto());
        }
    }
}