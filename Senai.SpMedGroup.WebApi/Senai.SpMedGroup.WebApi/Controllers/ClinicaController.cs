using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Senai.SpMedGroup.WebApi.Repositories;

namespace Senai.SpMedGroup.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clinicaRepository.Listar());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_clinicaRepository.BuscarPorId(id));
        }


        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            _clinicaRepository.Cadastrar(novaClinica);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Clinica clinica)
        {
            Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(id);
            if(clinicaBuscada == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Clinica não encontrada",
                            erro = true
                        }
                    );
            }
            try
            {
                _clinicaRepository.Atualizar(id, clinica);
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
            _clinicaRepository.Deletar(id);
            return Ok("Clinica Deletada");
        }
    }
}