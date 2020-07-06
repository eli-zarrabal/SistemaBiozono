using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class NIngreso
    {
        public static string Insertar(
            int idtrabajador, 
            DateTime fecha,
            string estado, 
            DataTable dtDetalles)
        {
            dIngreso Obj = new dIngreso();
            Obj.IdEmpleado = idtrabajador;
            Obj.Fecha = fecha;   
            Obj.Estado = estado;
            List<dDetalleIngreso> detalles = new List<dDetalleIngreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                dDetalleIngreso detalle = new dDetalleIngreso();
                detalle.IdProducto = Convert.ToInt32(row["idproducto"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Fecha_Produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
           
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        public static string Anular(int idingreso)
        {
            dIngreso Obj = new dIngreso();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DIngreso
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new dIngreso().Mostrar();
        }

        //Método BuscarFecha que llama al método BuscarNombre
        //de la clase DIngreso de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            dIngreso Obj = new dIngreso();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            dIngreso Obj = new dIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
