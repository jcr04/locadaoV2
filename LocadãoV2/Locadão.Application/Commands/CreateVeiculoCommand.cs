using System;

namespace Locadao.Application.Commands.Veiculos;

public class CreateVeiculoCommand
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int AnoFabricacao { get; set; }
    public string Placa { get; set; }
    public string Cor { get; set; }
    public double Quilometragem { get; set; }
    public bool Automatico { get; set; }
    public bool DisponivelParaAluguel { get; set; }
    public Guid AgenciaId { get; set; }
}

public class UpdateVeiculoCommand 
{
    public Guid Id { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int AnoFabricacao { get; set; }

    public string Placa { get; set;}

    public string Cor { get; set; }

}

public class DeleteVeiculoCommand
{
    public Guid Id { get; set; }
}

