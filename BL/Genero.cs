using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Genero
    {
        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.RVelazquezPNCEntities context = new DL_EF.RVelazquezPNCEntities())
                {
                    var generos = context.GeneroGetAll().ToList();

                    result.Objects = new List<object>();

                    if (generos != null)
                    {
                        foreach (var objGenero in generos)
                        {
                            ML.Genero genero = new ML.Genero();
                            genero.IdGenero  = objGenero.IdGenero;
                            genero.Nombre = objGenero.Nombre;

                            result.Objects.Add(genero);
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
