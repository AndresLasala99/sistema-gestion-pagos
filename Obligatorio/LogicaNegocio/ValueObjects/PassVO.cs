using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    public class PassVO : IValidable
    {
        public string Valor {  get; private set; }
        public PassVO(string valor)
        {
            Valor=valor;
            Validar();
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Valor)) throw new DatosInvalidosException("La contraseña no puede ser vacía.");
            if (Valor.Length < 8) throw new DatosInvalidosException("La contraseña debe tener al menos 8 caracteres.");
        }
        public override bool Equals(object obj)
        {
            PassVO otra = obj as PassVO;
            if (otra == null) return false;
            return Valor == otra.Valor;
        }
    }
}
