using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    public class MailVO : IValidable
    {
        public string Valor {  get; private set; }
        public MailVO(string valor) {
            Valor = valor;
            Validar();
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Valor)) throw new DatosInvalidosException("El mail no puede ser vacío.");

        }
        public override bool Equals(object obj)
        {
            MailVO otra = obj as MailVO;
            if (otra == null) return false;
            return Valor == otra.Valor;
        }
        public static MailVO GenerarDesdeNombreApellido(string nombre, string apellido)
        {
            string mail = "";

            if (nombre.Length < 3 && apellido.Length < 3)
            {
                mail = nombre.ToLower() + apellido.ToLower();
            }
            else if (nombre.Length < 3 && apellido.Length >= 3)
            {
                mail = nombre.ToLower();
                for (int i = 0; i < 3; i++)
                {
                    mail += char.ToLower(apellido[i]);
                }
            }
            else if (nombre.Length >= 3 && apellido.Length < 3)
            {
                mail = apellido.ToLower();
                for (int i = 0; i < 3; i++)
                {
                    mail += char.ToLower(nombre[i]);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    mail += char.ToLower(nombre[i]);
                }
                for (int i = 0; i < 3; i++)
                {
                    mail += char.ToLower(apellido[i]);
                }
            }

            string mailNormalizado = "";

            for (int i = 0; i < mail.Length; i++)
            {
                char c = mail[i];

                // reemplazos simples de acentos y caracteres comunes
                switch (c)
                {
                    case 'á':
                    case 'à':
                    case 'â':
                    case 'ä':
                    case 'ã':
                    case 'å':
                        c = 'a'; break;
                    case 'é':
                    case 'è':
                    case 'ê':
                    case 'ë':
                        c = 'e'; break;
                    case 'í':
                    case 'ì':
                    case 'î':
                    case 'ï':
                        c = 'i'; break;
                    case 'ó':
                    case 'ò':
                    case 'ô':
                    case 'ö':
                    case 'õ':
                        c = 'o'; break;
                    case 'ú':
                    case 'ù':
                    case 'û':
                    case 'ü':
                        c = 'u'; break;
                    case 'ñ':
                        c = 'n'; break;
                    case 'ç':
                        c = 'c'; break;
                }

                // dejamos sólo letras y números (saltamos espacios/símbolos)
                if (char.IsLetterOrDigit(c)) mailNormalizado += c;
            }

            string resultado = mailNormalizado + "@laempresa.com";

            return new MailVO(resultado);
        }

    }
}