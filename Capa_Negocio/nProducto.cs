using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class NProducto
    {
        //Método Insertar que llama al método Insertar de la clase dProducto
        //de la CapaDatos
        public static string Insertar(string nombre)
        {
            dProducto Obj = new dProducto();
            Obj.Nombre = nombre;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idproducto, string nombre)
        {
            dProducto Obj = new dProducto();
            Obj.IdProducto = idproducto;
            Obj.Nombre = nombre;

            return Obj.Editar(Obj);
        }

       
        public static string Eliminar(int idproducto)
        {
            dProducto Obj = new dProducto();
            Obj.IdProducto = idproducto;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new dProducto().Mostrar();
        }

       
        public static DataTable BuscarNombre(string textobuscar)
        {
            dProducto Obj = new dProducto();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
       

    }
}

