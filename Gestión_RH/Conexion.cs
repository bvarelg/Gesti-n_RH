using System;
using System.Data.SqlClient;

namespace Gestión_RH
{
    internal class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool seguridad;

        private static Conexion con = null;

        private Conexion()
        {
            this.Base = "gestion_rh";
            this.Servidor = "DESKTOP-M5H8T08\\SQLEXPRESS";
            this.Usuario = "sa";
            this.Clave = "1234";
            this.seguridad = true;
        }

        public SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection();

            if (this.seguridad)
            {
                conexion.ConnectionString =
                    $"Data Source={this.Servidor};Initial Catalog={this.Base};Integrated Security=SSPI";
            }
            else
            {
                conexion.ConnectionString =
                    $"Data Source={this.Servidor};Initial Catalog={this.Base};User ID={this.Usuario};Password={this.Clave};";
            }

            return conexion;
        }

        public static Conexion Instancia()
        {
            if (con == null)
            {
                con = new Conexion();
            }
            return con;
        }
    }
}
