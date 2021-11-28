using ErpApi.Data;
using ErpApi.Models;
using ErpApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Controllers
{

    [Route("empresas")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository _repository;
       
        public EmpresaController(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var empresas = await _repository.GetEmpresasAsync();
            return empresas.Any()
                ? Ok(empresas)
                : BadRequest("Empresa não encontrada");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empresa = await _repository.GetEmpresaByIdAsync(id);
            return empresa != null
                ? Ok(empresa)
                : BadRequest("Erpresa não encontrada");
        }





        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Empresa>>> Post(
   [FromBody] Empresa model,
   [FromServices] DataContext context
   )
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

          //  try
           // {
                context.Empresas.Add(model);
                await context.SaveChangesAsync(); //persist
                return Ok(model);
          //  }
          //  catch (Exception)
          //  {
          // //     return BadRequest(new { message = "Não foi possível criar Empresa" });
            //}
        }
    }
}
