using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

using Timipro.DataAccess.Interfaces;
using Timipro.Models;

namespace Timipro.DataAccess.Repository
{

    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = new ApplicationDbContext();
        }
        public async Task<int> Create(Cliente entity)
        {
            _context.Cliente.Add(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(Cliente entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Cliente entity)
        {
            _context.Cliente.Attach(entity);
            _context.Cliente.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<Cliente> Get(object id)
        {
            return await _context.Cliente.FindAsync(id);   
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Cliente.ToListAsync();
        }

    }
}
