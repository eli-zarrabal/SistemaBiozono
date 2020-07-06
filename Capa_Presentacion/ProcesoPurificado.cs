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
    public partial class ProcesoPurificado : Form
    {


        private bool IsEditar = false;
        private bool IsNuevo = false;
        public int IdEmpleado;


        private static ProcesoPurificado _Instancia;

        public static ProcesoPurificado GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ProcesoPurificado();
            }
            return _Instancia;
        }
        public ProcesoPurificado()
        {
            InitializeComponent();
        }

     
      
        //Limpia los controles del formulario
        private void Limpiar()
        {
            this.txtFolioPurificado.Text = string.Empty;
            this.txtIdEmpleado.Text = string.Empty;
            this.txtIdPurificado.Text = string.Empty;
          

        }
        //Habilita los controles de los formularios
        private void Habilitar(bool Valor)
        {
            this.txtFolioPurificado.ReadOnly = !Valor;
          
            //this.dtFecha_EntradaSodio.Enabled = Valor;
            //this.dtFecha_EntradaSodio.Enabled = Valor;
        }
        //Habilita los botones
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

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NProcesoPurificado.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void OcultarColumnas()
        {
          //  this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
          
        }

        
        private void BuscarFolio()
        {
            this.dataListado.DataSource = NProcesoPurificado.BuscarFolio(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //private void BuscarLocalidad()
        //{
        //    this.dataListado.DataSource = NCliente.BuscarLocalidad(this.txtBuscar.Text);
        //    this.OcultarColumnas();
        //    lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        //}

        private void ProcesoPurificado_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }
        //Para mostrar mensaje de confirmación
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Para mostrar mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtFolioPurificado.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtFolioPurificado.Text == string.Empty || 
                    this.dtFecha_SalidaSodio.Text == string.Empty ||
                    this.dtFecha_EntradaSodio.Text == string.Empty)

                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtFolioPurificado, "Ingrese un Folio");
                    errorIcono.SetError(dtFecha_SalidaSodio, "Ingrese una Fecha de Salida del Sodio");
                    errorIcono.SetError(dtFecha_EntradaSodio, "Ingrese una Fecha de Entrada del Sodio");

                }
                else
                {
                    MessageBox.Show("OK!");


                    if (this.IsNuevo)
                    {
                        rpta = NProcesoPurificado.Insertar(
                            IdEmpleado,
                            dtFecha_EntradaSodio.Value,
                            dtFecha_SalidaSodio.Value,
                            this.txtFolioPurificado.Text
                             );

                    }
                    else
                    {

                        rpta = NProcesoPurificado.Editar(
                            
                                                   Convert.ToInt32(this.txtIdPurificado.Text),
                                                   IdEmpleado,
                                                   dtFecha_EntradaSodio.Value,
                                                   dtFecha_SalidaSodio.Value,
                                                   this.txtFolioPurificado.Text
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Folio"))
            {
                this.BuscarFolio();
            }
            else if (cbBuscar.Text.Equals("Nombre Empleado"))
            {
               // this.BuscarLocalidad();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

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
                            Rpta = NProcesoPurificado.Eliminar(Convert.ToInt32(Codigo));

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

        private void btnEditar_Click(object sender, EventArgs e)
        {

            
            if (!this.txtFolioPurificado.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)

        {
            this.txtFolioPurificado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Folio"].Value);
            
            this.dtFecha_EntradaSodio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha Entrada de Sodio"].Value);
            this.dtFecha_SalidaSodio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha Salida de Sodio"].Value);
            this.txtIdPurificado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Id"].Value);

            this.tabControl1.SelectedIndex = 1;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
