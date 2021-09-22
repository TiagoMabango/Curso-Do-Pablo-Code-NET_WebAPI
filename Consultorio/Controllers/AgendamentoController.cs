using Consultorio.Models.Entities;
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
        List<Agendamento> agendamentos = new List<Agendamento>();
        public AgendamentoController()
        {

            agendamentos.Add(new Agendamento { Id = 1, NomePaciente = "Tiago Mabango", Horario = new DateTime(2021, 09, 17) });
        }
        [HttpGet]
        public IActionResult Get(){

            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var agendamentoSelecionado = agendamentos.FirstOrDefault(x => x.Id == id);
            return agendamentoSelecionado !=null ?  Ok(agendamentos) : BadRequest("Erro ao buscar o agendamento");
        }
    }
}
