using bancouh1.Capa_Logica;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace bancouh1.Presentacion
{
    public partial class CatalogoAsignaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LlenarGrid();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT AsignacionID, ReparacionID, TecnicoID, FechaAsignacion
                  FROM dbo.Asignaciones ORDER BY AsignacionID", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridViewAsignaciones.DataSource = rdr;
                    GridViewAsignaciones.DataBind();
                }
            }
        }

        private bool ObtenerDatos(out int asignacionID, out int reparacionID,
            out int tecnicoID, out DateTime fechaAsignacion, bool validarFecha)
        {
            asignacionID = 0;
            reparacionID = 0;
            tecnicoID = 0;
            fechaAsignacion = DateTime.MinValue;

            if (!int.TryParse(txtAsignacionID.Text.Trim(), out asignacionID))
            {
                lblMensaje.Text = "Ingrese un ID de asignacion numerico.";
                return false;
            }

            if (!validarFecha)
                return true;

            if (!int.TryParse(txtReparacionID.Text.Trim(), out reparacionID))
            {
                lblMensaje.Text = "Ingrese un ID de reparacion numerico.";
                return false;
            }

            if (!int.TryParse(txtTecnicoID.Text.Trim(), out tecnicoID))
            {
                lblMensaje.Text = "Ingrese un ID de tecnico numerico.";
                return false;
            }

            if (!DateTime.TryParseExact(txtFechaAsignacion.Text.Trim(), "yyyy-MM-dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaAsignacion))
            {
                lblMensaje.Text = "Seleccione una fecha de asignacion valida.";
                return false;
            }

            return true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int asignacionID, reparacionID, tecnicoID;
            DateTime fecha;
            if (!ObtenerDatos(out asignacionID, out reparacionID, out tecnicoID, out fecha, true))
                return;

            try
            {
                if (Asignaciones_CL.AgregarAsignacion(asignacionID, reparacionID, tecnicoID, fecha) > 0)
                {
                    lblMensaje.Text = "Asignacion agregada correctamente.";
                    LlenarGrid();
                }
                else
                    lblMensaje.Text = "No se pudo agregar la asignacion.";
            }
            catch (SqlException ex)
            {
                lblMensaje.Text = "Error al agregar. Verifique que el ID de asignacion no exista y que los datos sean validos. Detalle: " + ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int asignacionID, reparacionID, tecnicoID;
            DateTime fecha;
            if (!ObtenerDatos(out asignacionID, out reparacionID, out tecnicoID, out fecha, true))
                return;

            try
            {
                if (Asignaciones_CL.ModificarAsignacion(asignacionID, reparacionID, tecnicoID, fecha) > 0)
                {
                    lblMensaje.Text = "Asignacion modificada correctamente.";
                    LlenarGrid();
                }
                else
                    lblMensaje.Text = "No se encontro una asignacion con ese ID.";
            }
            catch (SqlException ex)
            {
                lblMensaje.Text = "Error al modificar. Verifique los datos. Detalle: " + ex.Message;
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int asignacionID, reparacionID, tecnicoID;
            DateTime fecha;
            if (!ObtenerDatos(out asignacionID, out reparacionID, out tecnicoID, out fecha, false))
                return;

            try
            {
                if (Asignaciones_CL.EliminarAsignacion(asignacionID) > 0)
                {
                    lblMensaje.Text = "Asignacion eliminada correctamente.";
                    LlenarGrid();
                }
                else
                    lblMensaje.Text = "No se encontro una asignacion con ese ID.";
            }
            catch (SqlException ex)
            {
                lblMensaje.Text = "No se pudo eliminar la asignacion. Detalle: " + ex.Message;
            }
        }
    }
}
