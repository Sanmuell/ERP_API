using ErpApi.Data;
using ErpApi.Dtos;
using ErpApi.Models;
using ErpApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorController(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var fornecedores = await _repository.GetFornecedoresAsync();
            return fornecedores.Any()
                ? Ok(fornecedores)
                : BadRequest("Fornecedor não encontrada");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fornecedor = await _repository.GetFornecedorByIdAsync(id);
            return fornecedor != null
                ? Ok(fornecedor)
                : BadRequest("Fornecedor não encontrada");
        }



        [HttpPost]
        public async Task<IActionResult> Post(Fornecedor fornecedor)
        {
            if (string.IsNullOrEmpty(fornecedor.Nome)) return BadRequest("Dados inválidos");

            _repository.Add(fornecedor);

            return await _repository.SaveChangesAsync()
                ? Ok("Fornecedor adicionada")
                : BadRequest("Erro ao adicionar a Fornecedor");

        }
       


        }
    }

