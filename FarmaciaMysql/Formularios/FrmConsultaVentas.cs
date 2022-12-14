using FarmaciaMysql.Conexion;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaciaMysql
{
    public partial class FrmConsultaVentas : Form
    {
        conexion cn = new conexion();
        public DateTime date;
        public FrmConsultaVentas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                MySqlDataAdapter da = new MySqlDataAdapter("select*from venta where fecha='" + label2.Text + "'", cn.obtenerConeccion());
            DataTable dt = new DataTable();
            da.Fill(dt);
                    dataGridView1.DataSource = dt;
                
                   
                

        }

        private void FrmConsultaVentas_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = Convert.ToDateTime(dateTimePicker1.Text);
            label2.Text = Convert.ToString(date.ToString("yyyy-MM-dd"));
        }
    }
}
