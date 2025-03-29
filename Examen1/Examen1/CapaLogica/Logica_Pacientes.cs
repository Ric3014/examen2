using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Examen1.CapaDatos;

namespace Examen1.CapaLogica
{
	public class Logica_Pacientes
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
                    string query = "SELECT COUNT(*) FROM Pacientes WHERE Cedula = @Cedula";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Cedula", Cls_Pacientes.Cedula);
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
        public static int Agregar()
        {
            int retorno = 0;
            try
            {
                string s = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "INSERT INTO Pacientes (Cedula, Nombre, PrimerApellido, FechaNacimiento, Edad, Telefono) VALUES ('" + Cls_Pacientes.Cedula + "', '" + Cls_Pacientes.Nombre + "', '" + Cls_Pacientes.PrimerApellido + "', '" + Cls_Pacientes.FechaNacimiento+ "','" + Cls_Pacientes.Edad+ "','" + Cls_Pacientes.Telefono+ "')";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Cedula", Cls_Pacientes.Cedula);
                        comando.Parameters.AddWithValue("@Nombre", Cls_Pacientes.Nombre);
                        comando.Parameters.AddWithValue("@PrimerApellido", Cls_Pacientes.PrimerApellido);
                        comando.Parameters.AddWithValue("@FechaNacimiento", Cls_Pacientes.FechaNacimiento);
                        comando.Parameters.AddWithValue("@Edad", Cls_Pacientes.Edad);
                        comando.Parameters.AddWithValue("@Telefono", Cls_Pacientes.Telefono);

                        retorno = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar paciente: " + ex.Message);
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
                    string query = "DELETE FROM Pacientes WHERE Cedula = @Cedula";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Cedula", Cls_Pacientes.Cedula);
                        retorno = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar paciente: " + ex.Message);
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
                    string query = "UPDATE Pacientes SET Nombre = @Nombre, PrimerApellido = @PrimerApellido, FechaNacimiento = @FechaNacimiento, Edad = @Edad, Telefono = @Telefono WHERE Cedula = @Cedula";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Cedula", Cls_Pacientes.Cedula);
                        comando.Parameters.AddWithValue("@Nombre", Cls_Pacientes.Nombre);
                        comando.Parameters.AddWithValue("@PrimerApellido", Cls_Pacientes.PrimerApellido);
                        comando.Parameters.AddWithValue("@FechaNacimiento", Cls_Pacientes.FechaNacimiento);
                        comando.Parameters.AddWithValue("@Edad", Cls_Pacientes.Edad);
                        comando.Parameters.AddWithValue("@Telefono", Cls_Pacientes.Telefono);

                        retorno = comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar usuario: " + ex.Message);
            }
            return retorno;
        }
    }

}