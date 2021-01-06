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
    public partial class StockProductos : Form
    {
        public StockProductos()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;

        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NProducto.Stock_Productos();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void StockProductos_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
    }
}
