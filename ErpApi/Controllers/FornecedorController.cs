using ErpApi.Data;
using ErpApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Controllers
{

    [Route("fornecedores")]
    public class FornecedorController : Controller

    { 

     [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Fornecedor>>> Get(
            [FromServices] DataContext context
           )
    {
        var fornecedors = await context
                .Fornecedores
                .ToListAsync();
        return fornecedors;
    }



    [HttpPost]
    [Route("")]
    public async Task<ActionResult<List<Fornecedor>>> Post(
[FromBody] Fornecedor model,
[FromServices] DataContext context
)
    {

      //  if (!ModelState.IsValid)
         //   return BadRequest(ModelState);

       // try
       // {
            context.Fornecedores.Add(model);
            await context.SaveChangesAsync(); //persist
            return Ok(model);
       // }
        //catch (Exception)
      //  {
           // return BadRequest(new { message = "Não foi possível criar Fornecedor" });
//}
    }
}
}