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
    public partial class Frmproductos : Form
    {
        conexion cn = new conexion();
        public DateTime date;
        public Frmproductos()
        {
            InitializeComponent();
        }
        void carga()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select*from producto", cn.obtenerConeccion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void limpiar()
        {
            textBox1.Text = "";
            textBox1.Focus();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label8.Text = "";
            comboBox1.Text = "";
            label9.Text = "";
            dateTimePicker1.Text = "";
        }
        void cargaproveedor()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select*from proveedor", cn.obtenerConeccion());
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "nombres";
                label8.DataBindings.Add(new Binding("Text", dt, "id_proveedor"));
            }
            catch (Exception ex)
            {
                throw ex;


            }
        }
        private void Frmproductos_Load(object sender, EventArgs e)
        {
            carga();
            cargaproveedor();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            limpiar();
            Button2.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["idproducto"].Value.ToString();
                textBox2.Text = row.Cells["Nombre"].Value.ToString();
                textBox3.Text = row.Cells["precio_compra"].Value.ToString();
                textBox4.Text = row.Cells["precio_venta"].Value.ToString();
                textBox5.Text = row.Cells["stock"].Value.ToString();
                label8.Text = row.Cells["proveedor"].Value.ToString();
               label9.Text = row.Cells["Fecha_vencimiento"].Value.ToString();
                date = Convert.ToDateTime(row.Cells["Fecha_vencimiento"].Value.ToString());
                label9.Text = Convert.ToString(date.ToString("yyyy-MM-dd"));

                // dateTimePicker1.Text=""

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Selecciona el proveedor por favor", "Sistema");
                comboBox1.Text = "";
            }
            else
            {
                String query = "insert into producto values('" + textBox1.Text + "','" + this.textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + label8.Text + "','" + (label9.Text) + "')";
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
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //date =Convert.ToDateTime(dateTimePicker1.Text);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Estas Seguro que quieres eleminar el Registro " + this.textBox1.Text, "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string b = "delete from producto where idproducto='" + this.textBox1.Text + "'";
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

        private void Button3_Click(object sender, EventArgs e)
        {
            string update = "update producto set Nombre='" + this.textBox2.Text + "' ,precio_venta='" + textBox3.Text + "',precio_compra='" + textBox4.Text + "',stock='"+textBox5.Text+"',proveedor='"+label8.Text+"',Fecha_vencimiento='"+label9.Text+"' where idproducto='" + this.textBox1.Text + "'";
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            date = Convert.ToDateTime(dateTimePicker1.Text);
            label9.Text = Convert.ToString(date.ToString("yyyy-MM-dd"));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
