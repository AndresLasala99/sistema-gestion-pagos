using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.InterfacesCU
{
    public interface IListadoMensualPagos
    {
        public IEnumerable<PagoDTO> ObtenerListadoMensualPagos(int mes, int anio);
    }
}
