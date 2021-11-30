using AutoMapper;
using ErpApi.Data;
using ErpApi.Dtos;
using ErpApi.Models;
using ErpApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                : BadRequest("Empresa não encontrada");
        }



        [HttpPost]
        public async Task<IActionResult> Post(Empresa empresa)
        {
            if (string.IsNullOrEmpty(empresa.NomeFantasia)) return BadRequest("Dados inválidos");

            _repository.Add(empresa);

            return await _repository.SaveChangesAsync()
                ? Ok("Empresa adicionada")
                : BadRequest("Erro ao adicionar a Empresa");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EmpresaDto empresaDto)
        {

            if (id <= 0) return BadRequest("Empresa não informada");

            var empresaAtualiza = await _repository.GetEmpresaByIdAsync(id);

            if (empresaAtualiza == null)

                return BadRequest("Empresa não encontrada na base de dados");

            empresaAtualiza.NomeFantasia = empresaDto.NomeFantasia;
            empresaAtualiza.Uf = empresaDto.Uf;
            empresaAtualiza.Cnpj = empresaDto.Cnpj;

            _repository.Update(empresaAtualiza);

            if (!await _repository.SaveChangesAsync())
                return NoContent();

            return Ok(empresaAtualiza);

        }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                if (id <= 0) return BadRequest("Empresa não informada");

                var empresaBanco = await _repository.GetEmpresaByIdAsync(id);

                if (empresaBanco == null)
                    return NotFound("Empresa não encontrada na base de dados");

                _repository.Delete(empresaBanco);

                return await _repository.SaveChangesAsync()
                    ? Ok("Empresa deletada")
                    : BadRequest("Erro ao deletar o Empresa");


            }
    }
}
    