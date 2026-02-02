using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    [Index(nameof(Mail), IsUnique = true)]
    public class Usuario : IValidable
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Nombre { get; set; }

        [MaxLength(30)]
        public string Apellido { get; set; }

        [MaxLength(30)]
        public string Pass { get; private set; }

        [MaxLength(30)]
        public string Mail { get; set; }
        public RolUsuario Rol { get; set; }
        public Equipo Equipo { get; set; }

        public Usuario() { }

        public Usuario(string nombre,string apellido,PassVO pass, MailVO mail, RolUsuario rol, Equipo equipo) {
            Nombre = nombre;
            Apellido = apellido;
            Pass = pass.Valor;
            Mail = mail.Valor;
            Rol = rol;
            Equipo = equipo;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new DatosInvalidosException("El nombre no puede estar vacío.");
            if (string.IsNullOrEmpty(Apellido)) throw new DatosInvalidosException("El apellido no puede estar vacío.");
            if (string.IsNullOrEmpty(Mail)) throw new DatosInvalidosException("El mail no puede estar vacío.");
        }
        public string GeneradorMail()
        {
            MailVO mailVO= MailVO.GenerarDesdeNombreApellido(Nombre, Apellido);
            return mailVO.Valor;
        }

        public void CambiarPass(string nueva)
        {
            PassVO vo = new PassVO(nueva);
            Pass = vo.Valor;
        }

        public string RolSesion()
        {
            string sesion = "";
            if (Rol == RolUsuario.EMPLEADO) sesion = "Empleado";
            else if (Rol == RolUsuario.GERENTE) sesion = "Gerente";
            else sesion = "Administrador";
            return sesion;
        }
    }
}
