using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
       public static void Add()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result result = new  ML.Result();

            Console.WriteLine("Ingresa el nombre del libro");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el numero de paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la fecha de publicacion");
            libro.FechaPublicacion = (Console.ReadLine());

            Console.WriteLine("Ingresa el nombre de la edicion");
            libro.Edicion = Console.ReadLine();

            libro.Autor = new ML.Autor();
            Console.WriteLine("Ingresa el id autor");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            libro.Editorial = new ML.Editorial();
            Console.WriteLine("Ingresa el id de la editorial");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            libro.Genero = new ML.Genero();
            Console.WriteLine("Ingresa el id del genero");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());


            result = BL.Libro.Add(libro);

            if(result.Correct == true)
            {
                Console.WriteLine("");
                Console.WriteLine("El libro fue agregado con exito");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("El libro no se agregó" + result.ErrorMessage);
                Console.ReadKey();

            }
        }

        public static void Update()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result result = new ML.Result();

            Console.WriteLine("Ingresa el id del libro a actualizar");
            libro.IdLibro = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nombre del libro");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el numero de paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la fecha de publicacion");
            libro.FechaPublicacion = (Console.ReadLine());

            Console.WriteLine("Ingresa el nombre de la edicion");
            libro.Edicion = Console.ReadLine();

            libro.Autor = new ML.Autor();
            Console.WriteLine("Ingresa el id autor");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            libro.Editorial= new ML.Editorial();
            Console.WriteLine("Ingresa el id de la editorial");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            libro.Genero = new ML.Genero();
            Console.WriteLine("Ingresa el id del genero");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());


            result = BL.Libro.Update(libro);

            if (result.Correct == true)
            {
                Console.WriteLine("");
                Console.WriteLine("El libro fue actualizado con exito");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("El libro no se actualizó" + result.ErrorMessage);
                Console.ReadKey();

            }
        }

        public static void Delete()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result result = new ML.Result();

            Console.WriteLine("Ingresa el id del libro a eliminar");
            libro.IdLibro = int.Parse(Console.ReadLine());

            result = BL.Libro.Delete(libro);

            if (result.Correct == true)
            {
                Console.WriteLine("");
                Console.WriteLine("El libro fue eliminado con exito");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("El libro no se eliminó" + result.ErrorMessage);
                Console.ReadKey();

            }
        }

        public static void GetAll()
        {
            ML.Result result = BL.Libro.GetAll();

            if (result.Correct)
            {
                foreach (ML.Libro libro in result.Objects)
                {
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("El id del libro es: " + libro.IdLibro);
                    Console.WriteLine("El nombre del libro es: " + libro.Nombre);
                    Console.WriteLine("El numero de paginas es: " + libro.NumeroPaginas);
                    Console.WriteLine("La fecha de publicacion es: " + libro.FechaPublicacion.ToString());
                    Console.WriteLine("La edición es: " + libro.Edicion);

                    Console.WriteLine("El id del autor es: " + libro.Autor.IdAutor);
                    Console.WriteLine("El nombre del autor es: " + libro.Autor.Nombre);

                    Console.WriteLine("El id de la editorial es: " + libro.Editorial.IdEditorial);
                    Console.WriteLine("El nombre de la editorial es: " + libro.Editorial.Nombre);

                    Console.WriteLine("El id del genero es: " + libro.Genero.IdGenero);
                    Console.WriteLine("El nombre del genero es: " + libro.Genero.Nombre);
                    Console.WriteLine("----------------------------------------------------------");
                }
            }
        }

        public static void GetById()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Ingresa el id del libro a consultar: ");
            libro.IdLibro = int.Parse(Console.ReadLine());
            ML.Result result = BL.Libro.GetById(libro.IdLibro);

            if (result.Correct)
            {
                libro = (ML.Libro)result.Object;

                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("El id del libro es: " + libro.IdLibro);
                Console.WriteLine("El nombre del libro es: " + libro.Nombre);
                Console.WriteLine("El numero de paginas es: " + libro.NumeroPaginas);
                Console.WriteLine("La fecha de publicacion es: " + libro.FechaPublicacion.ToString());
                Console.WriteLine("La edición es: " + libro.Edicion);

                Console.WriteLine("El id del autor es: " + libro.Autor.IdAutor);
                Console.WriteLine("El nombre del autor es: " + libro.Autor.Nombre);

                Console.WriteLine("El id de la editorial es: " + libro.Editorial.IdEditorial);
                Console.WriteLine("El nombre de la editorial es: " + libro.Editorial.Nombre);

                Console.WriteLine("El id del genero es: " + libro.Genero.IdGenero);
                Console.WriteLine("El nombre del genero es: " + libro.Genero.Nombre);
                Console.WriteLine("----------------------------------------------------------");

            }
        }
    }
}
