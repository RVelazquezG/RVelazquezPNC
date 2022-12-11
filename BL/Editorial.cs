using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {
        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.RVelazquezPNCEntities context = new DL_EF.RVelazquezPNCEntities())
                {
                    var editoriales = context.EditorialGetAll().ToList();

                    result.Objects = new List<object>();

                    if (editoriales != null)
                    {
                        foreach (var objEditorial in editoriales)
                        {
                            ML.Editorial editorial = new ML.Editorial();
                            editorial.IdEditorial = objEditorial.IdEditorial;
                            editorial.Nombre = objEditorial.Nombre;

                            result.Objects.Add(editorial);
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
