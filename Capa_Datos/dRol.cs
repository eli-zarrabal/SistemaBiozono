﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class dRol
    {
        private int _IdRol;
        private string _Rol;
        private string _TextoBuscar;


        public int IdRol
        {
            get { return _IdRol; }
            set { _IdRol = value; }
        }


        public string Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }



        //Constructores
        public dRol()
        {

        }

        public dRol(int idrol, string rol, string textobuscar)
        {
            this.IdRol = idrol;
            this.Rol = rol;
            this.TextoBuscar = textobuscar;

        }

        //Métodos
        //Insertar
        public string Insertar(dRol Rol)
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
                SqlCmd.CommandText = "p_insertar_roles";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParRol = new SqlParameter();
                ParRol.ParameterName = "@Id_Rol";
                ParRol.SqlDbType = SqlDbType.Int;
                ParRol.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParRol);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Rol";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Rol.Rol;
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
            DataTable DtResultado = new DataTable("roles");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "p_mostrar_roles";
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

    }

    //Método Editar
    //public string Editar(dProducto Producto)
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
    //            SqlCmd.CommandText = "p_editar_producto";
    //            SqlCmd.CommandType = CommandType.StoredProcedure;

    //            SqlParameter ParIdProducto = new SqlParameter();
    //            ParIdProducto.ParameterName = "@IdProducto";
    //            ParIdProducto.SqlDbType = SqlDbType.Int;
    //            ParIdProducto.Value = Producto.IdProducto;
    //            SqlCmd.Parameters.Add(ParIdProducto);



    //            SqlParameter ParNombre = new SqlParameter();
    //            ParNombre.ParameterName = "@Nombre";
    //            ParNombre.SqlDbType = SqlDbType.VarChar;
    //            ParNombre.Size = 255;
    //            ParNombre.Value = Producto.Nombre;
    //            SqlCmd.Parameters.Add(ParNombre);




    //            //Ejecutamos nuestro comando

    //            rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


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