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
    public class CUBuscarEquipoPorId : IBuscarEquipoPorId
    {
        public IRepositorio<Equipo> Repositorio { get; set; }

        public CUBuscarEquipoPorId(IRepositorio<Equipo> repo)
        {
            Repositorio = repo;
        }

        public EquipoDTO Buscar(int id)
        {
            return MapperEquipo.ToDTO(Repositorio.FindById(id));
        }
    }
}
