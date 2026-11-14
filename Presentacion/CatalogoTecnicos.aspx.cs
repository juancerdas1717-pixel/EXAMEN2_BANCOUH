using bancouh1.Capa_Logica;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace bancouh1.Presentacion
{
    public partial class CatalogoTecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos", con))
            {
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtTecnicoID.Text, out id))
            {
                lblMensaje.Text = "Ingrese un ID numerico.";
                return;
            }

            if (Tecnicos_CL.AgregarTecnico(id, txtNombre.Text, txtEspecialidad.Text) > 0)
            {
                lblMensaje.Text = "Tecnico agregado correctamente.";
                LlenarGrid();
            }
            else
            {
                lblMensaje.Text = "No se pudo agregar el tecnico. Verifique que el ID no exista.";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtTecnicoID.Text, out id))
            {
                lblMensaje.Text = "Ingrese un ID numerico.";
                return;
            }

            if (Tecnicos_CL.ModificarTecnico(id, txtNombre.Text, txtEspecialidad.Text) > 0)
            {
                lblMensaje.Text = "Tecnico modificado correctamente.";
                LlenarGrid();
            }
            else
            {
                lblMensaje.Text = "No se pudo modificar. Verifique que el ID exista.";
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtTecnicoID.Text, out id))
            {
                lblMensaje.Text = "Ingrese un ID numerico.";
                return;
            }

            if (Tecnicos_CL.EliminarTecnico(id) > 0)
            {
                lblMensaje.Text = "Tecnico eliminado correctamente.";
                LlenarGrid();
            }
            else
            {
                lblMensaje.Text = "No se pudo eliminar. Verifique que el ID exista.";
            }
        }
    }
}
