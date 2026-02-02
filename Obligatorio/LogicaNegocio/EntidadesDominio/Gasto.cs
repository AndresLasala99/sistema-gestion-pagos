using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Gasto : IValidable
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Descripcion { get; set; }

        public Gasto() { }

        public Gasto(string nombre,string descripcion) {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new DatosInvalidosException("El nombre no puede estar vacío.");
            if (string.IsNullOrEmpty(Descripcion)) throw new DatosInvalidosException("La descripción no puede estar vacía.");
        }
    }
}
