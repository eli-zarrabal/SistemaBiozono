using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class dTipoEmpleado
    {
        private int _IdTipoEmpleado;
        private string _Tipo;
        private string _TextoBuscar;


        public int IdTipoEmpleado
        {
            get { return _IdTipoEmpleado; }
            set { _IdTipoEmpleado = value; }
        }


        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }



        //Constructores
        public dTipoEmpleado()
        {

        }

        public dTipoEmpleado(int idtipoempleado, string tipo, string textobuscar)
        {
            this.IdTipoEmpleado = idtipoempleado;
            this.Tipo = tipo;
            this.TextoBuscar = textobuscar;

        }

        //Métodos
        //Insertar
        public string Insertar(dTipoEmpleado TipoEmpleado)
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
                SqlCmd.CommandText = "p_insertar_tipoempleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParRol = new SqlParameter();
                ParRol.ParameterName = "@Id_TipoEmpleado";
                ParRol.SqlDbType = SqlDbType.Int;
                ParRol.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParRol);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Tipo";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = TipoEmpleado.Tipo;
                SqlCmd.Parameters.Add(ParNombre);



                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


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
            DataTable DtResultado = new DataTable("tipoempleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_mostrar_tipoempleado";
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



        public string Editar(dTipoEmpleado TipoEmpleado)
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
                SqlCmd.CommandText = "p_editar_tipoempleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTipoEmpleado = new SqlParameter();
                ParTipoEmpleado.ParameterName = "@Id_TipoEmpleado";
                ParTipoEmpleado.SqlDbType = SqlDbType.Int;
                ParTipoEmpleado.Value = TipoEmpleado.IdTipoEmpleado;
                SqlCmd.Parameters.Add(ParTipoEmpleado);



                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@Tipo";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParTipo.Size = 255;
                ParTipo.Value = TipoEmpleado.Tipo;
                SqlCmd.Parameters.Add(ParTipo);




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


        //    //Método Mostrar
        //    public DataTable Mostrar()
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



        //    }


        //    public string Eliminar(dProducto Producto)
        //    {
        //        string rpta = "";
        //        SqlConnection SqlCon = new SqlConnection();
        //        try
        //        {
        //            //Código
        //            SqlCon.ConnectionString = Conexion.Cn;
        //            SqlCon.Open();
        //            //Establecer el Comando
        //            SqlCommand SqlCmd = new SqlCommand();
        //            SqlCmd.Connection = SqlCon;
        //            SqlCmd.CommandText = "p_eliminar_producto";
        //            SqlCmd.CommandType = CommandType.StoredProcedure;

        //            SqlParameter parIdProducto = new SqlParameter();
        //            parIdProducto.ParameterName = "@IdProducto";
        //            parIdProducto.SqlDbType = SqlDbType.Int;
        //            parIdProducto.Value = Producto.IdProducto;
        //            SqlCmd.Parameters.Add(parIdProducto);


        //            //Ejecutamos nuestro comando

        //            rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


        //        }
        //        catch (Exception ex)
        //        {
        //            rpta = ex.Message;
        //        }
        //        finally
        //        {
        //            if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
        //        }
        //        return rpta;
        //    }

        //}
    }

}