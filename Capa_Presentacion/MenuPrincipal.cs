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
    public partial class MenuPrincipal : Form
    {

        public string IdEmpleado = "";
        public string Apellido_Materno = "";
        public string Apellido_Paterno = "";
        public string Nombre = "";
        public string IdRol = "";
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcesoClarificado frm = new ProcesoClarificado();
           // frm.MdiParent = this;
            frm.Show();
            frm.IdEmpleado = Convert.ToInt32(this.IdEmpleado);
        }
    }
}
