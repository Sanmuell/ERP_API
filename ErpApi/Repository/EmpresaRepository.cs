using ErpApi.Data;
using ErpApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Repository
{
    public class EmpresaRepository : BaseRepository, IEmpresaRepository
    {
        private readonly DataContext _context;
        public EmpresaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empresa>> GetEmpresasAsync()
        {
            return await _context.Empresas.ToListAsync();

            
        }

        public async Task<Empresa> GetEmpresaByIdAsync(int id)
        {
            return await _context.Empresas.Include(x => x.Fornecedores)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
