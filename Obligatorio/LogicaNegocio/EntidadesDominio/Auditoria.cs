using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Auditoria : IValidable
    {
        public int Id { get; set; }
        public TipoAccion Accion { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Usuario { get; set; }
        public int IdGasto { get; set; }

        public Auditoria() { }

        public void Validar()
        {
            if (Fecha == DateTime.MinValue) throw new DatosInvalidosException("La fecha es inválida.");
            if (Usuario == null) throw new DatosInvalidosException("El usuario no puede ser nulo.");
            if (IdGasto <= 0) throw new DatosInvalidosException("El id del tipo de gasto no puede ser menor a 1.");
        }
    }
}
