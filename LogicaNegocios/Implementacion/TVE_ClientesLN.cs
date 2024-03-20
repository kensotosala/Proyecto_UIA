using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;

namespace AccesoDatos.Implementacion
{
    public class TVE_ClientesLN : ITVE_ClientesLN
    {
        public static VETEntidades _vETEntidades = new VETEntidades();
        private readonly ITVE_ClientesAD _tVE_ClientesAD = new TVE_ClientesAD(_vETEntidades);

        // --- Entidades ---
        public List<TVE_Clientes> obtenerClientes_ENT()
        {
            List<TVE_Clientes> listaClientes = new List<TVE_Clientes>();
            try
            {
                listaClientes = _tVE_ClientesAD.obtenerClientes_ENT();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaClientes;
        }

        public TVE_Clientes obtenerClientesXId_ENT(int pCliente)
        {
            TVE_Clientes cliente = new TVE_Clientes();

            try
            {
                cliente = _tVE_ClientesAD.obtenerClientesXId_ENT(pCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cliente;
        }

        public bool agregarClientes_ENT(TVE_Clientes pCliente)
        {
            bool estado = false;
            try
            {
                estado = _tVE_ClientesAD.agregarClientes_ENT(pCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return estado;
        }

        public bool modificarClientes_ENT(TVE_Clientes pCliente)
        {
            bool estado = false;
            try
            {
                estado = _tVE_ClientesAD.modificarClientes_ENT(pCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return estado;
        }

        public bool eliminarCliente_ENT(TVE_Clientes pCliente)
        {
            bool estado = false;
            try
            {
                estado = _tVE_ClientesAD.eliminarCliente_ENT(pCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return estado;
        }
    }
}