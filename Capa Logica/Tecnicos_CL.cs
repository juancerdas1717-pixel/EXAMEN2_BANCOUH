using System;
using System.Data;
using System.Data.SqlClient;

namespace bancouh1.Capa_Logica
{
    public class Tecnicos_CL
    {
        public static int AgregarTecnico(int tecnicoID, string nombre, string especialidad)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Tecnicos (tecnicoID, nombre, especialidad) VALUES (@tecnicoID, @nombre, @especialidad)", Conn);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@tecnicoID", tecnicoID));
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@especialidad", especialidad));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int EliminarTecnico(int tecnicoID)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Tecnicos WHERE tecnicoID = @tecnicoID", Conn);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@tecnicoID", tecnicoID));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int ModificarTecnico(int tecnicoID, string nombre, string especialidad)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Tecnicos SET nombre = @nombre, especialidad = @especialidad WHERE tecnicoID = @tecnicoID", Conn);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@tecnicoID", tecnicoID));
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@especialidad", especialidad));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
    }
}
