using System.ComponentModel.DataAnnotations;

namespace ClienteHttpMVC.DTOs
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

        public DateTime? Fecha { get; set; }
        public int? NroRecibo { get; set; }


        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

    }
}
