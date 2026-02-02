using ExcepcionesPropias.Excepciones;
using LogicaAccesoDatos.EF;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoriaBD : IRepositorioAuditorias
    {
        public ObligatorioContext Contexto { get; set; }
        public RepositorioAuditoriaBD(ObligatorioContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Auditoria obj)
        {
            obj.Validar();
            if (obj.Usuario != null)
            {
                var u = Contexto.Usuarios.Find(obj.Usuario.Id);

                if (u != null)
                {
                    obj.Usuario = u;
                }
                else
                {
                    Contexto.Attach(obj.Usuario);
                }
            }
            //Contexto.Entry(obj.Usuario).State = EntityState.Unchanged;

            Contexto.Auditorias.Add(obj);
            Contexto.SaveChanges();
        }

        public IEnumerable<Auditoria> FindAll()
        {
            return Contexto.Auditorias.ToList();
        }

        public Auditoria FindById(int id)
        {
            return Contexto.Auditorias.FirstOrDefault(a => a.Id == id);
        }
        public IEnumerable<Auditoria> ListadoAuditoriasDeUnTipoDeGasto(int idGasto)
        {
            return Contexto.Auditorias
                .Include(a => a.Usuario)
                .Where(a => a.IdGasto == idGasto)
                .ToList();
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditoria obj)
        {
            throw new NotImplementedException();
        }
    }
}
