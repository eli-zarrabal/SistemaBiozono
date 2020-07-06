using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class dEmpleado
    {
        //Variables
        private int _IdEmpleado;
        private string _CodigoEmpleado;
        private string _Nombre;
        private string _Apellido_Paterno;
        private string _Apellido_Materno;
        private string _Edad;
        private string _Sexo;
        private string _Telefono;
        private string _Domicilio;
        private int _TipoEmpleado;
        private int _Rol;
        //private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;

        public int IdEmpleado
        {
            get { return _IdEmpleado; }
            set { _IdEmpleado = value; }
        }
        public string CodigoEmpleado
        {
            get { return _CodigoEmpleado; }
            set { _CodigoEmpleado = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Apellido_Paterno
        {
            get { return _Apellido_Paterno; }
            set { _Apellido_Paterno = value; }
        }
        public string Apellido_Materno
        {
            get { return _Apellido_Materno; }
            set { _Apellido_Materno = value; }
        }
        public string Edad
        {
            get { return _Edad; }
            set { _Edad = value; }
        }



        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public string Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }
        }


        public int TipoEmpleado
        {
            get { return _TipoEmpleado; }
            set { _TipoEmpleado = value; }
        }

        public int Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }


        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores
        public dEmpleado()
        {

        }

        public dEmpleado(int idempleado,
            string codigoempleado,
            string nombre,
            string apellidopaterno,
            string apellidomaterno,
            string edad,
            string sexo,
            string telefono,
            string domicilio,
            int tipoempleado,
            int rol,
            string usuario,
            string password,
            string textobuscar)
        {
            this.IdEmpleado = idempleado;
            this.CodigoEmpleado = codigoempleado;
            this.Nombre = nombre;
            this.Apellido_Paterno = apellidopaterno;
            this.Apellido_Materno = apellidomaterno;
            this.Edad = edad;
            this.Sexo = sexo;
            this.Telefono = telefono;
            this.Domicilio = domicilio;
            this.TipoEmpleado = tipoempleado;
            this.Rol = rol;
            //  this.Acceso = acceso;
             this.Usuario = usuario;
             this.Password = password;
            this.TextoBuscar = textobuscar;

        }

        //Métodos
        //Insertar
        public string Insertar(dEmpleado Empleado)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_insertar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@Codigo_Empleado";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 10;
                ParCodigo.Value = Empleado.CodigoEmpleado;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 20;
                ParNombre.Value = Empleado.Nombre;
                SqlCmd.Parameters.Add(ParNombre);


                SqlParameter ParApellidoPaterno = new SqlParameter();
                ParApellidoPaterno.ParameterName = "@Apellido_Paterno";
                ParApellidoPaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoPaterno.Size = 50;
                ParApellidoPaterno.Value = Empleado.Apellido_Paterno;
                SqlCmd.Parameters.Add(ParApellidoPaterno);

                SqlParameter ParApellidoMaterno = new SqlParameter();
                ParApellidoMaterno.ParameterName = "@Apellido_Materno";
                ParApellidoMaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoMaterno.Size = 50;
                ParApellidoMaterno.Value = Empleado.Apellido_Materno;
                SqlCmd.Parameters.Add(ParApellidoMaterno);

                SqlParameter ParEdad = new SqlParameter();
                ParEdad.ParameterName = "@Edad";
                ParEdad.SqlDbType = SqlDbType.VarChar;
                ParEdad.Size = 20;
                ParEdad.Value = Empleado.Edad;
                SqlCmd.Parameters.Add(ParEdad);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@Sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Empleado.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Empleado.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParDomicilio = new SqlParameter();
                ParDomicilio.ParameterName = "@Domicilio";
                ParDomicilio.SqlDbType = SqlDbType.VarChar;
                ParDomicilio.Size = 100;
                ParDomicilio.Value = Empleado.Domicilio;
                SqlCmd.Parameters.Add(ParDomicilio);

                SqlParameter ParTipoEmpleado = new SqlParameter();
                ParTipoEmpleado.ParameterName = "@Id_TipoEmpleado";
                ParTipoEmpleado.SqlDbType = SqlDbType.VarChar;
                ParTipoEmpleado.Value = Empleado.TipoEmpleado;
                SqlCmd.Parameters.Add(ParTipoEmpleado);

                SqlParameter ParRol = new SqlParameter();
                ParRol.ParameterName = "@Id_Rol";
                ParRol.SqlDbType = SqlDbType.VarChar;
                ParRol.Value = Empleado.Rol;
                SqlCmd.Parameters.Add(ParRol);


                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Empleado.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@Password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Empleado.Password;
                SqlCmd.Parameters.Add(ParPassword);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        //Método Editar
        public string Editar(dEmpleado Empleado)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_editar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParEmpleado = new SqlParameter();
                ParEmpleado.ParameterName = "@Id_Empleado";
                ParEmpleado.SqlDbType = SqlDbType.Int;
                ParEmpleado.Value = Empleado.IdEmpleado;
                SqlCmd.Parameters.Add(ParEmpleado);


                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@Codigo_Empleado";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 10;
                ParCodigo.Value = Empleado.CodigoEmpleado;
                SqlCmd.Parameters.Add(ParCodigo);


                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 20;
                ParNombre.Value = Empleado.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidoPaterno = new SqlParameter();
                ParApellidoPaterno.ParameterName = "@Apellido_Paterno";
                ParApellidoPaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoPaterno.Size = 50;
                ParApellidoPaterno.Value = Empleado.Apellido_Paterno;
                SqlCmd.Parameters.Add(ParApellidoPaterno);

                SqlParameter ParApellidoMaterno = new SqlParameter();
                ParApellidoMaterno.ParameterName = "@Apellido_Materno";
                ParApellidoMaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoMaterno.Size = 50;
                ParApellidoMaterno.Value = Empleado.Apellido_Materno;
                SqlCmd.Parameters.Add(ParApellidoMaterno);

                SqlParameter ParEdad = new SqlParameter();
                ParEdad.ParameterName = "@Edad";
                ParEdad.SqlDbType = SqlDbType.VarChar;
                ParEdad.Size = 20;
                ParEdad.Value = Empleado.Edad;
                SqlCmd.Parameters.Add(ParEdad);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@Sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Empleado.Sexo;
                SqlCmd.Parameters.Add(ParSexo);


                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Empleado.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParDomicilio = new SqlParameter();
                ParDomicilio.ParameterName = "@Domicilio";
                ParDomicilio.SqlDbType = SqlDbType.VarChar;
                ParDomicilio.Size = 100;
                ParDomicilio.Value = Empleado.Domicilio;
                SqlCmd.Parameters.Add(ParDomicilio);


                SqlParameter ParTipoEmpleado = new SqlParameter();
                ParTipoEmpleado.ParameterName = "@Id_TipoEmpleado";
                ParTipoEmpleado.SqlDbType = SqlDbType.VarChar;
                ParTipoEmpleado.Size = 50;
                ParTipoEmpleado.Value = Empleado.TipoEmpleado;
                SqlCmd.Parameters.Add(ParTipoEmpleado);

                SqlParameter ParRol = new SqlParameter();
                ParRol.ParameterName = "@Id_Rol";
                ParRol.SqlDbType = SqlDbType.VarChar;
                ParRol.Size = 50;
                ParRol.Value = Empleado.Rol;
                SqlCmd.Parameters.Add(ParRol);

                SqlParameter parusuario = new SqlParameter();
                parusuario.ParameterName = "@Usuario";
                parusuario.SqlDbType = SqlDbType.VarChar;
                parusuario.Size = 50;
                parusuario.Value = Empleado.Usuario;
                SqlCmd.Parameters.Add(parusuario);

                SqlParameter parpassword = new SqlParameter();
                parpassword.ParameterName = "@Password";
                parpassword.SqlDbType = SqlDbType.VarChar;
                parpassword.Size = 50;
                parpassword.Value = Empleado.Password;
                SqlCmd.Parameters.Add(parpassword);

              


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Eliminar
        //public string Eliminar(DTrabajador Trabajador)
        //{
        //    string rpta = "";
        //    SqlConnection SqlCon = new SqlConnection();
        //    try
        //    {
        //        //Código
        //        SqlCon.ConnectionString = Conexion.Cn;
        //        SqlCon.Open();
        //        //Establecer el Comando
        //        SqlCommand SqlCmd = new SqlCommand();
        //        SqlCmd.Connection = SqlCon;
        //        SqlCmd.CommandText = "speliminar_trabajador";
        //        SqlCmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter ParIdtrabajador = new SqlParameter();
        //        ParIdtrabajador.ParameterName = "@idtrabajador";
        //        ParIdtrabajador.SqlDbType = SqlDbType.Int;
        //        ParIdtrabajador.Value = Trabajador.Idtrabajador;
        //        SqlCmd.Parameters.Add(ParIdtrabajador);


        //        //Ejecutamos nuestro comando

        //        rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


        //    }
        //    catch (Exception ex)
        //    {
        //        rpta = ex.Message;
        //    }
        //    finally
        //    {
        //        if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
        //    }
        //    return rpta;


        //Método Mostrar
        //public DataTable Mostrar()
        //    {
        //        DataTable DtResultado = new DataTable("producto");
        //        SqlConnection SqlCon = new SqlConnection();
        //        try
        //        {
        //            SqlCon.ConnectionString = Conexion.Cn;
        //            SqlCommand SqlCmd = new SqlCommand();
        //            SqlCmd.Connection = SqlCon;
        //            SqlCmd.CommandText = "p_mostrar_producto";
        //            SqlCmd.CommandType = CommandType.StoredProcedure;

        //            SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
        //            SqlDat.Fill(DtResultado);

        //        }
        //        catch (Exception ex)
        //        {
        //            DtResultado = null;
        //        }
        //        return DtResultado;

        //    }

        //    //Método BuscarNombre
        //    public DataTable BuscarNombre(dProducto Producto)
        //    {
        //        DataTable DtResultado = new DataTable("producto");
        //        SqlConnection SqlCon = new SqlConnection();
        //        try
        //        {
        //            SqlCon.ConnectionString = Conexion.Cn;
        //            SqlCommand SqlCmd = new SqlCommand();
        //            SqlCmd.Connection = SqlCon;
        //            SqlCmd.CommandText = "p_consultar_producto";
        //            SqlCmd.CommandType = CommandType.StoredProcedure;

        //            SqlParameter ParTextoBuscar = new SqlParameter();
        //            ParTextoBuscar.ParameterName = "@textobuscar";
        //            ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
        //            ParTextoBuscar.Size = 50;
        //            ParTextoBuscar.Value = Producto.TextoBuscar;
        //            SqlCmd.Parameters.Add(ParTextoBuscar);

        //            SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
        //            SqlDat.Fill(DtResultado);

        //        }
        //        catch (Exception ex)
        //        {
        //            DtResultado = null;
        //        }
        //        return DtResultado;



        //Método Eliminar
        public string Eliminar(dEmpleado Empleado)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_eliminar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParEmpleado = new SqlParameter();
                ParEmpleado.ParameterName = "@Id_Empleado";
                ParEmpleado.SqlDbType = SqlDbType.Int;
                ParEmpleado.Value = Empleado.IdEmpleado;
                SqlCmd.Parameters.Add(ParEmpleado);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }


        //}
        //Método BuscarApellidos
        public DataTable BuscarNombre(dEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_buscar_empleado_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Empleado.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public DataTable BuscarCodigo(dEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_buscar_empleado_codigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Empleado.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_mostrar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public DataTable Login(dEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_Login";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empleado.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@Password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Empleado.Password;
                SqlCmd.Parameters.Add(ParPassword);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    
}
}