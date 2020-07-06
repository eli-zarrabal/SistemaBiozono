using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Capa_Negocio;

namespace Capa_Presentacion
{
    public partial class VistaArticuloIngreso : Form
    {
        public VistaArticuloIngreso()
        {
            InitializeComponent();
        }

        //public void setProducto(string idproducto, string nombre)
        //{
        //    this.I.Text = idproducto;
        //    this.txtArticulo.Text = nombre;
        //}


        //Método para ocultar columnas
        //private void OcultarColumnas()
        //{
        //    this.dataListado.Columns[0].Visible = false;
        //    this.dataListado.Columns[1].Visible = false;
        //  //  this.dataListado.Columns[6].Visible = false;
        //    this.dataListado.Columns[8].Visible = false;
        //}

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NProducto.Mostrar();
           // this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NProducto.BuscarNombre(this.txtBuscar.Text);
           // this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void VistaArticuloIngreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {

            Ingreso form = Ingreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Id_producto"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            form.setProducto(par1, par2);
            this.Hide();
        }

       
        //private void OcultarColumnas()
        //{
        //    this.dataListado.Columns[0].Visible = false;
        //    this.dataListado.Columns[1].Visible = false;
        //}
    }

}
