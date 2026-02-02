using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using ExcepcionesPropias.Excepciones;
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
    public class CUResetearPass : IResetearPass
    {
        public IRepositorioUsuarios Repo { get; set; }

        public CUResetearPass(IRepositorioUsuarios repo)
        {
            Repo = repo;
        }

        public UsuarioDTO Ejecutar(int idUsuario)
        {
            Usuario u = Repo.FindById(idUsuario);
            if (u == null)
            {
                throw new DatosInvalidosException("El usuario no existe.");
            }

            string nuevaPass = GenerarPassAleatoria();
            u.CambiarPass(nuevaPass);
            Repo.Update(u);

            // Mapeamos a DTO y dejamos la pass nueva
            UsuarioDTO dto = MapperUsuario.ToDTO(u);
            dto.Pass = nuevaPass;

            return dto;
        }

        private string GenerarPassAleatoria()
        {
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int largo = 10;

            Random r = new Random();
            char[] buffer = new char[largo];

            for (int i = 0; i < largo; i++)
            {
                int indice = r.Next(caracteres.Length);
                buffer[i] = caracteres[indice];
            }

            return new string(buffer);
        }
    }
}