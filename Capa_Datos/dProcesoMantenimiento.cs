using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;

namespace Capa_Datos
{
    public class dProcesoMantenimiento
    {
       
        private int _IdMantenimiento;
        private int _IdEmpleado;
        private string _Descripcion;
        private DateTime _Fecha;
        private string _TextoBuscar;


        public int IdMantenimiento
        {
            get { return _IdMantenimiento; }
            set { _IdMantenimiento = value; }
        }
        public int IdEmpleado
        {
            get { return _IdEmpleado; }
            set { _IdEmpleado = value; }
        }


        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
       
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
       
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        public dProcesoMantenimiento()
        {

        }

        public dProcesoMantenimiento(
            int idmantenimiento,
            int idempleado,
            string descripcion,
            DateTime fecha,
            string textobuscar)
        {

            
            this.IdEmpleado = idempleado;
            this.Descripcion = descripcion;
            this.Fecha = fecha;
            this.TextoBuscar = textobuscar;

        }

       
        public string Insertar(dProcesoMantenimiento Mantenimiento)
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
                SqlCmd.CommandText = "p_insertar_proceso_mantenimiento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 300;
                ParDescripcion.Value = Mantenimiento.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Mantenimiento.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@Id_Empleado";
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.Value = Mantenimiento.IdEmpleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);




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

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("mantenimiento");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_mostrar_proceso_mantenimiento";
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


        public DataTable BuscarDescripcion(dProcesoMantenimiento Mantenimiento)
        {
            DataTable DtResultado = new DataTable("mantenimiento");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_buscar_proceso_mantenimiento_descripcion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 300;
                ParTextoBuscar.Value = Mantenimiento.TextoBuscar;
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

        public DataTable BuscarEmpleado(dProcesoMantenimiento Mantenimiento)
        {
            DataTable DtResultado = new DataTable("mantenimiento");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_buscar_proceso_mantenimiento_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 300;
                ParTextoBuscar.Value = Mantenimiento.TextoBuscar;
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


        public string Editar(dProcesoMantenimiento Mantenimiento)
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
                SqlCmd.CommandText = "p_editar_proceso_mantenimiento";
                SqlCmd.CommandType = CommandType.StoredProcedure;



                SqlParameter ParIdMantenimiento = new SqlParameter();
                ParIdMantenimiento.ParameterName = "@Id_Mantenimiento";
                ParIdMantenimiento.SqlDbType = SqlDbType.Int;
                ParIdMantenimiento.Value = Mantenimiento.IdMantenimiento;
                SqlCmd.Parameters.Add(ParIdMantenimiento);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 300;
                ParDescripcion.Value = Mantenimiento.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Mantenimiento.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@Id_Empleado";
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.Value = Mantenimiento.IdEmpleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);


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


        public string Eliminar(dProcesoMantenimiento Mantenimiento)
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
                SqlCmd.CommandText = "p_eliminar_proceso_mantenimiento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMantenimiento = new SqlParameter();
                ParIdMantenimiento.ParameterName = "@Id_Mantenimiento";
                ParIdMantenimiento.SqlDbType = SqlDbType.Int;
                ParIdMantenimiento.Value = Mantenimiento.IdMantenimiento;
                SqlCmd.Parameters.Add(ParIdMantenimiento);


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


    }
}