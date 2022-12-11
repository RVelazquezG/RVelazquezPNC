using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {
            int Opcion1;

                Console.WriteLine("\n******Seleccione la operacion que desea realizar******\n");
                Console.WriteLine("1.-Agregar un nuevo libro \n2.-Actualizar registro de libro \n3.-Eliminar registro de libro \n4.-Consultar todos los registros de libros \n5.-Consultar los registros de un libro\n");
                Console.WriteLine("******************************************************\n");
                Opcion1 = Convert.ToInt32(System.Console.ReadLine());
                Console.WriteLine("******************************************************\n");

                switch (Opcion1)
                {
                    case 1:
                        PL.Libro.Add();
                        break;

                    case 2:
                        PL.Libro.Update();
                        break;

                    case 3:

                        PL.Libro.Delete();
                        break;

                    case 4:
                        PL.Libro.GetAll();
                        Console.ReadKey();
                        break;

                    case 5:
                        PL.Libro.GetById();
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("La opcion solicitada no es correcta, intente de nuevo.");
                        break;
                }
            
        }
    }
}
