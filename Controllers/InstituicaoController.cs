using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class InstituicaoController : Controller
    {

        private static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao(){
                InstituicaoID = 1,
                Nome = "IFCE",
                Endereco = "Ceará"
            },

            new Instituicao(){
                InstituicaoID = 2,
                Nome = "UFC",
                Endereco = "Ceará"
            },

            new Instituicao(){
                InstituicaoID = 3,
                Nome = "UECE",
                Endereco = "Ceará"
            }
        };

        public IActionResult Index()
        {
            return View(instituicoes);
        }

        //Get: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instituicao instituicao)
        {
            instituicao.InstituicaoID = instituicoes.Select(i => i.InstituicaoID).Max() + 1;
            instituicoes.Add(instituicao);

            return RedirectToAction("Index");
        }

        //Get: Edit
        public ActionResult Edit(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao)
        {
            instituicoes[instituicoes.IndexOf(instituicoes.
                Where(i => i.InstituicaoID == instituicao.InstituicaoID).First())] = instituicao;

            return RedirectToAction("Index");
        }

        //Get: Details
        public ActionResult Details(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        //Get: Delete
        public ActionResult Delete(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.
                Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());

            return RedirectToAction("Index");
        }
    }
}
