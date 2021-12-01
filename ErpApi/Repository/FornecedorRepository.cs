using ErpApi.Data;
using ErpApi.Models;
using ErpApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Repository
{
    public class FornecedorRepository : BaseRepository, IFornecedorRepository
    {

        private readonly DataContext _context;
        public FornecedorRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Fornecedor> GetFornecedorByCnpjAsync(string cnpj)
        {
            return await _context.Fornecedores.Include(x => x.Empresa)
                 .Where(x => x.Cnpj == cnpj).FirstOrDefaultAsync(); ;
        }

        public async Task<Fornecedor> GetFornecedorByCpfAsync(string cpf)
        {
            return await _context.Fornecedores.Include(x => x.Empresa)
                  .Where(x => x.Cpf == cpf).FirstOrDefaultAsync(); 
        }

        public async Task<Fornecedor> GetFornecedorByDataNascimentoAsync(DateTime dataDeNascimento)
        {
            
            return await _context.Fornecedores.Include(x => x.Empresa)
                   .Where(x => x.DataNascimento == dataDeNascimento).FirstOrDefaultAsync();
        }

        public async Task<Fornecedor> GetFornecedorByIdAsync(int id)
        {
            return await _context.Fornecedores.Include(x => x.Empresa)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Fornecedor> GetFornecedorByNomeAsync(string nome)
        {
            return await _context.Fornecedores.Include(x => x.Empresa)
                .Where(x => x.Nome == nome).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Fornecedor>> GetFornecedoresAsync()
        {
            return await _context.Fornecedores.Include(x => x.Empresa).ToListAsync();
        }
    }
}
