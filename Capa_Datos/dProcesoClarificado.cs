using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Capa_Datos
{
    public class dProcesoClarificado
    {
        //Variables

        private int _IdClarificado;
        private int _IdEmpleado;
        private string _LecturaAnterior;
        private int _Cantidad;
        private DateTime _Fecha;
        private string _FolioClarificado;
        private string _TextoBuscar;


        public int IdClarificado
        {
            get { return _IdClarificado; }
            set { _IdClarificado = value; }
        }
        public int IdEmpleado
        {
            get { return _IdEmpleado; }
            set { _IdEmpleado = value; }
        }
       
        
        public string LecturaAnterior
        {
            get { return _LecturaAnterior; }
            set { _LecturaAnterior = value; }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public string FolioClarificado
        {
            get { return _FolioClarificado; }
            set { _FolioClarificado = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        


        //Constructores
        public dProcesoClarificado()
        {

        }

        public dProcesoClarificado(
            int idclarificado,
            int idempleado,
            string lecturaanterior,
            int cantidad,
            DateTime fecha,
            string folioclarificado,
            string textobuscar)
        {
          
            this.IdEmpleado = idempleado;
            this.LecturaAnterior = lecturaanterior;
            this.Cantidad = cantidad;
            this.Fecha = fecha;
            this.FolioClarificado = folioclarificado;
            this.TextoBuscar = textobuscar;

        }

        //Métodos
        //Insertar
        public string Insertar(dProcesoClarificado Clarificado)
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
                SqlCmd.CommandText = "p_insertar_proceso_clarificado";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@Id_Empleado";
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.Value = Clarificado.IdEmpleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParLecturaAnterior = new SqlParameter();
                ParLecturaAnterior.ParameterName = "@Lectura_Anterior";
                ParLecturaAnterior.SqlDbType = SqlDbType.VarChar;
                ParLecturaAnterior.Size = 20;
                ParLecturaAnterior.Value = Clarificado.LecturaAnterior;
                SqlCmd.Parameters.Add(ParLecturaAnterior);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.VarChar;
                ParCantidad.SqlDbType = SqlDbType.VarChar;
                ParCantidad.Value = Clarificado.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Clarificado.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParFolio = new SqlParameter();
                ParFolio.ParameterName = "@Folio_Clarificado";
                ParFolio.SqlDbType = SqlDbType.VarChar;
                ParFolio.Size = 20;
                ParFolio.Value = Clarificado.FolioClarificado;
                SqlCmd.Parameters.Add(ParFolio);




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
            DataTable DtResultado = new DataTable("clarificado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_mostrar_proceso_clarificado";
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

        public DataTable BuscarFolio(dProcesoClarificado Clarificado)
        {
            DataTable DtResultado = new DataTable("clarificado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_buscar_proceso_clarificado_folio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Clarificado.TextoBuscar;
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

        public DataTable BuscarEmpleado(dProcesoClarificado Clarificado)
        {
            DataTable DtResultado = new DataTable("clarificado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_buscar_proceso_clarificado_nombre_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Clarificado.TextoBuscar;
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
        //public DataTable BuscarCantidad(dProcesoClarificado Clarificado)
        //{
        //    DataTable DtResultado = new DataTable("clarificado");
        //    SqlConnection SqlCon = new SqlConnection();
        //    try
        //    {
        //        SqlCon.ConnectionString = Conexion.Cn;
        //        SqlCommand SqlCmd = new SqlCommand();
        //        SqlCmd.Connection = SqlCon;
        //        SqlCmd.CommandText = "p_buscar_proceso_clarificado_cantidad";
        //        SqlCmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter ParTextoBuscar = new SqlParameter();
        //        ParTextoBuscar.ParameterName = "@textobuscar";
        //        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
        //        ParTextoBuscar.Size = 50;
        //        ParTextoBuscar.Value = Clarificado.TextoBuscar;
        //        SqlCmd.Parameters.Add(ParTextoBuscar);

        //        SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
        //        SqlDat.Fill(DtResultado);

        //    }
        //    catch (Exception ex)
        //    {
        //        DtResultado = null;
        //    }
        //    return DtResultado;

        //}
        //public DataTable BuscarLecturaAnterior(dProcesoClarificado Clarificado)
        //{
        //    DataTable DtResultado = new DataTable("clarificado");
        //    SqlConnection SqlCon = new SqlConnection();
        //    try
        //    {
        //        SqlCon.ConnectionString = Conexion.Cn;
        //        SqlCommand SqlCmd = new SqlCommand();
        //        SqlCmd.Connection = SqlCon;
        //        SqlCmd.CommandText = "p_buscar_proceso_clarificado_lectura_anterior";
        //        SqlCmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter ParTextoBuscar = new SqlParameter();
        //        ParTextoBuscar.ParameterName = "@textobuscar";
        //        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
        //        ParTextoBuscar.Size = 50;
        //        ParTextoBuscar.Value = Clarificado.TextoBuscar;
        //        SqlCmd.Parameters.Add(ParTextoBuscar);

        //        SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
        //        SqlDat.Fill(DtResultado);

        //    }
        //    catch (Exception ex)
        //    {
        //        DtResultado = null;
        //    }
        //    return DtResultado;

        //}
        //Método Editar
        public string Editar(dProcesoClarificado Clarificado)
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
                SqlCmd.CommandText = "p_editar_proceso_clarificado";
                SqlCmd.CommandType = CommandType.StoredProcedure;



                SqlParameter ParIdClarificado = new SqlParameter();
                ParIdClarificado.ParameterName = "@Id_Clarificado";
                ParIdClarificado.SqlDbType = SqlDbType.Int;
                ParIdClarificado.Value = Clarificado.IdClarificado;
                SqlCmd.Parameters.Add(ParIdClarificado);



                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@Id_Empleado";
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.SqlDbType = SqlDbType.VarChar;
                ParIdEmpleado.Value = Clarificado.IdEmpleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParLecturaAnterior = new SqlParameter();
                ParLecturaAnterior.ParameterName = "@Lectura_Anterior";
                ParLecturaAnterior.SqlDbType = SqlDbType.VarChar;
                ParLecturaAnterior.Size = 20;
                ParLecturaAnterior.Value = Clarificado.LecturaAnterior;
                SqlCmd.Parameters.Add(ParLecturaAnterior);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.VarChar;
                ParCantidad.SqlDbType = SqlDbType.VarChar;
                ParCantidad.Value = Clarificado.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);


                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Clarificado.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParFolio = new SqlParameter();
                ParFolio.ParameterName = "@Folio_Clarificado";
                ParFolio.SqlDbType = SqlDbType.VarChar;
                ParFolio.Size = 20;
                ParFolio.Value = Clarificado.FolioClarificado;
                SqlCmd.Parameters.Add(ParFolio);



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


        public string Eliminar(dProcesoClarificado Clarificado)
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
                SqlCmd.CommandText = "p_eliminar_proceso_clarificado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdClarificado = new SqlParameter();
                ParIdClarificado.ParameterName = "@Id_Clarificado";
                ParIdClarificado.SqlDbType = SqlDbType.Int;
                ParIdClarificado.Value = Clarificado.IdClarificado;
                SqlCmd.Parameters.Add(ParIdClarificado);


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