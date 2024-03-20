using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class TVE_ClientesAD : ITVE_ClientesAD
    {
        private VETEntidades _vETEntidades;

        public TVE_ClientesAD(VETEntidades vETEntidades)
        {
            _vETEntidades = vETEntidades;
        }

        // --- Entidades ---
        public List<TVE_Clientes> obtenerClientes_ENT()
        {
            List<TVE_Clientes> listaClientes = new List<TVE_Clientes>();
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                listaClientes = _vETEntidades.TVE_Clientes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = true;
            }

            return listaClientes;
        }

        public TVE_Clientes obtenerClientesXId_ENT(int pCliente)
        {
            TVE_Clientes cliente = new TVE_Clientes();

            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                cliente = _vETEntidades.TVE_Clientes.ToList().Find(x => x.TN_IdCliente == pCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = true;
            }

            return cliente;
        }

        public bool agregarClientes_ENT(TVE_Clientes pCliente)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVE_Clientes.Find(pCliente.TN_IdCliente);

                if (registroEncontrado == null)
                {
                    TVE_Clientes tVE_Clientes = _vETEntidades.TVE_Clientes.Add(pCliente);
                    _vETEntidades.SaveChanges();
                    estado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = true;
            }
            return estado;
        }

        public bool modificarClientes_ENT(TVE_Clientes pCliente)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVE_Clientes.Find(pCliente.TN_IdCliente);
                if (registroEncontrado != null)
                {
                    _vETEntidades.Entry(registroEncontrado).CurrentValues.SetValues(pCliente);
                    _vETEntidades.Entry(registroEncontrado).State = EntityState.Modified;
                    _vETEntidades.SaveChanges();
                    estado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = true;
            }
            return estado;
        }

        public bool eliminarCliente_ENT(TVE_Clientes pCliente)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVE_Clientes.Find(pCliente.TN_IdCliente);
                if (registroEncontrado != null)
                {
                    _vETEntidades.Entry(registroEncontrado).CurrentValues.SetValues(pCliente);
                    _vETEntidades.Entry(registroEncontrado).State = EntityState.Deleted;
                    _vETEntidades.SaveChanges();
                    estado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = true;
            }
            return estado;
        }
    }
}