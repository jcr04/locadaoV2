using locadao.Domain.Models;

namespace Locadão.Domain.models;

public class Reserva
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; }
    public Guid VeiculoId { get; set; }
    public virtual Veiculo Veiculo { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Status { get; set; } // Confirmada, Pendente, Cancelada
}
