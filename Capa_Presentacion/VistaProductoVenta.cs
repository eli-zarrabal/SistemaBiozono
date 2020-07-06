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
    public partial class VistaProductoVenta : Form
    {
        public VistaProductoVenta()
        {
            InitializeComponent();
        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

      
        private void MostrarProducto_Venta_Nombre()
        {
            this.dataListado.DataSource = NVenta.MostrarProducto_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Nombre"))
            {
                this.MostrarProducto_Venta_Nombre();
            }
        }

        private void VistaProductoVenta_Load(object sender, EventArgs e)
        {

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            Ventas form = Ventas.GetInstancia();
            string  par1, par2;
            decimal par3, par4;
            int par5;
            
           par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Id_Producto"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            par3 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["Precio_Compra"].Value);
            par4 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["Precio_Venta"].Value);
            par5 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Stock_Actual"].Value);
            
            form.setArticulo(par1, par2, par3, par4, par5);
            this.Hide();
        }
    }
}
