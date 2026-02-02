using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    public class MapperPago
    {
        public static IEnumerable<PagoDTO> ToListaDTO(IEnumerable<Pago> pagos, int mes, int anio)
        {
            List<PagoDTO> resultado = new List<PagoDTO>();

            foreach (Pago p in pagos)
            {
                PagoDTO dto = ToDto(p, mes, anio);
                resultado.Add(dto);
            }

            return resultado;
        }

        public static PagoDTO ToDto(Pago p, int mes, int anio)
        {
            PagoDTO dto = new PagoDTO();

            dto.Id = p.Id;
            dto.MetodoPago = p.MetodoPago;
            dto.idUsuario = p.Usuario.Id;
            dto.idGasto = p.Gasto.Id;
            dto.Descripcion = p.Descripcion;
            dto.Monto = p.Monto;
            dto.SaldoPendiente = p.SaldoPendiente(mes, anio);

            if (p is Recurrente)
            {
                Recurrente r = (Recurrente)p;
                dto.FechaInicio = r.FechaInicio;
                dto.FechaFin = r.FechaFin;
            }
            else
            {
                Unico u = (Unico)p;
                dto.Fecha = u.Fecha;
                dto.NroRecibo = u.NroRecibo;
            }

            return dto;
        }

        public static PagoDTO ToDtoAPI(Pago p)
        {
            PagoDTO dto = new PagoDTO();

            dto.Id = p.Id;
            dto.MetodoPago = p.MetodoPago;
            dto.idUsuario = p.Usuario.Id;
            dto.idGasto = p.Gasto.Id;
            dto.Descripcion = p.Descripcion;
            dto.Monto = p.Monto;
            int mesActual = DateTime.Now.Month;
            int anioActual = DateTime.Now.Year;
            dto.SaldoPendiente = p.SaldoPendiente(mesActual, anioActual);

            if (p is Recurrente)
            {
                Recurrente r = (Recurrente)p;
                dto.FechaInicio = r.FechaInicio;
                dto.FechaFin = r.FechaFin;
            }
            else
            {
                Unico u = (Unico)p;
                dto.Fecha = u.Fecha;
                dto.NroRecibo = u.NroRecibo;
            }

            return dto;
        }

        public static Pago ToPago(PagoDTO dto)
        {
            Usuario usuario = new Usuario();
            usuario.Id = dto.idUsuario;
            Gasto gasto = new Gasto();
            gasto.Id = dto.idGasto;

            if (dto.FechaInicio.HasValue && dto.FechaFin.HasValue)
            {
                return new Recurrente(dto.MetodoPago,gasto,usuario,dto.Descripcion,dto.Monto,dto.FechaInicio.Value,dto.FechaFin.Value);
            }
            else
            {
                DateTime fecha = dto.Fecha.HasValue ? dto.Fecha.Value : DateTime.Now;
                int nroRecibo = dto.NroRecibo.HasValue ? dto.NroRecibo.Value : 0;

                return new Unico(dto.MetodoPago,gasto,usuario,dto.Descripcion,dto.Monto,fecha,nroRecibo);
            }
        }

        public static IEnumerable<PagoDTO> ToListaDTOAPI(IEnumerable<Pago> pagos)
        {
            List<PagoDTO> resultado = new List<PagoDTO>();

            foreach (Pago p in pagos)
            {
                PagoDTO dto = ToDtoAPI(p);
                resultado.Add(dto);
            }

            return resultado;
        }
    }
}