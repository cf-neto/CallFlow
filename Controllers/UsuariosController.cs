using Microsoft.AspNetCore.Mvc;
using CallFlow.Models;
using CallFlow.Data;
using CallFlow.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CallFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/usuario
        [HttpGet]
        public ActionResult<List<Usuario>> GetAllUsers([FromQuery] int adminId, [FromQuery] string senha)
        {
            var admin = _context.Usuarios.FirstOrDefault(u => u.Id == adminId && u.Senha == senha && u.Permissao == Papel.Admin);
            if (admin == null) return Unauthorized("Apenas admins podem visualizar usuários");

            var users = _context.Usuarios.ToList();
            return Ok(users);
        }

        // GET api/usuario/email/
        [HttpGet("email/{email}")]
        public ActionResult<Usuario> GetUserByEmail(string email, [FromQuery] int adminId, [FromQuery] string senha)
        {

            // Verificar se admin existe
            var admin = _context.Usuarios.FirstOrDefault(u => u.Id == adminId && u.Senha == senha && u.Permissao == Papel.Admin);

            if (admin == null) return Unauthorized("Apenas admins podem visualizar usuários");

            var user = _context.Usuarios.FirstOrDefault(u => u.Email == email);
            if (user == null) return NotFound("Usuário não encontrado!");


            return Ok(user);
        }

        // GET api/usuario/id
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUserById(int id, [FromQuery] int adminId, [FromQuery] string senha)
        {

            // Verificar se admin existe
            var admin = _context.Usuarios.FirstOrDefault(u => u.Id == adminId && u.Senha == senha && u.Permissao == Papel.Admin);

            if (admin == null) return Unauthorized("Apenas admins podem visualizar usuários");

            var user = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound("Usuário não encontrado!");


            return Ok(user);
        }



        // POST api/usuario
        [HttpPost]
        public ActionResult<Usuario> CreateUser([FromBody] CreateUserRequest request)
        {
            // Config DTOs
            var adminAuth = request.adminAuth;
            var user = request.User;

            if (user == null) return BadRequest("Ocorreu um erro na solicitação");

            // Verifica se está nulo
            if (adminAuth == null) return Unauthorized("Admin não Informado");

            // Verificar se admin existe
            var admin = _context.Usuarios.FirstOrDefault(u => u.Id == adminAuth.AdminId && u.Senha == adminAuth.Senha);
            if (admin == null) return Unauthorized("Apenas admins podem criar usuários");

            _context.Usuarios.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new {id = user.Id}, user);
        }


        // PUT api/usuario/id
        [HttpPut("{id}")]
        public ActionResult<Usuario> EditUser(int id, [FromBody] AdminUserRequest request)
        {
            // Config DTOs
            var adminAuth = request.AdminAuth;
            var userUpdate = request.User;

            // Verifica se está nulo
            if (adminAuth == null) return Unauthorized("Admin não Informado");

            // Verifica se admin existe
            var admin = _context.Usuarios.FirstOrDefault(u => u.Id == adminAuth.AdminId && u.Senha == adminAuth.Senha);
            if (admin == null) return Unauthorized("Apenas admins podem criar usuários");

            // Verifica se o usuário existe
            var user = _context.Usuarios.Find(id);
            if (user == null) return NotFound("Usuário não encontrado!");

            user.Nome = userUpdate.Nome;
            user.Email = userUpdate.Email;
            user.Senha = userUpdate.Senha;
            user.Grupos = userUpdate.Grupos;
            user.Permissao = userUpdate.Permissao;

            _context.Usuarios.Update(user);
            _context.SaveChanges();

            return NoContent();
        }



        // PUT api/usuario/email/
        [HttpPut("email/{email}")]
        public ActionResult<Usuario> EditUserByEmail(string email, [FromBody] AdminUserRequest request)
        {
            // Config DTOs
            var adminAuth = request.AdminAuth;
            var userUpdate = request.User;

            // Verifica se está nulo
            if (adminAuth == null) return Unauthorized("Admin não Informado");

            // Verifica se admin existe
            var admin = _context.Usuarios.FirstOrDefault(u => u.Id == adminAuth.AdminId && u.Senha == adminAuth.Senha);
            if (admin == null) return Unauthorized("Apenas admins podem criar usuários");

            // Verifica se o usuário existe
            var user = _context.Usuarios.FirstOrDefault(u => u.Email == email);
            if (user == null) return NotFound("Usuário não encontrado!");

            // Modificações
            user.Nome = userUpdate.Nome;
            user.Email = userUpdate.Email;
            user.Senha = userUpdate.Senha;
            user.Grupos = userUpdate.Grupos;
            user.Permissao = userUpdate.Permissao;

            _context.SaveChanges();

            return Ok(user);
        }
    }
}