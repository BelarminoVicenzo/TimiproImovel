using System.Threading.Tasks;

using Timipro.Models;

namespace Timipro.DataAccess.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<bool> IsCPFExistant(string cpf);
        Task<bool> IsEmailExistant(string cpf);
    }
}
