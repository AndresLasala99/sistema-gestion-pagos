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
    public class CUBuscarUsuarioPorId : IBuscarUsuarioPorId
    {
        public IRepositorio<Usuario> Repositorio { get; set; }

        public CUBuscarUsuarioPorId(IRepositorio<Usuario> repo)
        {
            Repositorio = repo;
        }

        public UsuarioDTO Buscar(int id)
        {
            return MapperUsuario.ToDTO(Repositorio.FindById(id));
        }
    }
}
