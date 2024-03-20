using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class TVET_DetalleMascotaAD : ITVET_DetalleMascotaAD
    {
        private VETEntidades _vETEntidades;

        public TVET_DetalleMascotaAD(VETEntidades vETEntidades)
        {
            _vETEntidades = vETEntidades;
        }

        public List<TVET_DetalleMascota> obtenerDetalleMascota_ENT()
        {
            List<TVET_DetalleMascota> listaDetalles = new List<TVET_DetalleMascota>();
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                listaDetalles = _vETEntidades.TVET_DetalleMascota.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = true;
            }

            return listaDetalles;
        }

        public TVET_DetalleMascota obtenerDetalleMascotaXId_ENT(int pDetalle)
        {
            TVET_DetalleMascota detalle = new TVET_DetalleMascota();

            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                detalle = _vETEntidades.TVET_DetalleMascota.ToList().Find(x => x.TN_IdMascota == pDetalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = true;
            }

            return detalle;
        }

        public bool agregarDetalleMascota_ENT(TVET_DetalleMascota pDetalle)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_DetalleMascota.Find(pDetalle.TN_IdMascota);

                if (registroEncontrado == null)
                {
                    TVET_DetalleMascota tVET_Mascotas = _vETEntidades.TVET_DetalleMascota.Add(pDetalle);
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

        public bool modificarDetalleMascota_ENT(TVET_DetalleMascota pDetalle)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_DetalleMascota.Find(pDetalle.TN_IdMascota);
                if (registroEncontrado != null)
                {
                    _vETEntidades.Entry(registroEncontrado).CurrentValues.SetValues(pDetalle);
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

        public bool eliminarDetalleMascota_ENT(TVET_DetalleMascota pDetalle)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_DetalleMascota.Find(pDetalle.TN_IdMascota);
                if (registroEncontrado != null)
                {
                    _vETEntidades.Entry(registroEncontrado).CurrentValues.SetValues(pDetalle);
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