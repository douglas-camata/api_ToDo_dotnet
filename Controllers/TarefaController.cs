using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_API_ToDo.Context;
using dio_API_ToDo.Models;
using Microsoft.AspNetCore.Mvc;

namespace dio_API_ToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        public readonly BDTarefasContext _context;

        public TarefaController(BDTarefasContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }
        
        [HttpGet("{id}")]
        public IActionResult ObterId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();
            
            return Ok(tarefa);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            return Ok(_context.Tarefas.ToList());
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefas = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));

            if (tarefas == null)
                return NotFound();

            return Ok(tarefas);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefas = _context.Tarefas.Where(x => x.Data.Date == data.Date);

            if (tarefas == null)
                return NotFound();

            return Ok(tarefas);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefas = _context.Tarefas.Where(x => x.Status == status);

            if (tarefas == null)
                return NotFound();

            return Ok(tarefas);
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var novaTarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();

            novaTarefa.Descricao = tarefa.Descricao;    
            novaTarefa.Titulo = tarefa.Titulo;
            novaTarefa.Status = tarefa.Status;
            novaTarefa.Data = tarefa.Data;

            _context.Update(novaTarefa);
            _context.SaveChanges();
            return Ok(novaTarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();
            
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();

        }
    }
}