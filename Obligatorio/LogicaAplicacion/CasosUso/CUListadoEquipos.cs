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
    public class CUListadoEquipos : IListadoEquipos
    {
        public IRepositorio<Equipo> Repositorio { get; set; }

        public CUListadoEquipos(IRepositorio<Equipo> repo)
        {
            Repositorio = repo;
        }

        public IEnumerable<EquipoDTO> ObtenerListadoEquipos()
        {
            return MapperEquipo.ToListaDTO(Repositorio.FindAll());
        }
    }
}
