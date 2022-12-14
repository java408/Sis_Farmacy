using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace FarmaciaMysql.Conexion
{
     class conexion
    {
        public MySqlConnection cn = new MySqlConnection();

        public MySqlConnection obtenerConeccion()
        {
            cn = new MySqlConnection("Server = localhost; Database = farmamysql; Uid = root; Pwd =;");
            // cn = new SqlConnection("Data Source=sql7005.site4now.net;Initial Catalog=DB_A480F7_cristianpatric;User ID=DB_A480F7_cristianpatric_admin;Password=lac199024");
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DescargarConexion()
        {
            cn.Dispose();
            return true;
        }
    }
}
