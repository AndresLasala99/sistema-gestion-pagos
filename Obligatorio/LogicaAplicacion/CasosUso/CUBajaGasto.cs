using CasosUso.InterfacesCU;
using ExcepcionesPropias.Excepciones;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBajaGasto : IBajaGasto
    {
        public IRepositorio<Gasto> RepoGastos { get; set; }
        public IRepositorioPagos RepoPagos { get; set; }

        public CUBajaGasto(IRepositorio<Gasto> repoGastos, IRepositorioPagos repoPagos)
        {
            RepoGastos = repoGastos;
            RepoPagos = repoPagos;
        }
        public void EjecutarBaja(int id)
        {
            if (RepoPagos.ExistePagoConTipoGasto(id)) throw new OperacionInvalidaException("El tipo de gasto se encuentra en uso y no se puede eliminar.");
            RepoGastos.Remove(id);
        }
    }
}
