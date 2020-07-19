using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class NProcesoMantenimiento
    {

        public static string Insertar(
            string descripcion, 
            DateTime fecha,
            int idempleado)
        {
            dProcesoMantenimiento Obj = new dProcesoMantenimiento();
            Obj.Descripcion = descripcion;
            Obj.Fecha = fecha;
            Obj.IdEmpleado = idempleado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(
            int idmantenimiento,
            string descripcion,
             DateTime fecha,
            int idempleado
            )
        {
            dProcesoMantenimiento Obj = new dProcesoMantenimiento();
            Obj.IdMantenimiento = idmantenimiento;
            Obj.Descripcion = descripcion;
            Obj.Fecha = fecha;
            Obj.IdEmpleado = idempleado;
            return Obj.Editar(Obj);
        }


        public static string Eliminar(int idmantenimiento)
        {
            dProcesoMantenimiento Obj = new dProcesoMantenimiento();
            Obj.IdMantenimiento = idmantenimiento;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new dProcesoMantenimiento().Mostrar();
        }

        public static DataTable BuscarDescripcion(string textobuscar)
        {
            dProcesoMantenimiento Obj = new dProcesoMantenimiento();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarDescripcion(Obj);
        }
        public static DataTable BuscarEmpleado(string textobuscar)
        {
            dProcesoMantenimiento Obj = new dProcesoMantenimiento();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarEmpleado(Obj);
        }


    }
}

