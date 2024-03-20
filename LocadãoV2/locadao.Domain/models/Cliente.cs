using System;
using System.ComponentModel.DataAnnotations;

namespace locadao.Domain.Models;

public class Cliente
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [Required]
    [Range(18, 99)]
    public int Idade { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string Telefone { get; set; }

    [Required]
    [StringLength(11)]
    public string Cpf { get; set; }

    [Required]
    public bool TemCNH { get; set; }

    [Required]
    public bool IsPCD { get; set; }
}
