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
	public partial class Frm_Consultas : System.Web.UI.Page
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
                Cls_Consultas.ID_Consulta = int.Parse(tIDconsulta.Text);
                Cls_Consultas.Cedula = int.Parse(tcedula.Text);
                Cls_Consultas.ID_Medico = int.Parse(tIDmedico.Text);
                Cls_Consultas.FechaAtencion = DateTime.Parse(tFechaAtencion.Text).ToString("yyyy-MM-dd");

                string horaSeleccionada = Request.Form["hora"];    // Hora seleccionada (01-12)
                string minutosSeleccionados = Request.Form["minutos"];  // Minutos seleccionados (00, 15, 30, 45)
                string ampmSeleccionado = Request.Form["ampm"];    // AM/PM seleccionado

                // Concatenar la hora completa en formato de 12 horas
                Cls_Consultas.HoraAtencion = $"{horaSeleccionada}:{minutosSeleccionados} {ampmSeleccionado}";

                Cls_Consultas.Consultorio = int.Parse(tconsultorio.Text);



                if (!Logica_Consulta.ExisteUsuario())
                {
                    int resultado = Logica_Consulta.Agregar();

                    if (resultado > 0)
                    {
                        LlenarGrid();
                        MostrarAlerta(this, "Consulta agregado correctamente.");
                    }
                    else
                    {
                        MostrarAlerta(this, "Error al agregar Consulta.");
                    }
                }
                else
                {
                    MostrarAlerta(this, "El usuario ya está registrado.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta(this, "Error: " + ex.Message);
            }
        }

        protected void bmodificar_Click(object sender, EventArgs e)
        {
            Cls_Consultas.ID_Consulta = int.Parse(tIDconsulta.Text);
            Cls_Consultas.Cedula = int.Parse(tcedula.Text);
            Cls_Consultas.ID_Medico = int.Parse(tIDmedico.Text);
            Cls_Consultas.FechaAtencion = DateTime.Parse(tFechaAtencion.Text).ToString("yyyy-MM-dd");

            string horaSeleccionada = Request.Form["hora"];    // Hora seleccionada (01-12)
            string minutosSeleccionados = Request.Form["minutos"];  // Minutos seleccionados (00, 15, 30, 45)
            string ampmSeleccionado = Request.Form["ampm"];    // AM/PM seleccionado

            // Concatenar la hora completa en formato de 12 horas
            Cls_Consultas.HoraAtencion = $"{horaSeleccionada}:{minutosSeleccionados} {ampmSeleccionado}";
            Cls_Consultas.Consultorio = int.Parse(tconsultorio.Text);

            int resultado = Logica_Consulta.Modificar();

            if (resultado > 0)
            {
                LlenarGrid();
                MostrarAlerta(this, "Consulta modificado correctamente.");
            }
            else
            {
                MostrarAlerta(this, "Error al modificar Consulta.");
            }
        }

        protected void bborrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Consultas.ID_Consulta = int.Parse(tIDconsulta.Text);

                int resultado = Logica_Consulta.Borrar();

                if (resultado > 0)
                {
                    LlenarGrid();
                    MostrarAlerta(this, "Consulta eliminado correctamente.");
                }
                else
                {
                    MostrarAlerta(this, "No se encontró el Consulta.");
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Consultas", con))
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
            tFechaAtencion.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }
    }
}