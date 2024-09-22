using Locadão.Domain.models.DTOs;

public class AluguelDTO
{
    public Guid Id { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public decimal Valor { get; set; }
    public string Status { get; set; }
    
    public string Agencia { get; set; }
    public VeiculoDTO Veiculo { get; set; }

}