using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using ExcepcionesPropias.Excepciones;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaPago : IAltaPago
    {
        public IRepositorioPagos RepoPagos { get; set; }

        public CUAltaPago(IRepositorioPagos repoPagos)
        {
            RepoPagos = repoPagos;
        }
        public void EjecutarAlta(PagoDTO dto)
        {
            if (dto == null) throw new DatosInvalidosException("Los datos del pago son requeridos.");

            Pago pago = MapperPago.ToPago(dto);
            pago.Validar();
            RepoPagos.Add(pago);
        }
    }
}
