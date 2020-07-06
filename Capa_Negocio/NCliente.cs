using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class NCliente
    {
       
        public static string Insertar(
            string nombre, 
            string apellidopaterno, 
            string apellidomaterno, 
            string direccion, 
            string localidad,
            string clavecliente)
        {
            dCliente Obj = new dCliente();
            Obj.Nombre = nombre;
            Obj.ApellidoPaterno = apellidopaterno;
            Obj.ApellidoMaterno = apellidomaterno;
            Obj.Direccion = direccion;
            Obj.Localidad = localidad;
            Obj.Clave_Cliente = clavecliente;
            return Obj.Insertar(Obj);
        }

        public static string Editar(
            int idcliente, 
            string nombre, 
            string apellidopaterno, 
            string apellidomaterno, 
            string direccion, 
            string localidad,
            string clavecliente)
        {
            dCliente Obj = new dCliente();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.ApellidoPaterno = apellidopaterno;
            Obj.ApellidoMaterno = apellidomaterno;
            Obj.Direccion = direccion;
            Obj.Localidad = localidad;
            Obj.Clave_Cliente = clavecliente;
            return Obj.Editar(Obj);
        }


        public static string Eliminar(int idcliente)
        {
            dCliente Obj = new dCliente();
            Obj.Idcliente = idcliente;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new dCliente().Mostrar();
        }


        public static DataTable BuscarNombre(string textobuscar)
        {
            dCliente Obj = new dCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        public static DataTable BuscarLocalidad(string textobuscar)
        {
            dCliente Obj = new dCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarLocalidad(Obj);
        }

    }
}

