using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public abstract class Pago : IValidable
    {
        public int Id { get; set; }
        public TipoMetodo MetodoPago { get; set; }
        public Gasto Gasto { get; set; }
        public Usuario Usuario { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }
        public double Monto { get; set; }

        public Pago() { }
        public Pago (TipoMetodo metodoPago, Gasto gasto, Usuario usuario, string descripcion, double monto)
        {
            MetodoPago = metodoPago;
            Gasto = gasto;
            Usuario = usuario;
            Descripcion = descripcion;
            Monto = monto;
        }

        public virtual void Validar()
        {
            if (Gasto == null) throw new DatosInvalidosException("El gasto asociado no puede ser nulo.");
            if (Usuario == null) throw new DatosInvalidosException("El usuario asociado no puede ser nulo.");
            if (string.IsNullOrEmpty(Descripcion)) throw new DatosInvalidosException("La descripción no puede estar vacía.");
            if (Monto <= 0) throw new DatosInvalidosException("El monto debe ser mayor a cero.");
        }

        public abstract double CalcularMontoTotal();

        public abstract double SaldoPendiente(int mes, int anio);
    }
}
