using CasosUso.DTOs;
using CasosUso.InterfacesCU;
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
    public class CUListadoUsuarios : IListadoUsuarios
    {
        public IRepositorioUsuarios Repositorio { get; set; }

        public CUListadoUsuarios(IRepositorioUsuarios repo)
        {
            Repositorio = repo;
        }
        public IEnumerable<UsuarioDTO> ObtenerListadoUsuarios()
        {
            return MapperUsuario.ToListaDTO(Repositorio.FindAll());
        }
    }
}
