using Contract.LibroContract;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Interfaces
{
    public interface ILibroMapping
    {
        Libro FromDtoToEntity(LibroRequest request);
        LibroResponse FromEntityToResponse(Libro entity);
    }
}
