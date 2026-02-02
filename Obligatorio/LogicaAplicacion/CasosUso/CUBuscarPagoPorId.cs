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
    public class CUBuscarPagoPorId : IBuscarPagoPorId
    {
        public IRepositorioPagos Repositorio { get; set; }

        public CUBuscarPagoPorId(IRepositorioPagos repo)
        {
            Repositorio = repo;
        }

        public PagoDTO Buscar(int id)
        {
            return MapperPago.ToDtoAPI(Repositorio.FindById(id));
        }
    }
}
