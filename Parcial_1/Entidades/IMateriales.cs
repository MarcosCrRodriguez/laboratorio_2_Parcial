using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMateriales
    {
        bool Modificar(string material, int cantidadAgregar, int id);

        int LeerPorMaterial(int id, string material);
    }
}
