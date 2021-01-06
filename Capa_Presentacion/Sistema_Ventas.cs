using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Capa_Presentacion
{
    public partial class Sistema_Ventas : Form
    {
        public Sistema_Ventas()
        {
            InitializeComponent();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Maximized;
            btnMin.Visible = true;
            btnMaximizar.Visible = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMin.Visible = false;
            btnMaximizar.Visible = true;

        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
                MenuVertical.Width = 250;
        }

        // En esta parte esta el Codigo para poder mover la ventana seleccionando la barra de titulo.
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        // Aqui creamos el metodo donde hacemos el llamado del formulario hijo.
        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }
        // con este boton invocamos el metodo 
        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Producto());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new InicioResumen());
        }

        private void Sistema_Ventas_Load(Object sender, EventArgs e)
        {
           
        }

        private void Sistema_Ventas_Load_1(object sender, EventArgs e)
        {
            pictureBox1_Click(null, e);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Ingreso());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Empleado());
        }
    }
}
