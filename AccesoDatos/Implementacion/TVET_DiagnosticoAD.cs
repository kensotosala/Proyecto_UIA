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
    public class TVET_DiagnosticoAD : ITVET_DiagnosticoAD
    {
        private VETEntidades _vETEntidades;

        public TVET_DiagnosticoAD(VETEntidades vETEntidades)
        {
            _vETEntidades = vETEntidades;
        }
        public List<TVET_Diagnostico> obtenerDiagnostico_ENT()
        {
            List<TVET_Diagnostico> listaDiagnostico = new List<TVET_Diagnostico>();
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                listaDiagnostico = _vETEntidades.TVET_Diagnostico.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = true;
            }

            return listaDiagnostico;
        }

        public TVET_Diagnostico obtenerDiagnosticoXId_ENT(int pDiagnostico)
        {
            TVET_Diagnostico diagnostico = new TVET_Diagnostico();

            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                diagnostico = _vETEntidades.TVET_Diagnostico.ToList().Find(x => x.TN_IdDiagnostico == pDiagnostico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = true;
            }

            return diagnostico;
        }

        public bool agregarDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_Diagnostico.Find(pDiagnostico.TN_IdDiagnostico);

                if (registroEncontrado == null)
                {
                    TVET_Diagnostico tVET_Diagnostico = _vETEntidades.TVET_Diagnostico.Add(pDiagnostico);
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

        public bool modificarDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_DetalleMascota.Find(pDiagnostico.TN_IdDiagnostico);
                if (registroEncontrado != null)
                {
                    _vETEntidades.Entry(registroEncontrado).CurrentValues.SetValues(pDiagnostico);
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

        public bool eliminarDiagnostico_ENT(TVET_Diagnostico pDiagnostico)
        {
            bool estado = false;
            try
            {
                _vETEntidades.Configuration.ProxyCreationEnabled = false;
                var registroEncontrado = _vETEntidades.TVET_Diagnostico.Find(pDiagnostico.TN_IdDiagnostico);
                if (registroEncontrado != null)
                {
                    _vETEntidades.Entry(registroEncontrado).CurrentValues.SetValues(pDiagnostico);
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