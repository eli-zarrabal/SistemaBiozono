using Capa_Negocio;
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
    public partial class Mantenimiento : Form
    {

        private bool IsEditar = false;
        private bool IsNuevo = false;
        public int IdEmpleado;


        private static Mantenimiento _Instancia;

        public static Mantenimiento GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new Mantenimiento();
            }
            return _Instancia;
        }



        public Mantenimiento()
        {
            InitializeComponent();
        }

        private void BuscarDescripcion()
        {
            this.dataListado.DataSource = NProcesoMantenimiento.BuscarDescripcion(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarEmpleado()
        {
            this.dataListado.DataSource = NProcesoMantenimiento.BuscarEmpleado(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Limpiar()
        {
            this.txtDescripcion.Text = string.Empty;
            this.Fecha.Text = string.Empty;
            this.txtIdEmpleado.Text = string.Empty;
            this.txtIdMantenimiento.Text = string.Empty;


        }
      
        private void Habilitar(bool Valor)
        {
            this.txtDescripcion.ReadOnly = !Valor;
         

        }
     
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

     
        private void Mostrar()
        {
            this.dataListado.DataSource = NProcesoMantenimiento.Mostrar();

            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void OcultarColumnas()
        {
         
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[10].Visible = false;


        }


        //Para mostrar mensaje de confirmación
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema BIOZONO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Para mostrar mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema BIOZONO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void Mantenimiento_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtDescripcion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtDescripcion.Text == string.Empty )

                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtDescripcion, "Ingrese una Descripción");
                

                }
                else
                {
                    MessageBox.Show("OK!");


                    if (this.IsNuevo)
                    {
                        rpta = NProcesoMantenimiento.Insertar(
                            txtDescripcion.Text,
                            dtFecha.Value,
                            IdEmpleado
  
                             );

                    }
                    else
                    {

                        rpta = NProcesoMantenimiento.Editar(
                                                   Convert.ToInt32(this.txtIdMantenimiento.Text),
                                                   txtDescripcion.Text,
                                                    dtFecha.Value,
                                                   IdEmpleado
                                                
                                                   );
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.txtIdEmpleado.Text = "";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtDescripcion.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {

            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema BIOZONO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NProcesoMantenimiento.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {

            this.txtIdMantenimiento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Id Mantenimiento"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripción"].Value);
            this.dtFecha.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha de Mantenimiento"].Value);
            this.txtIdEmpleado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Id Empleado"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (cbBuscar.Text.Equals("Descripción"))
            {
                this.BuscarDescripcion();
            }
            else if (cbBuscar.Text.Equals("Nombre Empleado"))
            {
                this.BuscarEmpleado();
            }
        }
    }
}
