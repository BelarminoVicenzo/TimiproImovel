using System.Collections.Generic;
using System.Threading.Tasks;
using Timipro.DataAccess.Interfaces;
using Timipro.Models;

namespace Timipro.BLL.Services
{

    public interface ITipoNegocioService
    {

        Task<TipoNegocio> Get(int id);
        Task<List<TipoNegocio>> GetAll();

    }


    public class TipoNegocioService : ITipoNegocioService
    {
        ITipoNegocioRepository _repo;

        public TipoNegocioService(ITipoNegocioRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TipoNegocio>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<TipoNegocio> Get(int id)
        {
            var tpn = await _repo.Get(id);
            if (tpn != null) return tpn;
            else return new TipoNegocio();
        }
         
    }

    
}
