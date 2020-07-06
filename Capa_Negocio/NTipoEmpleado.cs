using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class NTipoEmpleado
    {
        //Método Insertar que llama al método Insertar de la clase dProducto
        //de la CapaDatos
        public static string Insertar(string tipo)
        {
            dTipoEmpleado Obj = new dTipoEmpleado();
            Obj.Tipo = tipo;
            return Obj.Insertar(Obj);
        }

       
        public static string Editar(int idtipoempleado, string tipo)
        {
            dTipoEmpleado Obj = new dTipoEmpleado();
            Obj.IdTipoEmpleado = idtipoempleado;
            Obj.Tipo = tipo;

            return Obj.Editar(Obj);
        }


        //public static string Eliminar(int idtipoempleado)
        //{
        //    dTipoEmpleado Obj = new dTipoEmpleado();
        //    Obj.IdTipoEmpleado = idtipoempleado;
        //    return Obj.Eliminar(Obj);
        //}

        public static DataTable Mostrar()
        {
            return new dTipoEmpleado().Mostrar();
        }


        //public static DataTable BuscarNombre(string textobuscar)
        //{
        //    dTipoEmpleado Obj = new dTipoEmpleado();
        //    Obj.TextoBuscar = textobuscar;
        //    return Obj.BuscarNombre(Obj);
        //}

    }
}

