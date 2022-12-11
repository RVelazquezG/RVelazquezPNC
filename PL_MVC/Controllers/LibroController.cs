using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LibroController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result result = new ML.Result();

            result = BL.Libro.GetAllEF();

            if (result.Correct)
            {
                libro = new ML.Libro();
                libro.Libros = result.Objects;
                return View(libro);
            }
           
            return View();
        }

        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {

            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();

            ML.Result resultAutor = BL.Autor.GetAll();
            ML.Result resultEditorial = BL.Editorial.GetAll();
            ML.Result resultGenero = BL.Genero.GetAll();


            if (IdLibro == null)
            {
                libro.Autor.Autores = resultAutor.Objects;
                libro.Editorial.Editoriales = resultEditorial.Objects;
                libro.Genero.Generos = resultGenero.Objects;
                return View(libro);
            }
            else
            {
                ML.Result result = BL.Libro.GetByIdEF(IdLibro.Value);
                if (result.Correct)
                {

                    libro = (ML.Libro)result.Object;
                    libro.Autor.Autores = resultAutor.Objects;
                    libro.Editorial.Editoriales = resultEditorial.Objects;
                    libro.Genero.Generos = resultGenero.Objects;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el usuario seleccionado";
                    return PartialView("Modal");
                }

                return View(libro);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
           
            if (libro.IdLibro == 0)
            {
                ML.Result result = BL.Libro.AddEF(libro);
                if (result.Correct)
                {
                    libro = (ML.Libro)result.Object;
                    ViewBag.Message = " El libro ha sido agregado con exito";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al agregar el libro";
                    return PartialView("Modal");
                }

            }
            else
            {
                ML.Result result = BL.Libro.UpdateEF(libro);
                if (result.Correct)
                {
                    libro = (ML.Libro)result.Object;
                    ViewBag.Message = "El libro seleccionado ha sido actualizado con exito";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el libro seleccionado";
                    return PartialView("Modal");
                }
            }

        }

        [HttpGet]
        public ActionResult Delete(int? IdLibro)
        {

            ML.Result result = new ML.Result();


            if (IdLibro == null)
            {
                ViewBag.Message = "Ocurrio un error al eliminar el libro seleccionado";
                return PartialView("Modal");
            }
            else
            {
                result = BL.Libro.DeleteEF(IdLibro.Value);
                ViewBag.Message = "El libro seleccionado ha sido eliminado";

            }
            return PartialView("Modal");
        }


    }
}
