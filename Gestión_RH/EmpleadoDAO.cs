using System;
using System.Data;
using System.Data.SqlClient;

namespace Gestión_RH
{
    internal class EmpleadoDAO
    {
        // LISTAR
        public DataTable Listar()
        {
            using (SqlConnection con = Conexion.Instancia().ObtenerConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT id_empleado, nombre, apellido, direccion, email FROM empleados",
                    con
                );

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // VALIDAR EXISTENCIA
        public bool ExisteEmpleado(int id)
        {
            using (SqlConnection con = Conexion.Instancia().ObtenerConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM empleados WHERE id_empleado = @id", con
                );
                cmd.Parameters.AddWithValue("@id", id);

                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // INSERTAR
        public bool Agregar(Empleado emp)
        {
            using (SqlConnection con = Conexion.Instancia().ObtenerConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO empleados (id_empleado, nombre, apellido, direccion, email) " +
                    "VALUES (@id, @nombre, @apellido, @direccion, @email)",
                    con
                );

                cmd.Parameters.AddWithValue("@id", emp.idEmpleado);
                cmd.Parameters.AddWithValue("@nombre", emp.Nombre);
                cmd.Parameters.AddWithValue("@apellido", emp.Apellido);
                cmd.Parameters.AddWithValue("@direccion", emp.Direccion);
                cmd.Parameters.AddWithValue("@email", emp.Email);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ACTUALIZAR
        public bool Actualizar(Empleado emp)
        {
            using (SqlConnection con = Conexion.Instancia().ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE empleados SET nombre=@nombre, apellido=@apellido, direccion=@direccion, email=@email " +
                    "WHERE id_empleado=@id",
                    con
                );

                cmd.Parameters.AddWithValue("@id", emp.idEmpleado);
                cmd.Parameters.AddWithValue("@nombre", emp.Nombre);
                cmd.Parameters.AddWithValue("@apellido", emp.Apellido);
                cmd.Parameters.AddWithValue("@direccion", emp.Direccion);
                cmd.Parameters.AddWithValue("@email", emp.Email);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ELIMINAR
        public bool Eliminar(int id)
        {
            using (SqlConnection con = Conexion.Instancia().ObtenerConexion())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM empleados WHERE id_empleado = @id",
                    con
                );

                cmd.Parameters.AddWithValue("@id", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
