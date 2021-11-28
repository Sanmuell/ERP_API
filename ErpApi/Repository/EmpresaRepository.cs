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

        public IEnumerable<Empresa> GetEmpresas()
        {
            return _context.Empresas.ToList();

            
        }

        public Empresa GetEmpresaById(int id)
        {
            return _context.Empresas.Include(x => x.Fornecedores)
                .Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
