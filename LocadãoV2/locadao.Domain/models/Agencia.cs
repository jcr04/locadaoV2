using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace locadao.Domain.Models
{
    public class Agencia
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        public List<Veiculo> Veiculos { get; set; }

        public List<Aluguel> Alugueis { get; set; }

        public Agencia()
        {
            Veiculos = new List<Veiculo>();
            Alugueis = new List<Aluguel>();
        }
    }
}
