using Entidades;
using System.Collections.Generic;

namespace AccesoDatos.Interfaces
{
    public interface ITVET_CitasAD
    {
        // --- Entidades ---
        List<TVET_Citas> obtenerCita_ENT();

        TVET_Citas obtenerCitaXId_ENT(int pCita);

        bool agregarCita_ENT(TVET_Citas pCita);

        bool modificarCita_ENT(TVET_Citas pCita);

        bool eliminarCita_ENT(TVET_Citas pCita);
    }
}