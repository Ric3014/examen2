using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Examen1.CapaDatos;

namespace Examen1.CapaLogica
{
	public class Logica_Consulta
    {
        public static bool ExisteUsuario()
        {
            bool existe = false;
            try
            {
                string s = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Consultas WHERE Cedula = @Cedula";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Cedula", Cls_Consultas.Cedula);
                        int count = Convert.ToInt32(comando.ExecuteScalar());
                        existe = (count > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar existencia de paciente: " + ex.Message);
            }
            return existe;
        }
        public static bool ExisteMedico()
        {
            bool existe = false;
            try
            {
                string s = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Consultas WHERE ID_Medico = @ID_Medico";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Medico", Cls_Consultas.ID_Medico);
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
                    string query = "INSERT INTO Consultas (ID_Consulta, Cedula, ID_Medico, FechaAtencion, HoraAtencion, Consultorio) VALUES ('" + Cls_Consultas.ID_Consulta + "', '" + Cls_Consultas.Cedula + "', '" + Cls_Consultas.ID_Medico + "', '" + Cls_Consultas.FechaAtencion + "','" + Cls_Consultas.HoraAtencion + "','" + Cls_Consultas.Consultorio + "')";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Consulta", Cls_Consultas.ID_Consulta );
                        comando.Parameters.AddWithValue("@Cedula", Cls_Consultas.Cedula);
                        comando.Parameters.AddWithValue("@ID_Medico", Cls_Consultas.ID_Medico);
                        comando.Parameters.AddWithValue("@FechaAtencion", Cls_Consultas.FechaAtencion);
                        comando.Parameters.AddWithValue("@HoraAtencion", Cls_Consultas.HoraAtencion);
                        comando.Parameters.AddWithValue("@Consultorio", Cls_Consultas.Consultorio);

                        retorno = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar Consulta: " + ex.Message);
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
                    string query = "DELETE FROM Consultas WHERE ID_Consulta = @ID_Consulta";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Consulta", Cls_Consultas.ID_Consulta);
                        retorno = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Consulta: " + ex.Message);
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
                    string query = "UPDATE Consultas SET Cedula = @Cedula, ID_Medico = @ID_Medico, FechaAtencion = @FechaAtencion, HoraAtencion = @HoraAtencion, Consultorio = @Consultorio WHERE ID_Consulta = @ID_Consulta";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Consulta", Cls_Consultas.ID_Consulta);
                        comando.Parameters.AddWithValue("@Cedula", Cls_Consultas.Cedula);
                        comando.Parameters.AddWithValue("@ID_Medico", Cls_Consultas.ID_Medico);
                        comando.Parameters.AddWithValue("@FechaAtencion", Cls_Consultas.FechaAtencion);
                        comando.Parameters.AddWithValue("@HoraAtencion", Cls_Consultas.HoraAtencion);
                        comando.Parameters.AddWithValue("@Consultorio", Cls_Consultas.Consultorio);

                        retorno = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar Consulta: " + ex.Message);
            }
            return retorno;
        }
    }
}