using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class dDetalleVenta
    {
        private int _Iddetalle_venta;
        private int _Idventa;
        private int _Iddetalle_Ingreso;
        private int _Cantidad;
        private decimal _Precio_Venta;
      
        public int Iddetalle_venta
        {
            get { return _Iddetalle_venta; }
            set { _Iddetalle_venta = value; }
        }

        public int Idventa
        {
            get { return _Idventa; }
            set { _Idventa = value; }
        }

        public int Iddetalle_Ingreso
        {
            get { return _Iddetalle_Ingreso; }
            set { _Iddetalle_Ingreso = value; }
        }


        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public decimal Precio_Venta
        {
            get { return _Precio_Venta; }
            set { _Precio_Venta = value; }
        }


       

        //Constructores
        public dDetalleVenta()
        {

        }

        public dDetalleVenta(int iddetalle_venta, int idventa, int iddetalle_ingreso, int cantidad, decimal precio_venta
            )
        {
            this.Iddetalle_venta = iddetalle_venta;
            this.Idventa = idventa;
            this.Iddetalle_Ingreso = iddetalle_ingreso;
            this.Cantidad = cantidad;
            this.Precio_Venta = precio_venta;
         

        }
        public string Insertar(dDetalleVenta Detalle_Venta, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "p_insertar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_venta = new SqlParameter();
                ParIddetalle_venta.ParameterName = "@Id_DetalleVenta";
                ParIddetalle_venta.SqlDbType = SqlDbType.Int;
                ParIddetalle_venta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_venta);

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@Id_Venta";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Detalle_Venta.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@Id_DetalleIngreso";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Value = Detalle_Venta.Iddetalle_Ingreso;
                SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle_Venta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio_Venta = new SqlParameter();
                ParPrecio_Venta.ParameterName = "@Precio_Venta";
                ParPrecio_Venta.SqlDbType = SqlDbType.Money;
                ParPrecio_Venta.Value = Detalle_Venta.Precio_Venta;
                SqlCmd.Parameters.Add(ParPrecio_Venta);

               

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : Convert.ToString(Idventa) + Convert.ToString(Iddetalle_Ingreso) + Convert.ToString(Cantidad) + Convert.ToString(Precio_Venta);

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }

    }
    //Método Insertar
    //public string Insertar(dDetalleVenta Detalle_Venta,
    //    ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
    //{
    //    string rpta = "";
    //    try
    //    {

    //        //Establecer el Comando
    //        SqlCommand SqlCmd = new SqlCommand();
    //        SqlCmd.Connection = SqlCon;
    //        SqlCmd.Transaction = SqlTra;
    //        SqlCmd.CommandText = "p_insertar_detalle_venta";
    //        SqlCmd.CommandType = CommandType.StoredProcedure;

    //        SqlParameter ParIddetalle_Venta = new SqlParameter();
    //        ParIddetalle_Venta.ParameterName = "@Id_DetalleVenta";
    //        ParIddetalle_Venta.SqlDbType = SqlDbType.Int;
    //        ParIddetalle_Venta.Direction = ParameterDirection.Output;
    //        SqlCmd.Parameters.Add(ParIddetalle_Venta);

    //        SqlParameter ParIdventa = new SqlParameter();
    //        ParIdventa.ParameterName = "@Id_Venta";
    //        ParIdventa.SqlDbType = SqlDbType.Int;
    //        ParIdventa.Value = Detalle_Venta.Idventa;
    //        SqlCmd.Parameters.Add(ParIdventa);

    //        SqlParameter ParIddetalle_ingreso = new SqlParameter();
    //        ParIddetalle_ingreso.ParameterName = "@Id_DetalleIngreso";
    //        ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
    //        ParIddetalle_ingreso.Value = Detalle_Venta.Iddetalle_ingreso;
    //        SqlCmd.Parameters.Add(ParIddetalle_ingreso);

    //        SqlParameter ParCantidad = new SqlParameter();
    //        ParCantidad.ParameterName = "@Cantidad";
    //        ParCantidad.SqlDbType = SqlDbType.Int;
    //        ParCantidad.Value = Detalle_Venta.Cantidad;
    //        SqlCmd.Parameters.Add(ParCantidad);

    //        SqlParameter ParPrecioVenta = new SqlParameter();
    //        ParPrecioVenta.ParameterName = "@Precio_Venta";
    //        ParPrecioVenta.SqlDbType = SqlDbType.Money;
    //        ParPrecioVenta.Value = Detalle_Venta.Precio_Venta;
    //        SqlCmd.Parameters.Add(ParPrecioVenta);


    //        //Ejecutamos nuestro comando

    //        rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";


    //    }
    //    catch (Exception ex)
    //    {
    //        rpta = ex.Message;
    //    }

    //    return rpta;

    //}

}
