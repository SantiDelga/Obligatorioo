﻿using System;
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

    }
}