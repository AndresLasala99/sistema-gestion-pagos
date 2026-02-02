using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using ExcepcionesPropias.Excepciones;
using LogicaAccesoDatos.Repositorios;
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
    public class CUAltaUsuario : IAltaUsuario
    {
        public IRepositorio<Usuario> RepoUsuarios { get; set; }
        public IRepositorio<Equipo> RepoEquipos { get; set; }

        public CUAltaUsuario(IRepositorio<Usuario> repoUsuarios, IRepositorio<Equipo> repoEquipos)
        {
            RepoUsuarios = repoUsuarios;
            RepoEquipos = repoEquipos;
        }
        public void EjecutarAlta(UsuarioDTO dto)
        {
            Equipo e= RepoEquipos.FindById(dto.idEquipo);
            Usuario nuevo = MapperUsuario.ToUsuario(dto,e);
            nuevo.Validar();
            RepoUsuarios.Add(nuevo);
        }
    }
}
