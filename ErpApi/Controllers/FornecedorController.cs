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

        [HttpGet("/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fornecedor = await _repository.GetFornecedorByIdAsync(id);
            return fornecedor != null
                ? Ok(fornecedor)
                : BadRequest("Fornecedor não encontrada");
        }

        


        [HttpGet  ("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            var fornecedor = await _repository.GetFornecedorByNomeAsync(nome);
            return fornecedor != null
                ? Ok(fornecedor)
                : BadRequest("Fornecedor não encontrado");
        }

        [HttpGet("/cpf/{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            var fornecedor = await _repository.GetFornecedorByCpfAsync(cpf);
            return fornecedor != null
                ? Ok(fornecedor)
                : BadRequest("Fornecedor não encontrada");
        }

        [HttpGet("/cnpj/{cnpj}")]
        public async Task<IActionResult> GetByCnpj(string cnpj)
        {
            var fornecedor = await _repository.GetFornecedorByCnpjAsync(cnpj);
            return fornecedor != null
                ? Ok(fornecedor)
                : BadRequest("Fornecedor não encontrada");
        }

        [HttpGet("/dataNascimento/{dataNascimento:datetime}")]
        public async Task<IActionResult> GetBydataNascimento(DateTime dataNascimento)
        {
            var fornecedor = await _repository.GetFornecedorByDataNascimentoAsync(dataNascimento);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Fornecedor fornecedor)
        {

            if (id <= 0) return BadRequest("Empresa não informada");

            var fornecedorAtualiza = await _repository.GetFornecedorByIdAsync(id);

            if (fornecedorAtualiza == null)

                return BadRequest("Fornecedor não encontrado na base de dados");

            fornecedorAtualiza.Nome = fornecedor.Nome;
            fornecedorAtualiza.TipoPessoa = fornecedor.TipoPessoa;
            fornecedorAtualiza.Cpf = fornecedor.Cpf;
            fornecedorAtualiza.Rg = fornecedor.Rg;
            fornecedorAtualiza.Cnpj = fornecedor.Cnpj;
            fornecedorAtualiza.DataeHoraCadastro = fornecedor.DataeHoraCadastro;
            fornecedorAtualiza.DataNascimento = fornecedor.DataNascimento;
            fornecedorAtualiza.Telefone = fornecedor.Telefone;


            _repository.Update(fornecedorAtualiza);

            if (!await _repository.SaveChangesAsync())
                return NoContent();

            return Ok(fornecedorAtualiza);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Fornecedor não informado");

            var fornecedorBanco = await _repository.GetFornecedorByIdAsync(id);

            if (fornecedorBanco == null)
                return NotFound("Empresa não encontrada na base de dados");

            _repository.Delete(fornecedorBanco);

            return await _repository.SaveChangesAsync()
                ? Ok("Fornecedor deletado")
                : BadRequest("Erro ao deletar fornecedor");

        }
    }
}
