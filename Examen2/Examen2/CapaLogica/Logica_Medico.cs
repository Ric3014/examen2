using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Examen1.CapaDatos;

namespace Examen1.CapaLogica
{
	public class Logica_Medico
	{
        public static bool ExisteMedico()
        {
            bool existe = false;
            try
            {
                string s = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Medicos WHERE ID_Medico = @ID_Medico";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Medico",Cls_Medicos.ID_Medico);
                        int count = Convert.ToInt32(comando.ExecuteScalar());
                        existe = (count > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar existencia de Medico: " + ex.Message);
            }
            return existe;
        }
        public static int Agregar()
        {
            int retorno = 0;
            try
            {
                string s = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "INSERT INTO Medicos (ID_Medico, Nombre, Especialidad) VALUES ('" + Cls_Medicos.ID_Medico + "', '" + Cls_Medicos.Nombre + "', '" + Cls_Medicos.Especialidad + "')";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Medico", Cls_Medicos.ID_Medico);
                        comando.Parameters.AddWithValue("@Nombre", Cls_Medicos.Nombre);
                        comando.Parameters.AddWithValue("@Especialidad", Cls_Medicos.Especialidad);
                       

                        retorno = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar Medico: " + ex.Message);
            }
            return retorno;
        }
        public static int Borrar()
        {
            int retorno = 0;
            try
            {
                string s = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "DELETE FROM Medicos WHERE ID_Medico = @ID_Medico";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Medico", Cls_Medicos.ID_Medico);
                        retorno = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Medico: " + ex.Message);
            }
            return retorno;
        }


        public static int Modificar()
        {
            int retorno = 0;
            try
            {
                string s = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "UPDATE Medicos SET ID_Medico = @ID_Medico, Nombre = @Nombre, Especialidad = @Especialidad WHERE ID_Medico = @ID_Medico";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Medico", Cls_Medicos.ID_Medico);
                        comando.Parameters.AddWithValue("@Nombre", Cls_Medicos.Nombre);
                        comando.Parameters.AddWithValue("@Especialidad", Cls_Medicos.Especialidad);

                        retorno = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar medicos: " + ex.Message);
            }
            return retorno;
        }
    }
}