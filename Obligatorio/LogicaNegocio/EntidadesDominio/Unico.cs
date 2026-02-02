using ExcepcionesPropias.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Unico: Pago
    {
        public DateTime Fecha {  get; set; }
        public int NroRecibo { get; set; }

        public Unico(TipoMetodo metodoPago, Gasto gasto, Usuario usuario, string descripcion,double monto, DateTime fecha, int nroRecibo) : base(metodoPago, gasto, usuario, descripcion,monto)
        {
            Fecha = fecha;
            NroRecibo = nroRecibo;
        }

        public Unico() { }

        public override void Validar()
        {
            base.Validar();
            if (Fecha == DateTime.MinValue) throw new DatosInvalidosException("La fecha es inválida.");
            if (NroRecibo <= 0) throw new DatosInvalidosException("El número de recibo no puede ser negativo.");
        }
        public override double CalcularMontoTotal()
        {
            return Monto;
        }

        public override double SaldoPendiente(int mes, int anio)
        {
            return 0;
        }
    }
}
