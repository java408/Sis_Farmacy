using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//importamos la libreria a utilizar
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;
namespace FarmaciaMysql
{
    public partial class Frmlistarclientes1 : Form
    {
        public Frmlistarclientes1()
        {
            InitializeComponent();
        }

        private void Frmlistarclientes1_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {

           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection("Server = localhost; Database = farmamysql; Uid = root; Pwd =;");
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select*from clientes", cn);
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.RefreshReport();
        }
    }
}
