using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetconnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroAdd";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;

                        collection[1] = new SqlParameter("@NumeroPaginas", System.Data.SqlDbType.Int);
                        collection[1].Value = libro.NumeroPaginas;

                        collection[2] = new SqlParameter("@FechaPublicacion", System.Data.SqlDbType.DateTime);
                        collection[2].Value = libro.FechaPublicacion;

                        collection[3] = new SqlParameter("@Edicion", System.Data.SqlDbType.VarChar);
                        collection[3].Value = libro.Edicion;

                        collection[4] = new SqlParameter("@IdAutor", System.Data.SqlDbType.Int);
                        collection[4].Value = libro.Autor.IdAutor;

                        collection[5] = new SqlParameter("@IdEditorial", System.Data.SqlDbType.Int);
                        collection[5].Value = libro.Editorial.IdEditorial;

                        collection[6] = new SqlParameter("@IdGenero", System.Data.SqlDbType.Int);
                        collection[6].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetconnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroUpdate";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("@IdLibro", System.Data.SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;

                        collection[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = libro.Nombre;

                        collection[2] = new SqlParameter("@NumeroPaginas", System.Data.SqlDbType.Int);
                        collection[2].Value = libro.NumeroPaginas;

                        collection[3] = new SqlParameter("@FechaPublicacion", System.Data.SqlDbType.DateTime);
                        collection[3].Value = libro.FechaPublicacion;

                        collection[4] = new SqlParameter("@Edicion", System.Data.SqlDbType.VarChar);
                        collection[4].Value = libro.Edicion;

                        collection[5] = new SqlParameter("@IdAutor", System.Data.SqlDbType.Int);
                        collection[5].Value = libro.Autor.IdAutor;

                        collection[6] = new SqlParameter("@IdEditorial", System.Data.SqlDbType.Int);
                        collection[6].Value = libro.Editorial.IdEditorial;

                        collection[7] = new SqlParameter("@IdGenero", System.Data.SqlDbType.Int);
                        collection[7].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetconnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroDelete";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdLibro", System.Data.SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetconnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        DataTable tableLibro = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableLibro);

                        if (tableLibro.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableLibro.Rows)
                            {
                                ML.Libro libro = new ML.Libro();
                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Nombre = row[1].ToString();
                                libro.NumeroPaginas = int.Parse(row[2].ToString());
                                libro.FechaPublicacion = row[3].ToString();
                                libro.Edicion = row[4].ToString();

                                libro.Autor = new ML.Autor();
                                libro.Autor.IdAutor = int.Parse(row[5].ToString());
                                libro.Autor.Nombre = row[6].ToString();

                                libro.Editorial = new ML.Editorial();
                                libro.Editorial.IdEditorial = int.Parse(row[7].ToString());
                                libro.Editorial.Nombre = row[8].ToString();

                                libro.Genero = new ML.Genero();
                                libro.Genero.IdGenero = int.Parse(row[9].ToString());
                                libro.Genero.Nombre = row[10].ToString();

                                result.Objects.Add(libro);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetconnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdLibro", System.Data.SqlDbType.Int);
                        collection[0].Value = IdLibro;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableLibro = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableLibro);

                        if (tableLibro.Rows.Count > 0)
                        {

                            DataRow row = tableLibro.Rows[0];

                            ML.Libro libro = new ML.Libro();
                            libro.IdLibro = int.Parse(row[0].ToString());
                            libro.Nombre = row[1].ToString();
                            libro.NumeroPaginas = int.Parse(row[2].ToString());
                            libro.FechaPublicacion = row[3].ToString();
                            libro.Edicion = row[4].ToString();

                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(row[5].ToString());
                            libro.Autor.Nombre = row[6].ToString();

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(row[7].ToString());
                            libro.Editorial.Nombre = row[8].ToString();

                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(row[9].ToString());
                            libro.Genero.Nombre = row[10].ToString();

                            result.Object = libro;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


        public static ML.Result AddEF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RVelazquezPNCEntities context = new DL_EF.RVelazquezPNCEntities())
                {


                    var query = context.LibroAdd(libro.Nombre, libro.NumeroPaginas, libro.FechaPublicacion, libro.Edicion, libro.Autor.IdAutor, libro.Editorial.IdEditorial, libro.Genero.IdGenero);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se registro el libro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static Result UpdateEF(ML.Libro libro)
        {
            Result result = new Result();
            try
            {

                using (DL_EF.RVelazquezPNCEntities context = new DL_EF.RVelazquezPNCEntities())
                {

                    {
                        var updateResult = context.LibroUpdate(libro.IdLibro, libro.Nombre, libro.NumeroPaginas, libro.FechaPublicacion, libro.Edicion, libro.Autor.IdAutor, libro.Editorial.IdEditorial, libro.Genero.IdGenero);
                        if (updateResult >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se actualizó el registro del libro";
                        }
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

        public static Result DeleteEF(int IdLibro)
        {
            Result result = new Result();

            try
            {
                using (DL_EF.RVelazquezPNCEntities context = new DL_EF.RVelazquezPNCEntities())
                {

                    var query = context.LibroDelete(IdLibro);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el libro";

                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.RVelazquezPNCEntities context = new DL_EF.RVelazquezPNCEntities())
                {
                    var libros = context.LibroGetAll().ToList();

                    result.Objects = new List<object>();

                    if (libros != null)
                    {
                        foreach (var objLibro in libros)
                        {
                            ML.Libro libro = new ML.Libro();
                            libro.IdLibro = objLibro.IdLibro;
                            libro.Nombre = objLibro.Nombre;
                            libro.NumeroPaginas = int.Parse(objLibro.NumeroPaginas.ToString());
                            libro.FechaPublicacion = objLibro.FechaPublicacion.ToString("dd-MM-yyyy");
                            libro.Edicion = objLibro.Edicion;

                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = int.Parse(objLibro.IdAutor.ToString());
                            libro.Autor.Nombre = objLibro.NombreAutor;

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.IdEditorial = int.Parse(objLibro.IdEditorial.ToString());
                            libro.Editorial.Nombre = objLibro.NombreEditorial;

                            libro.Genero = new ML.Genero();
                            libro.Genero.IdGenero = int.Parse(objLibro.IdGenero.ToString());
                            libro.Genero.Nombre = objLibro.NombreGenero;

                            result.Objects.Add(libro);
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

        public static ML.Result GetByIdEF(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RVelazquezPNCEntities context = new DL_EF.RVelazquezPNCEntities())
                {

                    var objLibro = context.LibroGetById(IdLibro).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objLibro != null)
                    {

                        ML.Libro libro = new ML.Libro();
                        libro.IdLibro = objLibro.IdLibro;
                        libro.Nombre = objLibro.Nombre;
                        libro.NumeroPaginas = int.Parse(objLibro.NumeroPaginas.ToString());
                        libro.FechaPublicacion = objLibro.FechaPublicacion.ToString("dd-MM-yyyy");
                        libro.Edicion = objLibro.Edicion;

                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = int.Parse(objLibro.IdAutor.ToString());
                        libro.Autor.Nombre = objLibro.NombreAutor;

                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = int.Parse(objLibro.IdEditorial.ToString());
                        libro.Autor.Nombre = objLibro.NombreEditorial;

                        libro.Genero = new ML.Genero();
                        libro.Genero.IdGenero = int.Parse(objLibro.IdGenero.ToString());
                        libro.Genero.Nombre = objLibro.NombreGenero;
                        result.Object = libro;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla libro";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
