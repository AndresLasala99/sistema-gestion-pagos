using CasosUso.DTOs;
using ExcepcionesPropias.Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.DTOs
{
    public class PagoDTO
    {
        public int Id { get; set; }
        public TipoMetodo MetodoPago { get; set; }
        public int idGasto { get; set; }
        public int idUsuario { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public double SaldoPendiente { get; set; }

        // Para pagos únicos
        public DateTime? Fecha { get; set; }
        public int? NroRecibo { get; set; }

        // Para pagos recurrentes
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
