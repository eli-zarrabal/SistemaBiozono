using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class dCliente
    {
        //Variables
        private int _Idcliente;

        private string _Nombre;

        private string _ApellidoPaterno;

        private string _ApellidoMaterno;

        private string _Direccion;

        private string _Localidad;

        private string _ClaveCliente;

    

        private string _TextoBuscar;


        //Propiedades Métodos Setter and Getter

        public int Idcliente
        {
            get { return _Idcliente; }
            set { _Idcliente = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string ApellidoPaterno
        {
            get { return _ApellidoPaterno; }
            set { _ApellidoPaterno = value; }
        }
        public string ApellidoMaterno
        {
            get { return _ApellidoMaterno; }
            set { _ApellidoMaterno = value; }
        }


        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        public string Localidad
        {
            get { return _Localidad; }
            set { _Localidad = value; }
        }

        public string Clave_Cliente
        {
            get { return _ClaveCliente; }
            set { _ClaveCliente = value; }
        }


        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores
        public dCliente()
        {

        }
        public dCliente(
            int idcliente, 
            string nombre,
            string apellidopaterno, 
            string apellidomaterno,
            string direccion,
            string localidad,
            string clavecliente,
            string textobuscar)
        {
            this.Idcliente = idcliente;
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidopaterno;
            this.ApellidoMaterno = apellidomaterno;
            this.Direccion = direccion;
            this.Localidad = localidad;
            this.Clave_Cliente = clavecliente;
            this.TextoBuscar = textobuscar;

        }

        //Métodos


        public string Insertar(dCliente Cliente)
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
                SqlCmd.CommandText = "p_insertar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidoPaterno = new SqlParameter();
                ParApellidoPaterno.ParameterName = "@apellido_Paterno";
                ParApellidoPaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoPaterno.Size = 50;
                ParApellidoPaterno.Value = Cliente.ApellidoPaterno;
                SqlCmd.Parameters.Add(ParApellidoPaterno);

                SqlParameter ParApellidoMaterno = new SqlParameter();
                ParApellidoMaterno.ParameterName = "@Apellido_Materno";
                ParApellidoMaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoMaterno.Size = 50;
                ParApellidoMaterno.Value = Cliente.ApellidoMaterno;
                SqlCmd.Parameters.Add(ParApellidoMaterno);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 255; ;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParLocalidad = new SqlParameter();
                ParLocalidad.ParameterName = "@Localidad";
                ParLocalidad.SqlDbType = SqlDbType.VarChar;
                ParLocalidad.Size = 255;
                ParLocalidad.Value = Cliente.Localidad;
                SqlCmd.Parameters.Add(ParLocalidad);

                SqlParameter ParClaveCliente = new SqlParameter();
                ParClaveCliente.ParameterName = "@Clave_Cliente";
                ParClaveCliente.SqlDbType = SqlDbType.VarChar;
                ParClaveCliente.Size = 255;
                ParClaveCliente.Value = Cliente.Clave_Cliente;
                SqlCmd.Parameters.Add(ParClaveCliente);

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
        public string Editar(dCliente Cliente)
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
                SqlCmd.CommandText = "p_editar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@Id_Cliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidoPaterno = new SqlParameter();
                ParApellidoPaterno.ParameterName = "@apellido_Paterno";
                ParApellidoPaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoPaterno.Size = 50;
                ParApellidoPaterno.Value = Cliente.ApellidoPaterno;
                SqlCmd.Parameters.Add(ParApellidoPaterno);

                SqlParameter ParApellidoMaterno = new SqlParameter();
                ParApellidoMaterno.ParameterName = "@Apellido_Materno";
                ParApellidoMaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoMaterno.Size = 50;
                ParApellidoMaterno.Value = Cliente.ApellidoMaterno;
                SqlCmd.Parameters.Add(ParApellidoMaterno);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 255; ;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParLocalidad = new SqlParameter();
                ParLocalidad.ParameterName = "@Localidad";
                ParLocalidad.SqlDbType = SqlDbType.VarChar;
                ParLocalidad.Size = 255;
                ParLocalidad.Value = Cliente.Localidad;
                SqlCmd.Parameters.Add(ParLocalidad);

                SqlParameter ParClaveCliente = new SqlParameter();
                ParClaveCliente.ParameterName = "@Clave_Cliente";
                ParClaveCliente.SqlDbType = SqlDbType.VarChar;
                ParClaveCliente.Size = 255;
                ParClaveCliente.Value = Cliente.Clave_Cliente;
                SqlCmd.Parameters.Add(ParClaveCliente);



                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el Registro";


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
        public string Eliminar(dCliente Cliente)
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
                SqlCmd.CommandText = "p_eliminar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@Id_Cliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el Registro";


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

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_mostrar_cliente";
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


        //Método BuscarNombre
        public DataTable BuscarNombre(dCliente Cliente)
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_buscar_cliente_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;
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




        public DataTable BuscarLocalidad(dCliente Cliente)
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_buscar_cliente_localidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;
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


    }
}