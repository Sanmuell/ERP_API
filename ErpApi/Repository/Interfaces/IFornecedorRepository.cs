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

        Task<Fornecedor> GetFornecedorByNomeAsync(string nome);

        Task<Fornecedor> GetFornecedorByCpfAsync(string cpf);

        Task<Fornecedor> GetFornecedorByCnpjAsync(string cnpj);

        Task<Fornecedor> GetFornecedorByDataNascimentoAsync(DateTime dataDeNascimento);


    }
}
