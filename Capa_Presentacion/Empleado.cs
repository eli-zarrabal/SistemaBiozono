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
    public partial class Empleado : Form
    {
     
        private bool IsNuevo = false;
        private bool IsEditar = false;
    //    public int IdRol;


        private static Empleado _Instancia;

        public static Empleado GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new Empleado();
            }
            return _Instancia;
        }




        public Empleado()
        {
            InitializeComponent();
          
            this.Habilitar(false);
        
            this.Botones();
            this.LlenarComboRol();
            this.LlenarComboTipoEmpleado();
        }
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema BIOZONO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Para mostrar mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema BIOZONO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Limpiar()
        {
            this.txtClaveEmpleado.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;

            this.txtDomicilio.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;

            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;

        }
        //Habilita los controles de los formularios
        private void Habilitar(bool Valor)
        {
            this.txtClaveEmpleado.ReadOnly = !Valor;
            this.txtNombre.ReadOnly = !Valor;
            this.txtDomicilio.ReadOnly = !Valor;
            this.cbSexo.Enabled = Valor;

            this.txtTelefono.ReadOnly = !Valor;

            //this.cbAcceso.Enabled = Valor;
            this.txtUsuario.ReadOnly = !Valor;
            this.txtPassword.ReadOnly = !Valor;
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

        private void Mostrar()
        {
            this.dataListado.DataSource = NEmpleado.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NEmpleado.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarCodigo()
        {
            this.dataListado.DataSource = NEmpleado.BuscarCodigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void OcultarColumnas()
        {


               this.dataListado.Columns[0].Visible = false;
               this.dataListado.Columns[1].Visible = false;


            //if (IdRol == 1)
            //{
            //    this.dataListado.Columns[11].Visible = false;
            //    this.dataListado.Columns[12].Visible = false;

            //}

            //else
            //{



            //}






        }
        private void LlenarComboRol()
        {

            cbIdRol.DataSource = NRol.Mostrar();
            cbIdRol.ValueMember = "Id_Rol";
            cbIdRol.DisplayMember = "Rol";


        }

            private void LlenarComboTipoEmpleado()
            {

                cbIdTipoEmpleado.DataSource = NTipoEmpleado.Mostrar();
            cbIdTipoEmpleado.ValueMember = "Id_TipoEmpleado";
            cbIdTipoEmpleado.DisplayMember = "Tipo";


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
            
            if (!this.txtClaveEmpleado.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {

                //La variable que almacena si se inserto 
                //o se modifico la tabla

                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellidoPaterno.Text == string.Empty || txtApellidoPaterno.Text == string.Empty)
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
                      
                        rpta = NEmpleado.Insertar(
                        this.txtClaveEmpleado.Text,
                        this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellidoPaterno.Text.Trim().ToUpper(),
                        this.txtApellidoMaterno.Text.Trim().ToUpper(),
                        this.txtEdad.Text.Trim().ToUpper(),
                        cbSexo.Text,
                        txtTelefono.Text.Trim().ToUpper(),
                        txtDomicilio.Text,
                        Convert.ToInt32(this.cbIdTipoEmpleado.SelectedValue),
                        Convert.ToInt32(this.cbIdRol.SelectedValue),
                        this.txtUsuario.Text,
                        this.txtPassword.Text
                        );


                    }
                    else
                    {
                        //Vamos a modificar un Empleado

                        rpta = NEmpleado.Editar(
                        Convert.ToInt32(this.txtIdEmpleado.Text),
                         this.txtClaveEmpleado.Text,
                        this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellidoPaterno.Text.Trim().ToUpper(),
                        this.txtApellidoMaterno.Text.Trim().ToUpper(),
                        this.txtEdad.Text.Trim().ToUpper(),
                        cbSexo.Text,
                        txtTelefono.Text.Trim().ToUpper(),
                        txtDomicilio.Text,
                        Convert.ToInt32(this.cbIdTipoEmpleado.SelectedValue),
                        Convert.ToInt32(this.cbIdRol.SelectedValue),
                        txtUsuario.Text,
                        txtPassword.Text

                      );


                    }
                    
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se actualizó de forma correcta el registro");
                        }

                    }
                    else
                    {
                        //Mostramos el mensaje de error
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.txtClaveEmpleado.Text = "";

                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Nombre"))
            {
                this.BuscarNombre();
            }
            else if (cbBuscar.Text.Equals("Código"))
            {
                this.BuscarCodigo();
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
                            Rpta = NEmpleado.Eliminar(Convert.ToInt32(Codigo));

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

        private void Empleado_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
          
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdEmpleado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Id Empleado"].Value);
            this.txtClaveEmpleado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Clave de Empleado"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellidoMaterno.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido Paterno"].Value);
            this.txtApellidoPaterno.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido Materno"].Value);
            this.txtEdad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Edad"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Sexo"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Teléfono"].Value);
            this.txtDomicilio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Domicilio"].Value);
            this.cbIdTipoEmpleado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo de Empleado"].Value);
            this.cbIdRol.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Rol"].Value);
            //this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Usuario"].Value);
            //this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Password"].Value);


            this.tabControl1.SelectedIndex = 1;



        }



       

    }
}