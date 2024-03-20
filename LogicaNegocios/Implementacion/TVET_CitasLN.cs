using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class TVET_CitasLN : ITVET_CitasAD
    {
        private VETEntidades _vETEntidades;

        public TVET_CitasLN(VETEntidades vETEntidades)
        {
            _vETEntidades = vETEntidades;
        }

        public List<TVET_Citas> obtenerCita_ENT()
        {
            List<TVET_Citas> listaCitas = new List<TVET_Citas>();
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                listaCitas = _vETEntidades.TVET_Citas.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = true;
            }

            return listaCitas;
        }

        public TVET_Citas obtenerCitaXId_ENT(int pCita)
        {
            TVET_Citas detalle = new TVET_Citas();

            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                detalle = _vETEntidades.TVET_Citas.ToList().Find(x => x.TN_IdCita == pCita);
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

        public bool agregarCita_ENT(TVET_Citas pCita)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_Citas.Find(pCita.TN_IdCita);

                if (registroEncontrado == null)
                {
                    TVET_Citas tVET_Citas = _vETEntidades.TVET_Citas.Add(pCita);
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

        public bool modificarCita_ENT(TVET_Citas pCita)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_DetalleMascota.Find(pCita.TN_IdCita);
                if (registroEncontrado != null)
                {
                    _vETEntidades.Entry(registroEncontrado).CurrentValues.SetValues(pCita);
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

        public bool eliminarCita_ENT(TVET_Citas pCita)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_Citas.Find(pCita.TN_IdCita);
                if (registroEncontrado != null)
                {
                    _vETEntidades.Entry(registroEncontrado).CurrentValues.SetValues(pCita);
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
