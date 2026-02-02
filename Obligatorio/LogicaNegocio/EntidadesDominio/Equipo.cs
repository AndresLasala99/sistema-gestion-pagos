using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Equipo : IValidable
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Nombre { get; set; }
        public Equipo() { }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new Exception("El nombre no puede ser vacío.");
        }
    }
}
