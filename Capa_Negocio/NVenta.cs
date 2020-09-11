using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class NVenta
    {
        public static string Insertar(
            int idcliente, 
            int idempleado, 
            DateTime fecha,
             DataTable dtDetalles)
        {
            dVenta Obj = new dVenta();
            Obj.Idcliente = idcliente;
            Obj.IdEmpleado = idempleado;
            Obj.Fecha = fecha;
           
            List<dDetalleVenta> detalles = new List<dDetalleVenta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                dDetalleVenta detalle = new dDetalleVenta();
                detalle.Iddetalle_ingreso = Convert.ToInt32(row["Id_DetalleIngreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["Precio_Venta"].ToString());  
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        public static string Eliminar(int idventa)
        {
            dVenta Obj = new dVenta();
            Obj.Idventa = idventa;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DVenta
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new dVenta().Mostrar();
        }

        //Método BuscarFecha que llama al método BuscarFecha
        //de la clase DVenta de la CapaDatos

        //public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        //{
        //    dVenta Obj = new dVenta();
        //    return Obj.BuscarFechas(textobuscar, textobuscar2);
        //}

        public static DataTable MostrarDetalle(string textobuscar)
        {
            dVenta Obj = new dVenta();
            return Obj.MostrarDetalle(textobuscar);
        }
        public static DataTable MostrarProducto_Venta_Nombre(string textobuscar)
        {
            dVenta Obj = new dVenta();
            return Obj.MostrarProducto_Venta_Nombre(textobuscar);
        }


    }
}