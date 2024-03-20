using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface ITVET_DetalleMascotaAD
    {
        // --- Entidades ---
        List<TVET_DetalleMascota> obtenerDetalleMascota_ENT();

        TVET_DetalleMascota obtenerDetalleMascotaXId_ENT(int pDetalle);

        bool agregarDetalleMascota_ENT(TVET_DetalleMascota pDetalle);

        bool modificarDetalleMascota_ENT(TVET_DetalleMascota pDetalle);

        bool eliminarDetalleMascota_ENT(TVET_DetalleMascota pDetalle);
    }
}
