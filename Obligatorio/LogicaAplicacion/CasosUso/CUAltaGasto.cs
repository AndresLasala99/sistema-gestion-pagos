using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using LogicaAccesoDatos.Repositorios;
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
    public class CUAltaGasto : IAltaGasto
    {
        public IRepositorio<Gasto> Repositorio { get; set; }

        public CUAltaGasto(IRepositorio<Gasto> repo)
        {
            Repositorio = repo;
        }
        public void EjecutarAlta(GastoDTO dto)
        {
            Gasto g = MapperGasto.ToGasto(dto);
            Repositorio.Add(g);
            dto.Id = g.Id;
        }
    }
}
