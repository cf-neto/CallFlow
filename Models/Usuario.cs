using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CallFlow.Models
{
    public enum Papel
    {
        Usuario,
        Admin
    }
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string? Senha { get; set; }
        public List<string> Grupos { get; set; } = new();
        public Papel Permissao { get; set; } = Papel.Usuario;
    }
}