using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface ITVET_MascotasLN
    {
        // --- Entidades ---
        List<TVET_Mascotas> obtenerMascotas_ENT();

        TVET_Mascotas obtenerMascotaXId_ENT(int pMascota);

        bool agregarMascotas_ENT(TVET_Mascotas pMascota);

        bool modificarMascota_ENT(TVET_Mascotas pMascota);

        bool eliminarMascota_ENT(TVET_Mascotas pMascota);
    }
}
