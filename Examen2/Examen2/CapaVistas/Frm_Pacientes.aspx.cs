using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen1.CapaDatos;
using Examen1.CapaLogica;

namespace Examen1.CapaVistas
{
    public partial class Frm_Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  // Evita que se llene la tabla en cada postback
            {
                LlenarGrid();
            }
        }

        protected void bagregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Pacientes.Cedula = int.Parse(tcedula.Text);
                Cls_Pacientes.Nombre = tnombre.Text;
                Cls_Pacientes.PrimerApellido = tapellido.Text;
                Cls_Pacientes.Cedula = int.Parse(tcedula.Text);
                Cls_Pacientes.Nombre = tnombre.Text;
                Cls_Pacientes.PrimerApellido = tapellido.Text;
                Cls_Pacientes.FechaNacimiento = DateTime.Parse(tFechaNacimiento.Text).ToString("yyyy-MM-dd");
                Cls_Pacientes.Edad = int.Parse(tedad.Text);
                Cls_Pacientes.Telefono = ttelefono.Text;

                if (!Logica_Pacientes.ExisteUsuario())
                {
                    int resultado = Logica_Pacientes.Agregar();

                    if (resultado > 0)
                    {
                        LlenarGrid();
                        MostrarAlerta(this, "Usuario agregado correctamente.");
                    }
                    else
                    {
                        MostrarAlerta(this, "Error al agregar usuario.");
                    }
                }
                else
                {
                    MostrarAlerta(this, "El correo ya está registrado.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta(this, "Error: " + ex.Message);
            }
        }

        protected void bmodificar_Click(object sender, EventArgs e)
        {
            Cls_Pacientes.Cedula = int.Parse(tcedula.Text);
            Cls_Pacientes.Nombre = tnombre.Text;
            Cls_Pacientes.PrimerApellido = tapellido.Text;
            Cls_Pacientes.Cedula = int.Parse(tcedula.Text);
            Cls_Pacientes.Nombre = tnombre.Text;
            Cls_Pacientes.PrimerApellido = tapellido.Text;
            Cls_Pacientes.FechaNacimiento = DateTime.Parse(tFechaNacimiento.Text).ToString("yyyy-MM-dd"); 
            Cls_Pacientes.Edad = int.Parse(tedad.Text);
            Cls_Pacientes.Telefono = ttelefono.Text;
            int resultado = Logica_Pacientes.Modificar();

            if (resultado > 0)
            {
                LlenarGrid();
                MostrarAlerta(this, "Paciente modificado correctamente.");
            }
            else
            {
                MostrarAlerta(this, "Error al modificar Paciente.");
            }
        }

        protected void bborrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Pacientes.Cedula = int.Parse(tcedula.Text);

                int resultado = Logica_Pacientes.Borrar();

                if (resultado > 0)
                {
                    LlenarGrid();
                    MostrarAlerta(this, "Paciente eliminado correctamente.");
                }
                else
                {
                    MostrarAlerta(this, "No se encontró el paciente.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta(this, "Error: " + ex.Message);
            }
        }
        public static void MostrarAlerta(Page page, String message)
        {
            string script = $"<script type ='text/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pacientes", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnMostrarCalendario_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            tFechaNacimiento.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }
    }

}