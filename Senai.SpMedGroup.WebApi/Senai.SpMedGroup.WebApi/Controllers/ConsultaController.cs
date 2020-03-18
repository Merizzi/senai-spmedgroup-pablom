using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using Senai.SpMedGroup.WebApi.Repositories;

namespace Senai.SpMedGroup.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_consultaRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_consultaRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            // Faz a chamada para o método
            _consultaRepository.Cadastrar(novaConsulta);

            // Retorna um status code
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Consulta consulta)
        {
            Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);

            if (consultaBuscada == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Consulta não encontrada",
                            erro = true
                        }
                    );
            }
            try
            {
                _consultaRepository.Atualizar(id, consulta);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _consultaRepository.Deletar(id);
            return Ok("Consulta Deletada");
        }
    }
}