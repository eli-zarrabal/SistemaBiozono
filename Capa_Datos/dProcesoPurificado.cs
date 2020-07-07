using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class dProcesoPurificado
    {
        //Variables

        private int _IdPurificado;
        private int _IdEmpleado;
        private DateTime _FechaEntradaSodio;
        private DateTime _FechaSalidaSodio;
        private string _FolioPurificacion;
        private string _TextoBuscar;



        public int IdEmpleado
        {
            get { return _IdEmpleado; }
            set { _IdEmpleado = value; }
        }
        public DateTime FechaEntradaSodio
        {
            get { return _FechaEntradaSodio; }
            set { _FechaEntradaSodio = value; }
        }

        public DateTime FechaSalidaSodio
        {
            get { return _FechaSalidaSodio; }
            set { _FechaSalidaSodio = value; }
        }
        public string FolioPurificacion
        {
            get { return _FolioPurificacion; }
            set { _FolioPurificacion = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public int IdPurificado
        {
            get { return _IdPurificado; }
            set { _IdPurificado = value; }
        }


        //Constructores
        public dProcesoPurificado()
        {

        }

        public dProcesoPurificado(
            int idpurificacion,
            int idempleado,
            DateTime fechaentradasodio,
            DateTime fechasalidasodio,
            string foliopurificacion,
            string textobuscar)
        {
            this.IdEmpleado = idempleado;
            this.FechaEntradaSodio = fechaentradasodio;
            this.FechaSalidaSodio = fechasalidasodio;
            this.FolioPurificacion = foliopurificacion;
            this.TextoBuscar = textobuscar;

        }

        //Métodos
        //Insertar
        public string Insertar(dProcesoPurificado Purificado)
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
                SqlCmd.CommandText = "p_insertar_proceso_purificado";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@Id_Empleado";
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.Value = Purificado.IdEmpleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParFecha_EntradaSodio = new SqlParameter();
                ParFecha_EntradaSodio.ParameterName = "@Fecha_EntradaSodio";
                ParFecha_EntradaSodio.SqlDbType = SqlDbType.Date;
                ParFecha_EntradaSodio.Value = Purificado.FechaEntradaSodio;
                SqlCmd.Parameters.Add(ParFecha_EntradaSodio);


                SqlParameter ParFecha_SalidaSodio = new SqlParameter();
                ParFecha_SalidaSodio.ParameterName = "@Fecha_SalidaSodio";
                ParFecha_SalidaSodio.SqlDbType = SqlDbType.Date;
                ParFecha_SalidaSodio.Value = Purificado.FechaSalidaSodio;
                SqlCmd.Parameters.Add(ParFecha_SalidaSodio);

                SqlParameter ParFolio_Purificacion = new SqlParameter();
                ParFolio_Purificacion.ParameterName = "@Folio_Purificacion";
                ParFolio_Purificacion.SqlDbType = SqlDbType.VarChar;
                ParFolio_Purificacion.Size = 20;
                ParFolio_Purificacion.Value = Purificado.FolioPurificacion;
                SqlCmd.Parameters.Add(ParFolio_Purificacion);


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

        

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("purificado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_mostrar_proceso_purificado";
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

    
        public DataTable BuscarFolio(dProcesoPurificado Purificado)
        {
            DataTable DtResultado = new DataTable("purificado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_buscar_proceso_purificado_folio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Purificado.TextoBuscar;
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
        public DataTable BuscarEmpleado(dProcesoPurificado Purificado)
        {
            DataTable DtResultado = new DataTable("purificado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_buscar_proceso_purificado_nombre_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Purificado.TextoBuscar;
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

        //Método Eliminar
        public string Eliminar(dProcesoPurificado Purificado)
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
                SqlCmd.CommandText = "p_eliminar_proceso_purificado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@Id_Purificacion";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Purificado.IdPurificado;
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


        //Método Editar
        public string Editar(dProcesoPurificado Purificado)
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
                SqlCmd.CommandText = "p_editar_proceso_purificado";
                SqlCmd.CommandType = CommandType.StoredProcedure;



                SqlParameter ParIdPurificado = new SqlParameter();
                ParIdPurificado.ParameterName = "@Id_Purificacion";
                ParIdPurificado.SqlDbType = SqlDbType.Int;
                ParIdPurificado.Value = Purificado.IdPurificado;
                SqlCmd.Parameters.Add(ParIdPurificado);

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@Id_Empleado";
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.Value = Purificado.IdEmpleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParFecha_EntradaSodio = new SqlParameter();
                ParFecha_EntradaSodio.ParameterName = "@Fecha_EntradaSodio";
                ParFecha_EntradaSodio.SqlDbType = SqlDbType.Date;
                ParFecha_EntradaSodio.Value = Purificado.FechaEntradaSodio;
                SqlCmd.Parameters.Add(ParFecha_EntradaSodio);


                SqlParameter ParFecha_SalidaSodio = new SqlParameter();
                ParFecha_SalidaSodio.ParameterName = "@Fecha_SalidaSodio";
                ParFecha_SalidaSodio.SqlDbType = SqlDbType.Date;
                ParFecha_SalidaSodio.Value = Purificado.FechaSalidaSodio;
                SqlCmd.Parameters.Add(ParFecha_SalidaSodio);

                SqlParameter ParFolio_Purificacion = new SqlParameter();
                ParFolio_Purificacion.ParameterName = "@Folio_Purificacion";
                ParFolio_Purificacion.SqlDbType = SqlDbType.VarChar;
                ParFolio_Purificacion.Size = 20;
                ParFolio_Purificacion.Value = Purificado.FolioPurificacion;
                SqlCmd.Parameters.Add(ParFolio_Purificacion);



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





    }
}