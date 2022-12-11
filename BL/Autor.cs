using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.RVelazquezPNCEntities context = new DL_EF.RVelazquezPNCEntities())
                {
                    var autores = context.AutorGetAll().ToList();

                    result.Objects = new List<object>();

                    if (autores != null)
                    {
                        foreach (var objAutor in autores)
                        {
                            ML.Autor autor = new ML.Autor();
                            autor.IdAutor = objAutor.IdAutor;
                            autor.Nombre = objAutor.Nombre;

                            result.Objects.Add(autor);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
    }
}
