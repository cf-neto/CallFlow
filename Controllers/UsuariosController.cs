using Microsoft.AspNetCore.Mvc;
using CallFlow.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CallFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> Usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nome = "Carlos Neto", Email = "carlosfdsn@empresa.com", Grupos = new List<string>{ "Desenvolvimento e Aplicações"}, Permissao = Papel.Usuario },
            new Usuario { Id = 2, Nome = "Isabelle Cordeiro", Email = "isacordeiro@empresa.com", Grupos = new List<string>{"Service Desk"}, Permissao = Papel.Admin }
        };

        private static int _nextId = 3;


        // GET api/usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios([FromQuery] int adminId)
        {
            var admin = Usuarios.FirstOrDefault(u => u.Id == adminId && u.Permissao == Papel.Admin);
            if (admin == null) return Unauthorized("Apenas admins podem listar usuários.");

            return Ok(Usuarios);
        }

        // GET api/usuario/id
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id, [FromQuery] int adminId)
        {
            var admin = Usuarios.FirstOrDefault(u => u.Id == adminId && u.Permissao == Papel.Admin);
            if (admin == null) return Unauthorized("Apenas admins podem visualizar usuários.");

            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }


        // POST api/usuario
        [HttpPost]
        public ActionResult<Usuario> Create([FromQuery] int adminId, [FromBody] Usuario novoUsuario)
        {
            var admin = Usuarios.FirstOrDefault(u => u.Id == adminId && u.Permissao == Papel.Admin);
            if (admin == null) return Unauthorized("Apenas admins podem criar usuários");

            novoUsuario.Id = _nextId++;
            Usuarios.Add(novoUsuario);

            return CreatedAtAction(nameof(GetById), new { id = novoUsuario.Id, adminId = adminId }, novoUsuario);
        }

        // PUT api/usuario/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromQuery] int adminId, [FromBody] Usuario usuarioAtualizado)
        {
            var admin = Usuarios.FirstOrDefault(u => u.Id == adminId && u.Permissao == Papel.Admin);
            if (admin == null) return Unauthorized("Apenas admins podem editar usuários");

            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound("Usuário não encontrado");

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Email = usuarioAtualizado.Email;
            usuario.Senha = usuarioAtualizado.Senha;
            usuario.Grupos = usuarioAtualizado.Grupos;
            usuario.Permissao = usuarioAtualizado.Permissao;

            return NoContent();
        }


        // DELETE api/usuario/{id}
        [HttpDelete]
        public ActionResult Delete(int id, [FromQuery] int adminId)
        {
            var admin = Usuarios.FirstOrDefault(u => u.Id == adminId && u.Permissao == Papel.Admin);
            if (admin == null) return Unauthorized("Apenas admins podem deletar usuários");

            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound("Usuário não encontrado");

            Usuarios.Remove(usuario);

            return NoContent();
        }



        // POST api/usuario/{id}/adicionar-grupo?adminId=1
        [HttpPost("{id}/adicionar-grupo")]
        public ActionResult AdicionarGrupo(int id, [FromQuery] int adminId, [FromBody] string grupo)
        {
            var admin = Usuarios.FirstOrDefault(u => u.Id == adminId && u.Permissao == Papel.Admin);
            if (admin == null) return Unauthorized("Apenas admins podem adicionar grupo para os usuários.");

            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound("Usuário não encontrado.");

            if (usuario.Grupos == null) usuario.Grupos = new List<string>();

            if (!usuario.Grupos.Contains(grupo))
            {
                usuario.Grupos.Add(grupo);
            }

            return Ok(usuario.Grupos);
        }


        // DELETE api/usuario/{id}/remover-grupo?adminId=1
        [HttpDelete("{id}/adicionar-grupo")]
        public ActionResult RemoverGrupo(int id, [FromQuery] int adminId, [FromBody] string grupo)
        {
            var admin = Usuarios.FirstOrDefault(u => u.Id == adminId && u.Permissao == Papel.Admin);
            if (admin == null) return Unauthorized("Apenas admins podem remover grupo dos usuários.");

            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound("Usuário não encontrado.");

            if (usuario.Grupos == null) usuario.Grupos = new List<string>();

            if (!usuario.Grupos.Contains(grupo))
            {
                usuario.Grupos.Remove(grupo);
            }

            return Ok(usuario.Grupos);
        }

    }
}