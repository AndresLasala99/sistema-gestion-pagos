using CasosUso.DTOs;
using CasosUso.InterfacesCU;
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
    public class CUListadoAuditoriasDeUnTipoDeGasto : IListadoAuditoriasDeUnTipoDeGasto
    {
        public IRepositorioAuditorias RepoAuditorias { get; set; }
        public IRepositorio<Gasto> RepoGastos { get; set; }

        public CUListadoAuditoriasDeUnTipoDeGasto(IRepositorioAuditorias repoAuditorias, IRepositorio<Gasto> repoGastos)
        {
            RepoAuditorias = repoAuditorias;
            RepoGastos = repoGastos;
        }

        public IEnumerable<AuditoriaDTO> ObtenerAuditoriasDeUnTipoDeGasto(int idGasto)
        {
            Gasto g = RepoGastos.FindById(idGasto);
            if (g == null)
            {
                throw new Exception("El tipo de gasto no existe.");
            }

            IEnumerable<Auditoria> lista = RepoAuditorias.ListadoAuditoriasDeUnTipoDeGasto(idGasto);
            return MapperAuditoria.ToListaDTO(lista);
        }
    }
}
