using Contract.LibroContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface ILibroService
    {
        Task AddLibro(LibroRequest request);
        Task<LibroResponse?> GetLibroByIdAsync(int id);
        Task EditLibroAsync(int id, LibroRequest request);
        Task DeleteLibroAsync(int id);
        Task<List<LibroResponse>> GetAllLibrosAsync();
        Task<List<LibroResponse>> GetLibroByNombreAsync(string nombre);
    }
}
