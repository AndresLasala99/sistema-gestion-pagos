using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    public class MapperGasto
    {
        public static IEnumerable<GastoDTO> ToListaDTO(IEnumerable<Gasto> gastos)
        {
            return gastos.Select(ToDTO).ToList();
        }

        public static GastoDTO ToDTO(Gasto gasto)
        {
            GastoDTO dto=new GastoDTO();
            dto.Id = gasto.Id;
            dto.Nombre= gasto.Nombre;
            dto.Descripcion= gasto.Descripcion;
            return dto;
        }

        public static Gasto ToGasto(GastoDTO dto)
        {
            Gasto gasto = new Gasto(dto.Nombre,dto.Descripcion);
            return gasto;
        }
    }
}
