using Microsoft.AspNetCore.Mvc;
using CallFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace CallFlow.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoController : ControllerBase
    {

        // Lista de usuários
        private static List<Usuario> Usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nome = "Carlos Neto", Email = "carlosfdsn@empresa.com", Grupos = new List<string>{ "Desenvolvimento e Aplicações"}, Permissao = Papel.Usuario },
            new Usuario { Id = 2, Nome = "Isabelle Cordeiro", Email = "isacordeiro@empresa.com", Grupos = new List<string>{"Service Desk"}, Permissao = Papel.Admin }
        };


        private static readonly List<Chamado> chamados = new List<Chamado>();
        private static int _nextId = 1;


        // GET api/chamados?usuariosId=1
        [HttpGet]
        public ActionResult<IEnumerable<Chamado>> GetChamadosUsuarios([FromQuery] int usuarioId)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (usuario == null) return NotFound("Usuário não encontrado!");

            var chamadosVisiveis = chamados.Where(c => usuario.Grupos.Contains(c.Area));
            
            return Ok(chamadosVisiveis);
        }

        // GET api/chamados/{id}
        [HttpGet("{id}")]
        public ActionResult<Chamado> GetById(int id)
        {
            var chamado = chamados.FirstOrDefault(c => c.Id == id);
            if (chamado == null) return NotFound();
            return Ok(chamados);
        }

        // POST api/chamados
        [HttpPost]
        public ActionResult<Chamado> Create([FromBody] Chamado chamado)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            chamado.Id = _nextId++;
            chamado.Status = "Aberto";
            chamado.DataAbertura = DateTime.Now;

            chamados.Add(chamado);

            return CreatedAtAction(nameof(GetById), new { id = chamado.Id }, chamado);

        }

        // PUT api/chamados/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Chamado chamadoAtualizado)
        {
            var chamado = chamados.FirstOrDefault(c => c.Id == id);

            if (chamado == null) return NotFound(new { message = "Chamado não encontrado" });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            chamado.Nome = chamadoAtualizado.Nome;
            chamado.Email = chamadoAtualizado.Email;
            chamado.Titulo = chamadoAtualizado.Titulo;
            chamado.Descricao = chamadoAtualizado.Descricao;
            chamado.Status = chamadoAtualizado.Status;
            chamado.DataFechamento = chamadoAtualizado.DataFechamento;

            return NoContent();
        }

        // DELETE api/chamados/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var chamado = chamados.FirstOrDefault(c => c.Id == id);
            if (chamado == null) return NotFound(new { message = "Chamado não encontrado" });

            chamados.Remove(chamado);

            return NoContent();
        }
    }
}