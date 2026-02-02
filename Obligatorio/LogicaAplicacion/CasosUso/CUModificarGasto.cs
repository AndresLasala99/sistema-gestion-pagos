using CasosUso.DTOs;
using CasosUso.InterfacesCU;
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
    public class CUModificarGasto : IModificarGasto
    {
        public IRepositorio<Gasto> Repositorio { get; set; }

        public CUModificarGasto(IRepositorio<Gasto> repo)
        {
            Repositorio = repo;
        }
        public void EjecutarModificacion(GastoDTO dto)
        {
            Gasto aModificar= Repositorio.FindById(dto.Id);
            aModificar.Id = dto.Id;
            aModificar.Nombre = dto.Nombre;
            aModificar.Descripcion = dto.Descripcion;
            Repositorio.Update(aModificar);
        }
    }
}
