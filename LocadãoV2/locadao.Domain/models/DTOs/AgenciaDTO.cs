public class AgenciaDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public int NumeroVeiculos { get; set; } // Quantidade de veículos
    public List<AluguelDTO> Alugueis { get; set; } // Lista de aluguéis
}