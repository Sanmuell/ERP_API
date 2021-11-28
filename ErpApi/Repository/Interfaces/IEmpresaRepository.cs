using ErpApi.Models;
using ErpApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Repository
{
    public interface IEmpresaRepository : IBaseRepository
    {

        Task<IEnumerable<Empresa>> GetEmpresasAsync();

        Task<Empresa> GetEmpresaByIdAsync(int id);


    }
}
