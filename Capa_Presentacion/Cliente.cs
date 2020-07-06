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
    public partial class Cliente : Form
    {
        

        private bool IsNuevo = false;
        private bool IsEditar = false;
        public Cliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtApellidoPaterno, "Ingrese el Apellido Paterno del Cliente");
            this.ttMensaje.SetToolTip(this.txtApellidoMaterno, "Ingrese el Apellido Materno del Cliente");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Dirección del Cliente");
            this.ttMensaje.SetToolTip(this.txtLocalidad, "Ingrese la Localidad del Cliente");
            this.txtIdCliente.Visible = false;
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema BIOZONO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema BIOZONO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;
            this.txtApellidoMaterno.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtLocalidad.Text = string.Empty;
            this.txtClave_Cliente.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidoPaterno.ReadOnly = !valor;
            this.txtApellidoMaterno.ReadOnly = !valor;
            this.txtDireccion.Enabled = valor;
            this.txtLocalidad.ReadOnly = !valor;
            this.txtClave_Cliente.ReadOnly = !valor;
          
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
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

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

     //   Método Mostrar
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

        //Método BuscarNum_Documento
        private void BuscarLocalidad()
        {
            this.dataListado.DataSource = NCliente.BuscarLocalidad(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }




        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                string rpta = "";
                if (
                    this.txtNombre.Text == string.Empty || this.txtApellidoMaterno.Text == string.Empty ||
                    this.txtApellidoPaterno.Text == string.Empty
                  )
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtApellidoPaterno, "Ingrese un Valor");
                    errorIcono.SetError(txtApellidoMaterno, "Ingrese un Valor");
               
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NCliente.Insertar(
                            this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidoPaterno.Text.Trim().ToUpper(),
                            this.txtApellidoMaterno.Text.Trim().ToUpper(),
                            txtDireccion.Text,
                            txtLocalidad.Text,
                            txtClave_Cliente.Text
                            );

                    }
                    else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdCliente.Text),
                            this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidoPaterno.Text.Trim().ToUpper(),
                            this.txtApellidoMaterno.Text.Trim().ToUpper(),
                            txtDireccion.Text,
                            txtLocalidad.Text,
                            txtClave_Cliente.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
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


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtClave_Cliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            this.txtClave_Cliente.Text = string.Empty;
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
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
        private void Cliente_Load(object sender, EventArgs e)
        {
          
            this.Top = 0;
            this.Left = 0;
           
            this.Mostrar();
        
            this.Habilitar(false);
      
            this.Botones();
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
                            Rpta = NCliente.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
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
            this.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Id Cliente"].Value);
            this.txtClave_Cliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Clave de Cliente"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellidoPaterno.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido Paterno"].Value);
            this.txtApellidoMaterno.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido Materno"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Dirección"].Value);
            this.txtLocalidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Localidad"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
