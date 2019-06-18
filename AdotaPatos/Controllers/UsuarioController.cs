using AdotaPatos.DAO;
using AdotaPatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdotaPatos.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioDAO usuarioDAO = new UsuarioDAO();


        // GET: Usuario
        public ActionResult Index(string nome)
        {
            if (nome != null)
            {
                var pesquisaUser = usuarioDAO.Search(nome);
                return View(pesquisaUser);
            }
            var teste = usuarioDAO.Listar();
            return View(teste);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            usuarioDAO.Salvar(usuario);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Details(long id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }

            var teste = usuarioDAO.PorId(id);
            return View(teste);
        }


        public ActionResult Edit(long id)
        {
            var teste = usuarioDAO.PorId(id);
            return View(teste);
        }


        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            usuarioDAO.Atualizar(usuario);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(long id)
        {
            var teste = usuarioDAO.PorId(id);
            return View(teste);
        }


        [HttpPost]
        public ActionResult Delete(long? id)
        {
            usuarioDAO.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}