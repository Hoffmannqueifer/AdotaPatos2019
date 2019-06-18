using AdotaPatos.DAO;
using AdotaPatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdotaPatos.Controllers
{
    public class CastracaoController : Controller
    {
        CastracaoDAO castracaoDAO = new CastracaoDAO();
        // GET: Castracao
        public ActionResult Index(string Nome)
        {
            if (Nome != null)
            {
                var pesquisaNome = castracaoDAO.Search(Nome);
                return View(pesquisaNome);
            }
            var castracaoIndex = castracaoDAO.Listar();
            return View(castracaoIndex);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Castracao castracao)
        {
            if (!ModelState.IsValid)
            {
                return View(castracao);
            }

            castracaoDAO.Salvar(castracao);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(long Id)
        {
            var castracaoEdit = castracaoDAO.PorId(Id);
            return View(castracaoEdit);
        }

        [HttpPost]
        public ActionResult Edit(Castracao castracao)
        {
            if (!ModelState.IsValid)
            {
                return View(castracao);
            }

            castracaoDAO.Atualizar(castracao);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(long Id)
        {
            if (Id == 0)
            {
                return HttpNotFound();
            }

            var CastracaoDetails = castracaoDAO.PorId(Id);
            return View(CastracaoDetails);

        }

        public ActionResult Delete(long Id)
        {
            var deleteCastracao = castracaoDAO.PorId(Id);
            return View(deleteCastracao);
        }

        [HttpPost]
        public ActionResult Delete(long? Id)
        {
            castracaoDAO.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}