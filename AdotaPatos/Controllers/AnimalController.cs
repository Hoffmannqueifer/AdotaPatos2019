using AdotaPatos.DAO;
using AdotaPatos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdotaPatos.Controllers
{
    public class AnimalController : Controller
    {
        AnimalDAO animalDAO = new AnimalDAO();
        // GET: Animal
        public ActionResult Index(string nome)
        {
            if (nome != null)
            {
                var pes = animalDAO.Search(nome);
                return View(pes);
            }
            var AnimalIndex = animalDAO.Listar();
            return View(AnimalIndex);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Animal animal, HttpPostedFileBase file, HttpPostedFileBase file2)
        {


            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                animal.ImagemAntes = fileName;
                string pic = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/ImagensAdotaPatos"), pic);
                // file is uploaded
                file.SaveAs(path);

                byte[] data;
                using (Stream inputStream = file.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                }
                string strBase64 = Convert.ToBase64String(data);
                var imgSrc = $"data:images/png;base64, { strBase64}";
            }

            if (file2 != null)
            {
                var fileName = Path.GetFileName(file2.FileName);
                animal.ImagemDepois = fileName;
                string pic = Path.GetFileName(file2.FileName);
                string path = Path.Combine(Server.MapPath("~/ImagensAdotaPatos"), pic);
                // file is uploaded
                file2.SaveAs(path);

                byte[] data;
                using (Stream inputStream = file2.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                }
                string strBase64 = Convert.ToBase64String(data);
                var imgSrc = $"data:images/png;base64, { strBase64}";
            }

            if (ModelState.IsValid)
            {

                if (animal.ImagemAntes == null & animal.ImagemDepois != null)
                {

                    animal.ImagemAntes = "EmojisCachorros.jpg";
                    animalDAO.Salvar(animal);
                    return RedirectToAction(nameof(Index));
                }

                if (animal.ImagemDepois == null & animal.ImagemAntes != null)
                {

                    animal.ImagemDepois = "EmojisCachorros.jpg";
                    animalDAO.Salvar(animal);
                    return RedirectToAction(nameof(Index));
                }

                if (animal.ImagemDepois == null & animal.ImagemDepois == null)
                {
                    animal.ImagemAntes = "EmojisCachorros.jpg";
                    animal.ImagemDepois = "EmojisCachorros.jpg";
                    animalDAO.Salvar(animal);
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    animalDAO.Salvar(animal);
                    return RedirectToAction(nameof(Index));
                }

            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            var AnimalEdit = animalDAO.PorId(id);
            return View(AnimalEdit);
        }
        [HttpPost]
        public ActionResult Edit(Animal animal, HttpPostedFileBase file, HttpPostedFileBase file2)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                animal.ImagemAntes = fileName;
                string pic = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/ImagensAdotaPatos"), pic);
                file.SaveAs(path);
            }

            if (file2 != null)
            {
                var fileName = Path.GetFileName(file2.FileName);
                animal.ImagemDepois = fileName;
                string pic = Path.GetFileName(file2.FileName);
                string path = Path.Combine(Server.MapPath("~/ImagensAdotaPatos"), pic);
                file2.SaveAs(path);
            }

            if (ModelState.IsValid)
            {



                if (animal.ImagemAntes == null & animal.ImagemDepois != null)
                {

                    animal.ImagemAntes = "EmojisCachorros.jpg";
                    animalDAO.Atualizar(animal);
                    return RedirectToAction(nameof(Index));
                }

                if (animal.ImagemDepois == null & animal.ImagemAntes != null)
                {

                    animal.ImagemDepois = "EmojisCachorros.jpg";
                    animalDAO.Atualizar(animal);
                    return RedirectToAction(nameof(Index));
                }

                if (animal.ImagemDepois == null & animal.ImagemAntes == null)
                {

                    animal.ImagemAntes = "EmojisCachorros.jpg";
                    animal.ImagemDepois = "EmojisCachorros.jpg";
                    animalDAO.Atualizar(animal);
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    animalDAO.Atualizar(animal);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        public ActionResult Details(int id)
        {

            if (id == 0)
            {
                return HttpNotFound();
            }

            var AnimalDetails = animalDAO.PorId(id);
            return View(AnimalDetails);
        }
        public ActionResult Delete(int id)
        {
            animalDAO.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}