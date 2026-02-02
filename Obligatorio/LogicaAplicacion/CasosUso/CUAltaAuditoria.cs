using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using ExcepcionesPropias.Excepciones;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaAuditoria : IAltaAuditoria
    {
        public IRepositorio<Auditoria> Repositorio { get; set; }
        public CUAltaAuditoria(IRepositorio<Auditoria> repo)
        {
            Repositorio = repo;
        }
        public void EjecutarAlta(AuditoriaDTO dto)
        {
            Auditoria a = MapperAuditoria.ToAuditoria(dto);
            Repositorio.Add(a);
        }
    }
}
