using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio.Clases
{
    public abstract class Basededatos
    {
        public static List<Clientes> misClientes = new List<Clientes>()
        {
            new Clientes{ Nombre="Santiago", Apellido="Delgado", CI= 55188116, Direccion="Maldonado", Email="ejemplo@gmail.com", Telefono=099263238},
            new Clientes{ Nombre="Elías", Apellido="Corajoría", CI= 12345678, Direccion="La BARRA", Email="elias@hotmail.com", Telefono=000000000}
        };

        public static List<Tecnicos> misTecnicos = new List<Tecnicos>()
        {
            new Tecnicos{ Nombre="Jorge", Apellido="Perez", CI= 55188116, Especialidad="Electricista"},
            new Tecnicos{ Nombre="Ana", Apellido="Morales", CI= 12345678, Especialidad="Diseñadora"}
        };

        public static List<OrdenDeTrabajo> misOrdenes = new List<OrdenDeTrabajo>()
        {

        };
    }
}