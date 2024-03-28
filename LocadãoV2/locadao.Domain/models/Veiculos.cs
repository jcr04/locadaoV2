using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locadao.Domain.Models;

public class Veiculo
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(50)]
    public string Marca { get; set; }

    [Required]
    [StringLength(50)]
    public string Modelo { get; set; }

    [Required]
    [Range(1900, 2100)]
    public int AnoFabricacao { get; set; }

    [Required]
    [StringLength(7)]
    public string Placa { get; set; }

    [Required]
    [StringLength(30)]
    public string Cor { get; set; }

    [Required]
    public double Quilometragem { get; set; }

    [Required]
    public bool Automatico { get; set; }

    [Required]
    public bool DisponivelParaAluguel { get; set; }

    public bool AdaptadoParaPCD { get; set; }

    [Required]
    public Guid AgenciaId { get; set; }

    [ForeignKey("AgenciaId")]
    public virtual Agencia Agencia { get; set; }
}
