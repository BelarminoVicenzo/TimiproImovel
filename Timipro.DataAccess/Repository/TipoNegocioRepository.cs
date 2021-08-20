using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

using Timipro.DataAccess.Interfaces;
using Timipro.Models;

namespace Timipro.DataAccess.Repository
{
    public class TipoNegocioRepository : ITipoNegocioRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoNegocioRepository(ApplicationDbContext context)
        {
            _context = new ApplicationDbContext();
        }
        public async Task<int> Create(TipoNegocio entity)
        {
             
            throw new System.NotImplementedException();
        }
        public async Task<int> Update(TipoNegocio entity)
        {
             
            throw new System.NotImplementedException();
        }

        public async Task<int> Delete(TipoNegocio entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TipoNegocio> Get(object id)
        {
            return await _context.TipoNegocio.FindAsync(id);   
        }

        public async Task<List<TipoNegocio>> GetAll()
        {
            return await _context.TipoNegocio.ToListAsync();
        }
 
    }
}
