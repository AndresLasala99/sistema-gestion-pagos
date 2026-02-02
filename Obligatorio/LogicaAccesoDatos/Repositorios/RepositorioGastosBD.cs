using ExcepcionesPropias.Excepciones;
using LogicaAccesoDatos.EF;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioGastosBD : IRepositorio<Gasto>
    {
        public ObligatorioContext Contexto { get; set; }

        public RepositorioGastosBD(ObligatorioContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Gasto obj)
        {
            if (obj == null) throw new DatosInvalidosException("El gasto no puede ser nulo.");
            obj.Validar();
            Contexto.Gastos.Add(obj);
            Contexto.SaveChanges();
        }

        public void Update(Gasto obj)
        {
            if (obj == null) throw new DatosInvalidosException("No se proveen datos para la modificación.");

            obj.Validar();
            Gasto aModificar = FindById(obj.Id);

            if (aModificar == null) throw new OperacionInvalidaException("El gasto con ID " + obj.Id + " no existe");

            aModificar.Nombre = obj.Nombre;
            aModificar.Descripcion = obj.Descripcion;
            Contexto.Gastos.Update(aModificar);
            Contexto.SaveChanges();
        }

        public void Remove(int id)
        {
            Gasto aBorrar = FindById(id);
            if (aBorrar == null) throw new OperacionInvalidaException($"El gasto con id {id} no existe.");
            Contexto.Gastos.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        public IEnumerable<Gasto> FindAll()
        {
            return Contexto.Gastos.ToList();
        }

        public Gasto FindById(int id)
        {
            return Contexto.Gastos.FirstOrDefault(g => g.Id == id);
        }
    }
}
