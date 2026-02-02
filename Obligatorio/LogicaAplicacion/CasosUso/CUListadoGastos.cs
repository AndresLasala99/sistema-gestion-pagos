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
    public class CUListadoGastos : IListadoGastos
    {
        public IRepositorio<Gasto> Repositorio { get; set; }

        public CUListadoGastos(IRepositorio<Gasto> repo)
        {
            Repositorio = repo;
        }
        public IEnumerable<GastoDTO> ObtenerListadoGastos()
        {
            return MapperGasto.ToListaDTO(Repositorio.FindAll());
        }
    }
}
