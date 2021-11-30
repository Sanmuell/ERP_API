using ErpApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Repository.Interfaces
{
    public interface IFornecedorRepository : IBaseRepository
    {

        Task<IEnumerable<Fornecedor>> GetFornecedoresAsync();

        Task<Fornecedor> GetFornecedorByIdAsync(int id);


    }
}
