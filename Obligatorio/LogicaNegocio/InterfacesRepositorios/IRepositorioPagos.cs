using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPagos : IRepositorio<Pago>
    {
        IEnumerable<Pago> ListadoMensualDePagos(int mes, int anio);
        IEnumerable<Usuario> UsuariosConPagosUnicoSuperioresA(double monto);
        bool ExistePagoConTipoGasto(int gastoId);
        IEnumerable<Pago> ListadoPagosDeUnUsuario(int idUsuario);
        IEnumerable<Equipo> ListadoEquiposConPagosUnicosMayoresA(double monto);
    }
}
