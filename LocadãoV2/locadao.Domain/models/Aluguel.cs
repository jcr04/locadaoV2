using locadao.Domain.Models;
using System.ComponentModel.DataAnnotations;

public class Aluguel
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; }

    [Required]
    public Guid VeiculoId { get; set; }
    public virtual Veiculo Veiculo { get; set; }

    [Required]
    public Guid AgenciaId { get; set; }
    public virtual Agencia Agencia { get; set; }

    [Required]
    public DateTime DataInicio { get; set; }

    [Required]
    public DateTime DataFim { get; set; }

    public decimal Valor { get; set; }

    public string Status { get; set; } // Ativo, Finalizado, Cancelado, etc.

    // Outras propriedades e detalhes do aluguel podem ser adicionados aqui
}