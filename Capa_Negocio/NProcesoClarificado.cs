using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class NProcesoClarificado
    {

        public static string Insertar(int idempleado, string lecturaanterior, int cantidad,  DateTime fecha, string folioclarificado)
        {
            dProcesoClarificado Obj = new dProcesoClarificado();
            Obj.IdEmpleado = idempleado;
            Obj.LecturaAnterior = lecturaanterior;
            Obj.Cantidad = cantidad;
            Obj.Fecha = fecha;
            Obj.FolioClarificado = folioclarificado;
            return Obj.Insertar(Obj);
        }


       

        public static string Editar(
            int idclarificado,
            int idempleado,
            string lecturaanterior,
            int cantidad,
            DateTime fecha,
            string folioclarificado
            )
        {
            dProcesoClarificado Obj = new dProcesoClarificado();
            Obj.IdClarificado = idclarificado;
            Obj.IdEmpleado = idempleado;
            Obj.LecturaAnterior = lecturaanterior;
            Obj.Cantidad = cantidad;
            Obj.Fecha = fecha;
            Obj.FolioClarificado = folioclarificado;
            return Obj.Editar(Obj);
        }


        public static string Eliminar(int idclarificado)
        {
            dProcesoClarificado Obj = new dProcesoClarificado();
            Obj.IdClarificado = idclarificado;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new dProcesoClarificado().Mostrar();
        }


        public static DataTable BuscarFolio(string textobuscar)
        {
            dProcesoClarificado Obj = new dProcesoClarificado();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarFolio(Obj);
        }
        public static DataTable BuscarEmpleado(string textobuscar)
        {
            dProcesoClarificado Obj = new dProcesoClarificado();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarEmpleado(Obj);
        }
        //public static DataTable BuscarCantidad(string textobuscar)
        //{
        //    dProcesoClarificado Obj = new dProcesoClarificado();
        //    Obj.TextoBuscar = textobuscar;
        //    return Obj.BuscarCantidad(Obj);
        //}
        //public static DataTable BuscarLecturaAnterior(string textobuscar)
        //{
        //    dProcesoClarificado Obj = new dProcesoClarificado();
        //    Obj.TextoBuscar = textobuscar;
        //    return Obj.BuscarLecturaAnterior(Obj);
        //}


    }
}

