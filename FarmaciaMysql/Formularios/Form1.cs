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
    public partial class Form1 : Form
    {
        //public MySqlConnection cn = new MySqlConnection("Server=localhost;Database=farmamysql; Uid=root;Pwd=;");
        conexion cn = new conexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Conectandote al servidor local
            
            

                     
        }
        private void ingresar()
        {
            try
            {
                string usuario;
                string pass;

                usuario = this.UsernameTextBox.Text;
                pass = this.PasswordTextBox.Text;
               MySqlCommand cm = new MySqlCommand("select*from usuario where usuario='"+ usuario +"'and password ='"+ pass +"'",cn.obtenerConeccion());
                MySqlDataReader dr;
                cn.obtenerConeccion();
                dr = cm.ExecuteReader();
              

                if (dr.Read() == true)
                {
                    string usu;
                    //count = count + 1;
                    //usuariologin = dr["nombres"].ToString();
                   usu = dr["usuario"].ToString();
                    //nivel = Convert.ToInt32(dr["nivel_usu"].ToString());
                    //cargo = dr["cargo"].ToString();
                   
                    MessageBox.Show("Bienvenido  " + "Usuario " + "=>" + usu, "SystFarma 2019", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MDIParent1 f = new MDIParent1();
                    f.Show();
                    cn.DescargarConexion();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrecta", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UsernameTextBox.Text = "";
                    PasswordTextBox.Text = "";
                    UsernameTextBox.Focus();
                    cn.DescargarConexion();
                }

            }
            catch (Exception ex)
            {
                throw ex;
                

            
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "")
            {
                MessageBox.Show("Ingresa tu Usuario", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UsernameTextBox.Focus();
            }
            else if (PasswordTextBox.Text == "")
            {

                MessageBox.Show("Ingresa tu Password", "sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PasswordTextBox.Focus();
            }
            else
            {
                ingresar();
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ingresar();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
