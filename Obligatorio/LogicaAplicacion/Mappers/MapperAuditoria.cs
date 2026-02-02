using CasosUso.DTOs;
using ExcepcionesPropias.Excepciones;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    public class MapperAuditoria
    {
        public static Auditoria ToAuditoria(AuditoriaDTO dto)
        {
            Auditoria a = new Auditoria();
            a.Id = dto.Id;
            a.Accion=dto.Accion;
            a.Fecha=dto.Fecha;
            a.Usuario = new Usuario { Id = dto.IdUsuario };
            a.IdGasto = dto.IdGasto;

            return a;
        }
        public static AuditoriaDTO ToDto(Auditoria a)
        {
            AuditoriaDTO dto = new AuditoriaDTO();

            dto.Id = a.Id;
            dto.IdGasto = a.IdGasto;
            dto.IdUsuario = a.Usuario.Id;
            dto.Fecha = a.Fecha;
            dto.Accion = a.Accion;
            return dto;
        }

        public static List<AuditoriaDTO> ToListaDTO(IEnumerable<Auditoria> lista)
        {
            var resultado = lista
                .Select(a => ToDto(a))
                .ToList();
            return resultado;
        }
    }
}
