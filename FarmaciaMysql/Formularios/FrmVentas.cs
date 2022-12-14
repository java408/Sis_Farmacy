using FarmaciaMysql.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace FarmaciaMysql
{
    public partial class FrmVentas : Form
    {
        conexion cn = new conexion();
        public FrmVentas()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Label9.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label21.Text = DateTime.Now.ToShortTimeString();
        }

        private void BtnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cm = new MySqlCommand("select*from clientes where dni='" + TextBox5.Text + "'", cn.obtenerConeccion());
                MySqlDataReader dr = cm.ExecuteReader();
                if (dr.Read() == true)
                {
                    TextBox4.Text = dr["nombres"].ToString();
                    Label10.Text = dr["idclientes"].ToString();
                    // Label9.Text = dr["idclientes"].ToString();

                    TextBox5.Text = dr["DNI"].ToString();
                    // textBox6ext = dr["Stock"].ToString();
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("Cliente no Encontrado", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TextBox5.Text = "";
                    TextBox5.Focus();

                }
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

        private void FrmVentas_Load(object sender, EventArgs e)
        {

        }

        private void TextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnExaminar_Click(sender, e);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cm = new MySqlCommand("select*from producto where idproducto='" + textBox1.Text + "'", cn.obtenerConeccion());
                MySqlDataReader dr = cm.ExecuteReader();
                if (dr.Read() == true)
                {
                    textBox2.Text = dr["Nombre"].ToString();
                    // Label10.Text = dr["idclientes"].ToString();
                    textBox6.Text = dr["stock"].ToString();
                    textBox3.Text = dr["precio_venta"].ToString();
                    textBox1.Text = dr["idproducto"].ToString();
                    maskedTextBox1.Text = "1";
                    maskedTextBox1.Focus();
                }
                else
                {
                    MessageBox.Show("Cliente no Encontrado", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TextBox5.Text = "";
                    TextBox5.Focus();

                }
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4_Click(sender, e);

            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            //maskedTextBox1.Text = "0";
            if (maskedTextBox1.Text == "")

            {
                MessageBox.Show("Debe ingresar la cantidad", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                maskedTextBox1.Text = "";
                maskedTextBox1.Focus();
            }

            else if (int.Parse(maskedTextBox1.Text) > int.Parse(textBox6.Text))
            {
                //MessageBox.Show("Debes Ingresar la cantidad", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("La cantidad supera el stock o no tiene stock suficiente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Text = "";
                maskedTextBox1.Focus();
                textBox2.Text = "";

                textBox3.Text = "";
                textBox6.Text = "";
            }

            //codigo con listview

            else
            {
                ListViewItem lista = new ListViewItem(textBox1.Text);
                lista.SubItems.Add(textBox2.Text);
                lista.SubItems.Add(textBox3.Text);
                lista.SubItems.Add(maskedTextBox1.Text);
                lista.SubItems.Add((Decimal.Parse(maskedTextBox1.Text) * Decimal.Parse(textBox3.Text)).ToString());
                listView1.Items.Add(lista);
                //calcula iva
                sumartotal();

                //limpia para nuevo producto
                textBox1.Text = "";
                textBox2.Text = "";
                maskedTextBox1.Text = "";
                textBox3.Text = "";
                textBox6.Text = "";
                textBox1.Focus();



            }

        }
        void sumartotal()
        {
            Decimal dblSuma = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                dblSuma += Convert.ToDecimal(item.SubItems[4].Text);
            }


            lbltotal.Text = Convert.ToString(dblSuma);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseas Eleminar el Producto ?", "Sistema", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                    //actualiza la sumas de venta

                    sumartotal();
                }
                else
                {
                    MessageBox.Show("Seleccione una Fila");

                }


            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseas cancelar los pedidos ?", "Sistema", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                listView1.Items.RemoveAt(0);

                sumartotal();

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnbuscarproducto_Click(sender, e);

            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (TextBox5.Text == "")
            {
                MessageBox.Show("Ingrese el cliente");
                TextBox5.Text = "";
                TextBox5.Focus();
            }
            else
            {
                String query = "insert into venta values('" + textBox8.Text + "','" + Label9.Text + "','" + "1" + "','" + Label10.Text + "','" + lbltotal.Text + "')";
                MySqlCommand cm = new MySqlCommand(query, cn.obtenerConeccion());
                MySqlDataReader dr;


                dr = cm.ExecuteReader();
                guardadetalle();
                MessageBox.Show("Datos Guardados Corectamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);


                nuevo();

            }
        }
        void nuevo()
        {



            textBox2.Text = "";
            maskedTextBox1.Text = "0";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";

            TextBox4.Text = "";
            Label10.Text = "";
            textBox6.Text = "";

            // label26.Text = "";
            //DataGridView1.Rows.Clear();
            btnguardar.Enabled = true;
            lbltotal.Text = "";

            //limpiar listas agregados
            listView1.Items.Clear();
            textBox1.Text = "";
            TextBox5.Text = "";
            TextBox5.Focus();


        }
        void guardadetalle()
        {
            
                String idproducto;
                decimal cantidad, precioventa, importe;
                MySqlCommand cmd = new MySqlCommand("InsertarDetalle", cn.obtenerConeccion());
                cmd.CommandType = CommandType.StoredProcedure;
                cn.obtenerConeccion();

                foreach (ListViewItem item in listView1.Items)
                {
                    idproducto = Convert.ToString(item.SubItems[0].Text);
                    cantidad = Convert.ToDecimal(item.SubItems[3].Text);
                    precioventa = Convert.ToDecimal(item.SubItems[2].Text);
                    importe = Convert.ToDecimal(item.SubItems[4].Text);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nro_venta", SqlDbType.Char).Value = textBox8.Text;
                  cmd.Parameters.AddWithValue("@id_venta", SqlDbType.Char).Value = textBox8.Text;

                cmd.Parameters.AddWithValue("@id_producto", idproducto);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@precio_Venta", precioventa);
                cmd.Parameters.AddWithValue("@sub_total", precioventa);
                cmd.Parameters.AddWithValue("@total", importe);

                    cmd.ExecuteNonQuery();


                }
            
        }
    
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }
    }
}
