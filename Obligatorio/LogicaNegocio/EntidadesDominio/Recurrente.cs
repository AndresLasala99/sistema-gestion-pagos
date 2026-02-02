using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Recurrente : Pago
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public Recurrente(TipoMetodo metodoPago, Gasto gasto, Usuario usuario, string descripcion, double monto, DateTime fechaInicio, DateTime fechaFin) : base(metodoPago, gasto, usuario, descripcion, monto)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

        public Recurrente() { }

        public override void Validar()
        {
            base.Validar();
            if (FechaInicio > FechaFin) throw new DatosInvalidosException("La fecha de inicio no puede ser mayor a la fecha fin."); //corregir mensaje de error q no es claro
            if (FechaFin == DateTime.MinValue) throw new DatosInvalidosException("La fecha es inválida.");
            if (FechaInicio == DateTime.MinValue) throw new DatosInvalidosException("La fecha es inválida.");
        }

        public override double CalcularMontoTotal()
        {
            int cantidadMeses = ((FechaFin.Year - FechaInicio.Year) * 12) + FechaFin.Month - FechaInicio.Month;

            if (FechaFin.Day < FechaInicio.Day)
            {
                cantidadMeses--;
            }

            return Monto * cantidadMeses;
        }

        public override double SaldoPendiente(int mes, int anio)
        {
            int mesConsultado = anio * 12 + mes;
            int finPago = FechaFin.Year * 12 + FechaFin.Month;

            if (mesConsultado > finPago) return 0;

            int restantes = finPago - mesConsultado + 1;
            if (restantes < 0) restantes = 0;

            return Monto * restantes;
        }
    }
}
