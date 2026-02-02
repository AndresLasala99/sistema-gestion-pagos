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
    public class RepositorioEquiposBD : IRepositorio<Equipo>
    {
        public ObligatorioContext Contexto { get; set; }

        public RepositorioEquiposBD(ObligatorioContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Equipo obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Equipo obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> FindAll()
        {
            return Contexto.Equipos.ToList();
        }

        public Equipo FindById(int id)
        {
            return Contexto.Equipos.FirstOrDefault(e => e.Id == id);
        }
    }
}
