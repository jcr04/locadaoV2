using locadao.Domain.Models;
using Locadão.Infra.Repository.Agencias;
using Locadão.Infra.Repository.Alugueis;

namespace Locadão.Application.Queries
{
    public class AgenciaQueryService : IAgenciaQueryService
    {
        private readonly IAgenciaRepository _agenciaRepository;
        private readonly IAluguelRepository _aluguelRepository; 

        public AgenciaQueryService(IAgenciaRepository agenciaRepository, IAluguelRepository aluguelRepository)
        {
            _agenciaRepository = agenciaRepository;
            _aluguelRepository = aluguelRepository;
        }

        public async Task<AgenciaDTO> GetAgenciaByIdAsync(Guid id)
        {
            var agencia = await _agenciaRepository.GetAgenciaByIdAsync(id);
            if (agencia == null)
            {
                return null;
            }

            var numeroVeiculos = await _agenciaRepository.CountVeiculosByAgenciaAsync(id);
            var alugueis = await _aluguelRepository.GetAlugueisByAgenciaAsync(id);

            var agenciaDto = new AgenciaDTO
            {
                Id = agencia.Id,
                Nome = agencia.Nome,
                Endereco = agencia.Endereco,
                Telefone = agencia.Telefone,
                NumeroVeiculos = numeroVeiculos,
                Alugueis = alugueis.Select(a => new AluguelDTO
                {
                    Id = a.Id,
                    DataInicio = a.DataInicio,
                    DataFim = a.DataFim,
                    Valor = a.Valor,
                    Status = a.Status
                }).ToList()
            };

            return agenciaDto;
        }


        public async Task<int> CountVeiculosByAgenciaAsync(Guid agenciaId)
        {
            // conta o número de veículos na agência
            return await _agenciaRepository.CountVeiculosByAgenciaAsync(agenciaId);
        }

        public async Task<List<Aluguel>> GetAlugueisByAgenciaAsync(Guid agenciaId)
        {
            // retorna todos os aluguéis da agência
            return await _aluguelRepository.GetAlugueisByAgenciaAsync(agenciaId);
        }
    }
}
