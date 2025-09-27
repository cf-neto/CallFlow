using System;
using System.ComponentModel.DataAnnotations;

namespace CallFlow.Models
{
    public class Chamado
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Área é obrigatório")]
        public string Area { get; set; } = ""; // Apenas uma área por chamado
        
        public string Status { get; set; } = "Aberto";
        public DateTime DataAbertura { get; set; } = DateTime.Now;
        public DateTime? DataFechamento { get; set; }
    }
}