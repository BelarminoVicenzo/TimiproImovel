using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

using Timipro.DataAccess.Interfaces;
using Timipro.Models;

namespace Timipro.DataAccess.Repository
{
    public class ImovelRepository : IImovelRepository
    {

        private readonly ApplicationDbContext _context;

        public ImovelRepository(ApplicationDbContext context)
        {
            _context = new ApplicationDbContext();
        }
        public async Task<int> Create(Imovel entity)
        {
            _context.Imovel.Add(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(Imovel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Imovel entity)
        {
            _context.Imovel.Attach(entity);
            _context.Imovel.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<Imovel> Get(object id)
        {
            return await _context.Imovel.FindAsync(id);
        }

        public async Task<List<Imovel>> GetAll()
        {
            return await _context.Imovel
                .Include(c => c.Cliente)
                .Include(t => t.TipoNegocio)
                .ToListAsync();
        }


    }
}
