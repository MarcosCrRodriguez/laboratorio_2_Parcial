﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IUsuario<T> 
        where T : Usuario
    {
        bool GuardarRegistro(T usuario);

        T LeerPorID(int id);

        T LeerPorDNI(long dni);
    }
}
