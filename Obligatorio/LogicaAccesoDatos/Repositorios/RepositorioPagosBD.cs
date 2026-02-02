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
    public class RepositorioPagosBD : IRepositorioPagos
    {
        public ObligatorioContext Contexto { get; set; }

        public RepositorioPagosBD(ObligatorioContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Pago obj)
        {
            if (obj == null) throw new DatosInvalidosException("El pago no puede ser nulo.");
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

            if (obj.Gasto != null)
            {
                var g = Contexto.Gastos.Find(obj.Gasto.Id);

                if (g != null)
                {
                    obj.Gasto = g;
                }
                else
                {
                    Contexto.Attach(obj.Gasto);
                }
            }
            //Contexto.Entry(obj.Gasto).State = EntityState.Unchanged;

            Contexto.Pagos.Add(obj);
            Contexto.SaveChanges();
        }

        public IEnumerable<Pago> FindAll()
        {
            return Contexto.Pagos.Include("Usuario.Equipo").Include("Gasto").ToList();
        }
        public IEnumerable<Usuario> UsuariosConPagosUnicoSuperioresA(double monto)
        {
            var lista = FindAll().OfType<Unico>().Where(u => u.Monto > monto).Select(u => u.Usuario).Distinct();
            return lista;
        }
        public IEnumerable<Pago> ListadoMensualDePagos(int mes, int anio)
        {
            if (mes < 1 || mes > 12) throw new DatosInvalidosException("El mes que se ingresó es incorrecto.");
            if (anio < 1) throw new DatosInvalidosException("El año que se ingresó es incorrecto.");

            int anioMes = anio * 100 + mes;

            return FindAll()
                .Where(p =>
                    (p is Unico u && u.Fecha.Year == anio && u.Fecha.Month == mes) ||
                    (p is Recurrente r &&
                        (r.FechaInicio.Year * 100 + r.FechaInicio.Month) <= anioMes &&
                        (r.FechaFin.Year * 100 + r.FechaFin.Month) >= anioMes)
                )
                .ToList();
        }
        public bool ExistePagoConTipoGasto(int gastoId)
        {
            return FindAll().Any(p => p.Gasto != null && p.Gasto.Id == gastoId);
        }

        public IEnumerable<Pago> ListadoPagosDeUnUsuario(int idUsuario)
        {
            var resultado= Contexto.Pagos
                            .Include(p => p.Gasto)
                            .Include(p => p.Usuario)
                            .Where(p => p.Usuario.Id == idUsuario)
                            .ToList();
            return resultado;
        }

        public IEnumerable<Equipo> ListadoEquiposConPagosUnicosMayoresA(double monto)
        {
            var resultado=Contexto.Pagos
                            .Where(p => p is Unico)
                            .Where(p => p.Monto > monto)
                            .Select(p => p.Usuario.Equipo)
                            .Distinct()
                            .OrderByDescending(e => e.Nombre)
                            .ToList();
            return resultado;
        }

        public void Update(Pago obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        public Pago FindById(int id)
        {
            return Contexto.Pagos
                    .Include(p => p.Usuario)
                    .ThenInclude(u => u.Equipo)
                    .Include(p => p.Gasto)
                    .SingleOrDefault(p => p.Id == id);
        }
    }
}
