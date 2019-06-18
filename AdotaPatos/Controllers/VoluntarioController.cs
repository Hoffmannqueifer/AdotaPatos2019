using AdotaPatos.DAO;
using AdotaPatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdotaPatos.Controllers
{
    public class VoluntarioController : Controller
    {

        VoluntarioDAO voluntarioDAO = new VoluntarioDAO();


        // GET: Voluntario
        public ActionResult Index(string nome)
        {
            if(nome != null)
            {
                var pes = voluntarioDAO.Search(nome);
                return View(pes);
            }
            var teste = voluntarioDAO.Listar();
            return View(teste);

        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Voluntario voluntario)
        {
            if (ModelState.IsValid)
            {   
                voluntarioDAO.Salvar(voluntario);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public ActionResult Details(long id)
        {
            if(id == 0)
            {
                return HttpNotFound();
            }

            var teste = voluntarioDAO.PorId(id);
            return View(teste);
        }


        public ActionResult Edit(long id)
        {
            var teste = voluntarioDAO.PorId(id);
            return View(teste);
        }


        [HttpPost]
        public ActionResult Edit(Voluntario voluntario)
        {
            if (ModelState.IsValid)
            {        
                voluntarioDAO.Atualizar(voluntario);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public ActionResult Delete(long id)
        {
            var teste = voluntarioDAO.PorId(id);
            return View(teste);
        }


        [HttpPost]
        public ActionResult Delete(long? id)
        {
            voluntarioDAO.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}