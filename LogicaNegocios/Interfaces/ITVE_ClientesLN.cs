using Entidades;
using System.Collections.Generic;

namespace AccesoDatos.Interfaces
{
    public interface ITVE_ClientesLN
    {
        // --- Entidades ---
        List<TVE_Clientes> obtenerClientes_ENT();

        TVE_Clientes obtenerClientesXId_ENT(int pCliente);

        bool agregarClientes_ENT(TVE_Clientes pCliente);

        bool modificarClientes_ENT(TVE_Clientes pCliente);

        bool eliminarCliente_ENT(TVE_Clientes pCliente);
    }
}