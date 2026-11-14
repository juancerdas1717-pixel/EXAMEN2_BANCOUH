using System;
using System.Data;
using System.Data.SqlClient;

namespace bancouh1.Capa_Logica
{
    public class Asignaciones_CL
    {
        public static int AgregarAsignacion(int asignacionID, int reparacionID, int tecnicoID, DateTime fechaAsignacion)
        {
            using (SqlConnection conn = DBconn.obtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO dbo.Asignaciones
                  (AsignacionID, ReparacionID, TecnicoID, FechaAsignacion)
                  VALUES (@AsignacionID, @ReparacionID, @TecnicoID, @FechaAsignacion)", conn))
            {
                cmd.Parameters.Add("@AsignacionID", SqlDbType.Int).Value = asignacionID;
                cmd.Parameters.Add("@ReparacionID", SqlDbType.Int).Value = reparacionID;
                cmd.Parameters.Add("@TecnicoID", SqlDbType.Int).Value = tecnicoID;
                cmd.Parameters.Add("@FechaAsignacion", SqlDbType.Date).Value = fechaAsignacion.Date;
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ModificarAsignacion(int asignacionID, int reparacionID, int tecnicoID, DateTime fechaAsignacion)
        {
            using (SqlConnection conn = DBconn.obtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE dbo.Asignaciones
                  SET ReparacionID = @ReparacionID,
                      TecnicoID = @TecnicoID,
                      FechaAsignacion = @FechaAsignacion
                  WHERE AsignacionID = @AsignacionID", conn))
            {
                cmd.Parameters.Add("@AsignacionID", SqlDbType.Int).Value = asignacionID;
                cmd.Parameters.Add("@ReparacionID", SqlDbType.Int).Value = reparacionID;
                cmd.Parameters.Add("@TecnicoID", SqlDbType.Int).Value = tecnicoID;
                cmd.Parameters.Add("@FechaAsignacion", SqlDbType.Date).Value = fechaAsignacion.Date;
                return cmd.ExecuteNonQuery();
            }
        }

        public static int EliminarAsignacion(int asignacionID)
        {
            using (SqlConnection conn = DBconn.obtenerConexion())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM dbo.Asignaciones WHERE AsignacionID = @AsignacionID", conn))
            {
                cmd.Parameters.Add("@AsignacionID", SqlDbType.Int).Value = asignacionID;
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
