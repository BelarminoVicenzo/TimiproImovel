using System.Collections.Generic;
using System.Threading.Tasks;

using Timipro.DataAccess.Interfaces;
using Timipro.Models;

namespace Timipro.BLL.Services
{

    public interface IImovelService
    {
        Task<int> Create(Imovel entity);
        Task<int> Delete(Imovel entity);
        Task<Imovel> Get(int id);
        Task<List<Imovel>> GetAll();
        Task<int> Update(Imovel entity);
    }
    public class ImovelService:IImovelService
    {
        IImovelRepository _repo;

        public ImovelService(IImovelRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Imovel>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Imovel> Get(int id)
        {
            var imovel = await _repo.Get(id);
            if (imovel != null) return imovel;
            else return new Imovel();
        }


        public async Task<int> Create(Imovel entity)
        {
            return await _repo.Create(entity);
        }

        public async Task<int> Update(Imovel entity)
        {
            return await _repo.Update(entity);
        }

        public async Task<int> Delete(Imovel entity)
        {
            return await _repo.Delete(entity);
        }

    }

    
}
