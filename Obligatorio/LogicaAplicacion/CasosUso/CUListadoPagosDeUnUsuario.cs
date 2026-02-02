using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoPagosDeUnUsuario : IListadoPagosDeUnUsuario
    {
        public IRepositorioPagos Repo { get; set; }

        public CUListadoPagosDeUnUsuario(IRepositorioPagos repo)
        {
            Repo=repo;
        }
        public IEnumerable<PagoDTO> ObtenerPagosDeUnUsuario(int idUsuario)
        {
            IEnumerable<Pago> lista=Repo.ListadoPagosDeUnUsuario(idUsuario);
            return MapperPago.ToListaDTOAPI(lista);
        }
    }
}
