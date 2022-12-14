using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FarmaciaMysql.Conexion;
using MySql.Data.MySqlClient;
namespace FarmaciaMysql
{
    public partial class Frmcliente : Form
    {
        conexion cn = new conexion();
        public Frmcliente()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            limpiar();
            Button2.Enabled = true;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            String query = "insert into clientes values('" + textBox1.Text + "','" + this.textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            MySqlCommand cm = new MySqlCommand(query, cn.obtenerConeccion());
            MySqlDataReader dr;
            try
            {
                dr = cm.ExecuteReader();
                MessageBox.Show("Datos Guardados Corectamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);


                carga();
                limpiar();
                Button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.DescargarConexion();
            }
        }

        private void Frmcategoria_Load(object sender, EventArgs e)
        {
            carga();

        }
        void carga()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select*from clientes", cn.obtenerConeccion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Estas Seguro que quieres eleminar el Registro " + this.textBox1.Text, "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string b = "delete from clientes where idclientes='" + this.textBox1.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(b, cn.obtenerConeccion());
                    cmd.ExecuteNonQuery();
                    carga();
                    MessageBox.Show("Datos Eleminado Correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carga();
                    limpiar();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    cn.DescargarConexion();
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["idclientes"].Value.ToString();
                textBox2.Text = row.Cells["nombres"].Value.ToString();
                textBox3.Text = row.Cells["direccion"].Value.ToString();

                textBox4.Text = row.Cells["dni"].Value.ToString();


            }

        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["idclientes"].Value.ToString();
                textBox2.Text = row.Cells["nombres"].Value.ToString();
                textBox3.Text = row.Cells["direccion"].Value.ToString();

                textBox4.Text = row.Cells["dni"].Value.ToString();


            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string update = "update clientes set nombres='" + this.textBox2.Text + "' ,direccion='"+textBox3.Text+"',dni='"+textBox4.Text+"' where idclientes='" + this.textBox1.Text + "'";
            MySqlCommand cm = new MySqlCommand(update, cn.obtenerConeccion());
            MySqlDataReader dr;
            try
            {
                dr = cm.ExecuteReader();
                MessageBox.Show("Datos Actualizados Corectamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                carga();
                //habilitar botones
               


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.DescargarConexion();
            }
        }
    }
}
