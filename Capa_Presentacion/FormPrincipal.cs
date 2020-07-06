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
    public partial class FormPrincipal : Form
    {
        private int childFormNumber = 0;

        public string IdEmpleado = "";
        public string Apellido_Materno = "";
        public string Apellido_Paterno = "";
        public string Nombre = "";
        public string IdRol = "";

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Producto frm = new Producto();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente frm = new Cliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleado frm = new Empleado();
            frm.MdiParent = this;
            frm.Show();
         //   frm.IdRol = Convert.ToInt32(this.IdRol);
           
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }

        private void GestionUsuario()
        {
            //COntrolar los accesos administrador
            //if (Rol == "Administrador")
            //{
            //    this.MnuAlmacen.Enabled = true;
            //    this.MnuCompras.Enabled = true;
            //    this.MnuVentas.Enabled = false;
            //    this.MnuMantenimiento.Enabled = true;
            //    this.MnuConsultas.Enabled = true;
            //    this.MnuHerramientas.Enabled = true;
            //    this.TsCompras.Enabled = true;
            //    this.TsVentas.Enabled = true;

            //}
            //else if (Rol == "General")
            //{



            //    this.MnuAlmacen.Enabled = false;
            //    this.MnuCompras.Enabled = false;
            //    this.MnuVentas.Enabled = true;
            //    this.MnuMantenimiento.Enabled = false;
            //    this.MnuConsultas.Enabled = true;
            //    this.MnuHerramientas.Enabled = true;
            //    this.TsCompras.Enabled = false;
            //    this.TsVentas.Enabled = true;

            //}
            //else if (Acceso == "Almacenero")
            //{
            //    this.MnuAlmacen.Enabled = true;
            //    this.MnuCompras.Enabled = true;
            //    this.MnuVentas.Enabled = false;
            //    this.MnuMantenimiento.Enabled = false;
            //    this.MnuConsultas.Enabled = true;
            //    this.MnuHerramientas.Enabled = true;
            //    this.TsCompras.Enabled = true;
            //    this.TsVentas.Enabled = false;

            //}
            //else
            //{
            //    this.MnuAlmacen.Enabled = false;
            //    this.MnuCompras.Enabled = false;
            //    this.MnuVentas.Enabled = false;
            //    this.MnuMantenimiento.Enabled = false;
            //    this.MnuConsultas.Enabled = false;
            //    this.MnuHerramientas.Enabled = false;
            //    this.TsCompras.Enabled = false;
            //    this.TsVentas.Enabled = false;

        }
 

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingreso frm = Ingreso.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.IdEmpleado = Convert.ToInt32(this.IdEmpleado);
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ventas frm = Ventas.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.IdEmpleado = Convert.ToInt32(this.IdEmpleado);

        }

        //private void stockDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Consultas.FrmConsulta_Stock_Articulos frm = new Consultas.FrmConsulta_Stock_Articulos();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        //private void comprasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Consultas.FrmConsultaCompras frm = new Consultas.FrmConsultaCompras();
        //    frm.MdiParent = this;
        //    frm.Show();
        //    frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        //}

        //private void ventasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Consultas.FrmConsultaVentas frm = new Consultas.FrmConsultaVentas();
        //    frm.MdiParent = this;
        //    frm.Show();
        //    frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        //}

        private void TsCompras_Click(object sender, EventArgs e)
        {
            Ingreso frm = Ingreso.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.IdEmpleado = Convert.ToInt32(this.IdEmpleado);
        }

        private void TsVentas_Click(object sender, EventArgs e)
        {
            Ventas frm = Ventas.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.IdEmpleado = Convert.ToInt32(this.IdEmpleado);

        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MnuCompras_Click(object sender, EventArgs e)
        {

        }

        private void procesosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void procesoPurificadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcesoPurificado frm = ProcesoPurificado.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.IdEmpleado = Convert.ToInt32(this.IdEmpleado);
        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cliente frm = new Cliente();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
