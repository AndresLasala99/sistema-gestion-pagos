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
    public class CUListadoEquiposConPagosUnicosMayoresA: IListadoEquiposConPagosUnicosMayoresA
    {
        public IRepositorioPagos Repo { get; set; }
        public CUListadoEquiposConPagosUnicosMayoresA(IRepositorioPagos repo)
        {
            Repo = repo;
        }
        public IEnumerable<EquipoDTO> ObtenerEquiposConPagosUnicosMayoresA(double monto)
        {
            IEnumerable<Equipo> lista=Repo.ListadoEquiposConPagosUnicosMayoresA(monto);
            return MapperEquipo.ToListaDTO(lista);
        }
    }
}
