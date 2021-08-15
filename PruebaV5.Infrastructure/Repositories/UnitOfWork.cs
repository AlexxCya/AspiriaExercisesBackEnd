using PruebaV5.Core.Entities;
using PruebaV5.Core.Interfaces;
using PruebaV5.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaV5.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PruebaV5BDContext _context;
        private readonly IRepository<Toy> _toyRepository;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(PruebaV5BDContext context)
        {
            _context = context;
        }
        public IRepository<Toy> ToyRepository => _toyRepository ?? new BaseRepository<Toy>(_context);

        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
