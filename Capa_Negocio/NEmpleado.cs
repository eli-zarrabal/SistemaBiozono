using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class NEmpleado
    {
        //Método Insertar que llama al método Insertar de la clase dProducto
        //de la CapaDatos
        public static string Insertar(string nombre,
            string codigoempleado,
            string apellidopaterno,
            string apellidomaterno,
            string edad,
            string sexo,
            string telefono,
            string domicilio,
            int tipoempleado,
            int rol,
            string usuario,
            string password
            )
        {
            dEmpleado Obj = new dEmpleado();
            Obj.CodigoEmpleado = codigoempleado;
            Obj.Nombre = nombre;
            Obj.Apellido_Paterno = apellidopaterno;
            Obj.Apellido_Materno = apellidomaterno;
            Obj.Edad = edad;
            Obj.Sexo = sexo;
            Obj.Telefono = telefono;
            Obj.Domicilio = domicilio;
            Obj.TipoEmpleado = tipoempleado;
            Obj.Rol = rol;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idempleado,
            string codigoempleado,
            string nombre,
            string apellidopaterno,
            string apellidomaterno,
            string edad,
            string sexo,
            string telefono,
            string domicilio,
            int tipoempleado,
            int rol,
            string usuario,
            string password)
        {
            dEmpleado Obj = new dEmpleado();

            Obj.IdEmpleado = idempleado;
            Obj.CodigoEmpleado = codigoempleado;
            Obj.Nombre = nombre;
            Obj.Apellido_Paterno = apellidopaterno;
            Obj.Apellido_Materno = apellidomaterno;
            Obj.Edad = edad;
            Obj.Sexo = sexo;
            Obj.Telefono = telefono;
            Obj.Domicilio = domicilio;
            Obj.TipoEmpleado = tipoempleado;
            Obj.Rol = rol;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Editar(Obj);
        }


        public static string Eliminar(int idempleado)
        {
            dEmpleado Obj = new dEmpleado();
            Obj.IdEmpleado = idempleado;
            return Obj.Eliminar(Obj);
        }
        public static DataTable BuscarNombre(string textobuscar)
        {
            dEmpleado Obj = new dEmpleado();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
        public static DataTable BuscarCodigo(string textobuscar)
        {
            dEmpleado Obj = new dEmpleado();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCodigo(Obj);
        }
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new dEmpleado().Mostrar();
        }
        public static DataTable Login(string usuario, string password)
        {
            dEmpleado Obj = new dEmpleado();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
    }
}


