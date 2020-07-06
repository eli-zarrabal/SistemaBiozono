using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class NProcesoPurificado
    {
        
        public static string Insertar(int idempleado, DateTime fechaentradasodio, DateTime fechasalidasodio, string foliopurificacion)
        {
            dProcesoPurificado Obj = new dProcesoPurificado();
            Obj.IdEmpleado = idempleado;
            Obj.FechaEntradaSodio = fechaentradasodio;
            Obj.FechaSalidaSodio = fechasalidasodio;
            Obj.FolioPurificacion = foliopurificacion;
            return Obj.Insertar(Obj);
        }

        public static string Editar(
            int idpurificacion,
            int idempleado,
            DateTime fechaentradasodio,
            DateTime fechasalidasodio,
            string foliopurificacion
            )
        {
            dProcesoPurificado Obj = new dProcesoPurificado();
            Obj.IdPurificado = idpurificacion;
            Obj.IdEmpleado = idempleado;
            Obj.FechaEntradaSodio = fechaentradasodio;
            Obj.FechaSalidaSodio = fechasalidasodio;
            Obj.FolioPurificacion = foliopurificacion;

            return Obj.Editar(Obj);
        }


        public static string Eliminar(int idpurificado)
        {
            dProcesoPurificado Obj = new dProcesoPurificado();
            Obj.IdPurificado = idpurificado;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new dProcesoPurificado().Mostrar();
        }


        public static DataTable BuscarFolio(string textobuscar)
        {
            dProcesoPurificado Obj = new dProcesoPurificado();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarFolio(Obj);
        }


    }
}

