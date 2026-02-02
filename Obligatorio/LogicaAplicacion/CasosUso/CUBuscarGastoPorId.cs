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
    public class CUBuscarGastoPorId : IBuscarGastoPorId
    {
        public IRepositorio<Gasto> Repositorio { get; set; }

        public CUBuscarGastoPorId(IRepositorio<Gasto> repo)
        {
            Repositorio = repo;
        }

        public GastoDTO Buscar(int id)
        {
            Gasto g=Repositorio.FindById(id);
            if (g == null)
            {
                return null;
            }
            return MapperGasto.ToDTO(g);
        }

    }
}
