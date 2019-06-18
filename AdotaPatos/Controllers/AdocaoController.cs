using AdotaPatos.DAO;
using AdotaPatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdotaPatos.Controllers
{
    public class AdocaoController : Controller
    {

        AdocaoDAO adocaoDAO = new AdocaoDAO();
        AnimalDAO animalDAO = new AnimalDAO();

        // GET: Adocao
        public ActionResult Index(string nome)
        {
            if (nome != null)
            {
                var pes = adocaoDAO.Search(nome);
                return View(pes);
            }
            var teste = adocaoDAO.Listar();
            return View(teste);
        }


        public ActionResult Create()
        {
            ViewBag.Animal = new SelectList(animalDAO.Listar().OrderBy(b => b.NomeAnimal), "IdAnimal", "NomeAnimal");
            ViewBag.Animal1 = new SelectList(animalDAO.Listar().OrderBy(b => b.Raca), "IdAnimal", "Raca");
            ViewBag.Animal2 = new SelectList(animalDAO.Listar().OrderBy(b => b.TipoAnimal), "IdAnimal", "TipoAnimal");

            return View();
        }


        [HttpPost]
        public ActionResult Create(Adocao adocao)
        {

            if (!ModelState.IsValid)
            {
                return View(adocao);
            }

            adocaoDAO.Salvar(adocao);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Details(long id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }

            var teste = adocaoDAO.PorId(id);
            ViewBag.Data = teste.DataAdocao.ToString("dd/MM/yyyy");
            return View(teste);
        }


        public ActionResult Edit(long id)
        {
            var teste = adocaoDAO.PorId(id);
            ViewBag.Data = teste.DataAdocao.ToString("dd/MM/yyyy");
            return View(teste);
        }


        [HttpPost]
        public ActionResult Edit(Adocao adocao)
        {
            if (!ModelState.IsValid)
            {
                return View(adocao);
            }

            adocaoDAO.Atualizar(adocao);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(long id)
        {
            var teste = adocaoDAO.PorId(id);
            ViewBag.Data = teste.DataAdocao.ToString("dd/MM/yyyy");
            return View(teste);
        }


        [HttpPost]
        public ActionResult Delete(long? id)
        {
            adocaoDAO.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}