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
    public class CUListadoPagosSuperioresMonto : IListadoPagosSuperioresMonto
    {
        public IRepositorioPagos RepoPagos { get; set; }

        public CUListadoPagosSuperioresMonto(IRepositorioPagos repoPagos)
        {
            RepoPagos = repoPagos;
        }
        public IEnumerable<UsuarioDTO> ObtenerListadoUsuariosPagosSuperioresAUnMonto(double monto)
        {
            IEnumerable<Usuario> lista = RepoPagos.UsuariosConPagosUnicoSuperioresA(monto);
            return MapperUsuario.ToListaDTO(lista);
        }
    }
}
