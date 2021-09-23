using Consultorio.Models.Entities;
using Consultorio.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IEmailService _emailService;
        List<Agendamento> agendamentos = new List<Agendamento>();
        public AgendamentoController(IEmailService emailSerce)
        {

            agendamentos.Add(new Agendamento { Id = 1, NomePaciente = "Tiago Mabango", Horario = new DateTime(2021, 09, 17) });
            _emailService = emailSerce;
        }
        [HttpGet]
        public IActionResult Get(){

            return Ok(agendamentos);
        }

        [HttpGet("buscar-agendamento/{id}")]
        public IActionResult GetById(int id)
        {
            var agendamentoSelecionado = agendamentos.FirstOrDefault(x => x.Id == id);
            return agendamentoSelecionado !=null ?  Ok(agendamentos) : BadRequest("Erro ao buscar o agendamento");
        }

        [HttpPost]
        public IActionResult Post()
        {
            var pacienteAgendado = true;
            if (pacienteAgendado)
            {
                _emailService.EnviarEmail("tiagomabango@gmail.com");
            }
            return Ok();
        }
    }
}
