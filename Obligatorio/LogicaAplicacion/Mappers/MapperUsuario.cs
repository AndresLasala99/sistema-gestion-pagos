using CasosUso.DTOs;
using ExcepcionesPropias.Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    public class MapperUsuario
    {
        public static Usuario ToUsuario(UsuarioDTO dto, Equipo e)
        {
            PassVO passVO = new PassVO(dto.Pass);
            MailVO mailVO = MailVO.GenerarDesdeNombreApellido(dto.Nombre,dto.Apellido);
            Usuario u = new Usuario(dto.Nombre,dto.Apellido,passVO,mailVO,dto.Rol,e);

            return u;
        }

        public static UsuarioDTO ToDTO(Usuario u)
        {
            UsuarioDTO dto = new UsuarioDTO();
            dto.Id = u.Id;
            dto.Nombre = u.Nombre;
            dto.Apellido = u.Apellido;
            dto.Pass = u.Pass;
            dto.Mail = u.Mail;
            dto.Rol = u.Rol;
            dto.idEquipo = u.Equipo.Id;
            dto.RolSesion = u.RolSesion();
            return dto;
        }

        public static IEnumerable<UsuarioDTO> ToListaDTO(IEnumerable<Usuario> usuarios)
        {
            return usuarios.Select(ToDTO).ToList();
        }
    }
}
