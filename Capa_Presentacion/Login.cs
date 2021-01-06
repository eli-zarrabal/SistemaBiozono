using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class Login : Form
    {

        public static String usuario;
       
        public Login()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {

            DataTable Datos = Capa_Negocio.NEmpleado.Login(this.TxtUsuario.Text, this.TxtPassword.Text);
            //Evaluar si existe el Usuario
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("No Tiene Acceso al Sistema", "Sistema BIOZONO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FormPrincipal frm = new FormPrincipal();
                frm.IdEmpleado = Datos.Rows[0][0].ToString();
                frm.Apellido_Materno = Datos.Rows[0][1].ToString();
                frm.Apellido_Paterno = Datos.Rows[0][2].ToString();
                frm.IdRol = Datos.Rows[0][3].ToString();
              
                frm.Show();
                this.Hide();

            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToLongDateString();
        }

        //private void BtnIngresar_Click(object sender, EventArgs e)
        //{

        //  
    }
    }

