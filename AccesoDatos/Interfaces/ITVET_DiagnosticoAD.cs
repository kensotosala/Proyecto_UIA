using Entidades;
using System.Collections.Generic;

namespace AccesoDatos.Interfaces
{
    public interface ITVET_DiagnosticoAD
    { // --- Entidades ---
        List<TVET_Diagnostico> obtenerDiagnostico_ENT();

        TVET_Diagnostico obtenerDiagnosticoXId_ENT(int pDiagnostico);

        bool agregarDiagnostico_ENT(TVET_Diagnostico pDiagnostico);

        bool modificarDiagnostico_ENT(TVET_Diagnostico pDiagnostico);

        bool eliminarDiagnostico_ENT(TVET_Diagnostico pDiagnostico);
    }
}