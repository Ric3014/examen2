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
    public partial class Frm_Medicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void bagregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Medicos.ID_Medico = int.Parse(tidmedico.Text);
                Cls_Medicos.Nombre = tnombre.Text;
                Cls_Medicos.Especialidad = tespecialidad.Text;
                

                if (!Logica_Medico.ExisteMedico())
                {
                    int resultado = Logica_Medico.Agregar();

                    if (resultado > 0)
                    {
                        LlenarGrid();
                        MostrarAlerta(this, "Medico agregado correctamente.");
                    }
                    else
                    {
                        MostrarAlerta(this, "Error al agregar Medico.");
                    }
                }
                else
                {
                    MostrarAlerta(this, "El Medico ya está registrado.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta(this, "Error: " + ex.Message);
            }
        }

        protected void bmodificar_Click(object sender, EventArgs e)
        {
            Cls_Medicos.ID_Medico = int.Parse(tidmedico.Text);
            Cls_Medicos.Nombre = tnombre.Text;
            Cls_Medicos.Especialidad = tespecialidad.Text;
            int resultado = Logica_Medico.Modificar();

            if (resultado > 0)
            {
                LlenarGrid();
                MostrarAlerta(this, "Medico modificado correctamente.");
            }
            else
            {
                MostrarAlerta(this, "Error al modificar Medico.");
            }
        }

        protected void bborrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Medicos.ID_Medico = int.Parse(tidmedico.Text);

                int resultado = Logica_Medico.Borrar();

                if (resultado > 0)
                {
                    LlenarGrid();
                    MostrarAlerta(this, "Medico eliminado correctamente.");
                }
                else
                {
                    MostrarAlerta(this, "No se encontró el Medico.");
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Medicos", con))
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
    }
}