using AccesoDatos.Interfaces;
using Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace AccesoDatos.Implementacion
{
    public class TVET_MascotasAD : ITVET_MascotasAD
    {
        private VETEntidades _vETEntidades;

        public TVET_MascotasAD(VETEntidades vETEntidades)
        {
            _vETEntidades = vETEntidades;
        }

        // --- Entidades ---
        public List<TVET_Mascotas> obtenerMascotas_ENT()
        {
            List<TVET_Mascotas> listaMascotas = new List<TVET_Mascotas>();
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                listaMascotas = _vETEntidades.TVET_Mascotas.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = true;
            }

            return listaMascotas;
        }

        public TVET_Mascotas obtenerMascotaXId_ENT(int pMascota)
        {
            TVET_Mascotas cliente = new TVET_Mascotas();

            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                cliente = _vETEntidades.TVET_Mascotas.ToList().Find(x => x.TN_IdMascota == pMascota);
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

        public bool agregarMascotas_ENT(TVET_Mascotas pMascota)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_Mascotas.Find(pMascota.TN_IdMascota);

                if (registroEncontrado == null)
                {
                    TVET_Mascotas tVET_Mascotas = _vETEntidades.TVET_Mascotas.Add(pMascota);
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

        public bool modificarMascota_ENT(TVET_Mascotas pMascota)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_Mascotas.Find(pMascota.TN_IdMascota);
                if (registroEncontrado != null)
                {
                    _vETEntidades.Entry(registroEncontrado).CurrentValues.SetValues(pMascota);
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

        public bool eliminarMascota_ENT(TVET_Mascotas pMascota)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_Mascotas.Find(pMascota.TN_IdMascota);
                if (registroEncontrado != null)
                {
                    _vETEntidades.Entry(registroEncontrado).CurrentValues.SetValues(pMascota);
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