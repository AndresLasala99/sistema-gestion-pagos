using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using System.Collections.Generic;

namespace LogicaAplicacion.Mappers
{
    public static class MapperEquipo
    {
        public static EquipoDTO ToDTO(Equipo e)
        {
            EquipoDTO dto= new EquipoDTO();
            dto.Id = e.Id;
            dto.Nombre = e.Nombre;

            return dto;
        }

        public static Equipo ToEquipo(EquipoDTO dto)
        {
            Equipo e= new Equipo();
            e.Id = dto.Id;
            e.Nombre= dto.Nombre;

            return e;
        }

        public static IEnumerable<EquipoDTO> ToListaDTO(IEnumerable<Equipo> equipos)
        {
            return equipos.Select(ToDTO).ToList();
        }
    }
}
