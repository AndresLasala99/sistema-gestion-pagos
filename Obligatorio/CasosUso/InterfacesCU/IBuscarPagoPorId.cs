using CasosUso.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.InterfacesCU
{
    public interface IBuscarPagoPorId
    {
        public PagoDTO Buscar(int id);
    }
}
