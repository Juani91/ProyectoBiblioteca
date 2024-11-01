using Contract.Interfaces;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.LibroContract
{
    public class LibroMapping : ILibroMapping
    {
        public Libro FromDtoToEntity(LibroRequest request)
        {
            return new Libro
            {
                Titulo = request.Titulo,
                FechaPublicacion = request.FechaPublicacion,
            };
        }
        public LibroResponse FromEntityToResponse(Libro entity)
        {
            return new LibroResponse
            {
                Id = entity.Id,
                Titulo = entity.Titulo,
                FechaPublicacion = entity.FechaPublicacion,
            };
        }
    }
}
