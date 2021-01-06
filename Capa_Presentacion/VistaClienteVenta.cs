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
    public partial class VistaClienteVenta : Form
    {
        public VistaClienteVenta()
        {
            InitializeComponent();
        }

        //    Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarApellidos
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCliente.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarLocalidad()
        {
            this.dataListado.DataSource = NCliente.BuscarLocalidad(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Nombre"))
            {
                this.BuscarNombre();
            }
            else if (cbBuscar.Text.Equals("Localidad"))
            {
                this.BuscarLocalidad();
            }
        }

      
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {

            Ventas form = Ventas.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Id Cliente"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value) + " " +  
                   Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido Materno"].Value) + " " + 
                   Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido Paterno"].Value);
                //+ " " 
                //+
                //Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido_Materno"].Value) + " " +
                //Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido_Paterno"].Value);
            form.setCliente(par1, par2);
            this.Hide();



            //Ventas form = Ventas.GetInstancia();
            //string par1, par2;
            //decimal par3, par4;
            //int par5;

            //par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Id_Producto"].Value);
            //par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            //par3 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["Precio_Compra"].Value);
            //par4 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["Precio_Venta"].Value);
            //par5 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Stock_Actual"].Value);

            //form.setArticulo(par1, par2, par3, par4, par5);
            //this.Hide();


        }

        private void VistaClienteVenta_Load(object sender, EventArgs e)
        {
            Mostrar();

        }
    }

}

