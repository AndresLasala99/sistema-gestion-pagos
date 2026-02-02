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
    public class CUListadoMensualPagos : IListadoMensualPagos
    {
        public IRepositorioPagos RepoPagos { get; set; }

        public CUListadoMensualPagos(IRepositorioPagos repo)
        {
            RepoPagos = repo;
        }
        public IEnumerable<PagoDTO> ObtenerListadoMensualPagos(int mes, int anio)
        {
            IEnumerable<Pago> pagos = RepoPagos.ListadoMensualDePagos(mes, anio);
            return MapperPago.ToListaDTO(pagos,mes,anio);
        }
    }
}
