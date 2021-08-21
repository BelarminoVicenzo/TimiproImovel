using System.Collections.Generic;
using System.Threading.Tasks;

using Timipro.DataAccess.Interfaces;
using Timipro.Models;

namespace Timipro.BLL.Services
{


    public interface IClienteService
    {
        Task<int> Create(Cliente entity);
        Task<int> Delete(Cliente entity);
        Task<Cliente> Get(int id);
        Task<List<Cliente>> GetAll();
        Task<int> Update(Cliente entity);
        Task<bool> IsCPFExistant(string cpf);
        Task<bool> IsEmailExistant(string email);

    }

    public class ClienteService : IClienteService
    {
        IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Cliente> Get(int id)
        {
            var cliente = await _repo.Get(id);
            if (cliente != null) return cliente;
            else return new Cliente();
        }


        public async Task<int> Create(Cliente entity)
        {
            return await _repo.Create(entity);
        }

        public async Task<int> Update(Cliente entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<int> Delete(Cliente entity)
        {
            return await _repo.Delete(entity);
        }

        public async Task<bool> IsCPFExistant(string cpf)
        {
            return await _repo.IsCPFExistant(cpf);
        }
        public async Task<bool> IsEmailExistant(string email)
        {
            return await _repo.IsEmailExistant(email);
        }

    }
}
