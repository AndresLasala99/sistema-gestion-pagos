using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using ExcepcionesPropias.Excepciones;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CULoginUsuario : ILoginUsuario
    {
        public IRepositorioUsuarios RepoUsuarios { get; set; }
        public CULoginUsuario(IRepositorioUsuarios repoUsuarios)
        {
            RepoUsuarios = repoUsuarios;
        }

            public UsuarioDTO Login(string correo, string pass)
        {
            Usuario u = RepoUsuarios.FindByMail(correo);

            if (u == null) throw new DatosInvalidosException("Email o contraseña inválidos.");
            if (u.Pass != pass) throw new DatosInvalidosException("Email o contraseña inválidos.");

            return MapperUsuario.ToDTO(u);
        }
    }
}
