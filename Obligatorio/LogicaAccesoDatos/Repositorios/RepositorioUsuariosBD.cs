using Microsoft.EntityFrameworkCore;
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
    public class RepositorioUsuariosBD : IRepositorioUsuarios
    {
        public ObligatorioContext Contexto { get; set; }
        private static readonly Random random = new Random();

        public RepositorioUsuariosBD(ObligatorioContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Usuario obj)
        {
            if (obj == null) throw new DatosInvalidosException("El usuario no puede ser nulo.");
            if (obj.Rol != RolUsuario.ADMINISTRADOR)
            {
                int posicion = obj.Mail.IndexOf('@');
                string local = obj.Mail.Substring(0, posicion);
                string dominio = obj.Mail.Substring(posicion);

                while (ExisteMail(obj.Mail))
                {
                    int nroRandom = random.Next(1000, 10000); // 1000..9999
                    obj.Mail = local + nroRandom.ToString() + dominio;
                }
                obj.Validar();

                if (obj.Equipo != null)
                {
                    var u = Contexto.Equipos.Find(obj.Equipo.Id);

                    if (u != null)
                    {
                        obj.Equipo = u;
                    }
                    else
                    {
                        Contexto.Attach(obj.Equipo);
                    }
                }

                //Contexto.Entry(obj.Equipo).State = EntityState.Unchanged;

                Contexto.Usuarios.Add(obj);
                Contexto.SaveChanges();
            }
            else
            {
                throw new OperacionInvalidaException("No es posible crear un usuario ADMINISTRADOR.");
            }
        }

        private bool ExisteMail(string mail)
        {
            return FindAll().Any(u => u.Mail == mail);
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios.Include("Equipo").ToList();
        }

        public Usuario FindById(int id)
        {
            Usuario buscado = Contexto.Usuarios.Include("Equipo").FirstOrDefault(u => u.Id == id);
            return buscado;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            obj.Validar();

            Contexto.Usuarios.Update(obj);
            Contexto.SaveChanges();
        }

        public Usuario FindByMail(string mail)
        {
            Usuario buscado = Contexto.Usuarios.Include("Equipo").FirstOrDefault(u => u.Mail == mail);
            return buscado;
        }

        public Usuario Login(string email, string password)
        {
            Usuario buscado=null;

            buscado=Contexto.Usuarios
                    .Where(u => u.Mail==email && u.Pass==password)
                    .FirstOrDefault();

            return buscado;
        }
    }
}
