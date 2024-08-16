using Microsoft.AspNetCore.Mvc;
using Locadao.Application.Commands.Agencias;
using Locadao.Application.Interfaces.Commands;
using Locadão.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace Locadão.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgenciaController : ControllerBase
    {
        private readonly ICommandHandler<CreateAgenciaCommand> _createAgenciaHandler;
        private readonly ICommandHandlerDelete<DeleteAgenciaCommand> _deleteAgenciaHandler;
        private readonly IAgenciaQueryService _agenciaQueryService;

        public AgenciaController(
            ICommandHandler<CreateAgenciaCommand> createAgenciaHandler,
            ICommandHandlerDelete<DeleteAgenciaCommand> deleteAgenciaHandler,
            IAgenciaQueryService agenciaQueryService)
        {
            _createAgenciaHandler = createAgenciaHandler;
            _deleteAgenciaHandler = deleteAgenciaHandler;
            _agenciaQueryService = agenciaQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAgenciaCommand command)
        {
            var agenciaId = await _createAgenciaHandler.HandleAsync(command);
            var agenciaDto = await _agenciaQueryService.GetAgenciaByIdAsync(agenciaId);

            return CreatedAtAction(nameof(GetById), new { id = agenciaId }, agenciaDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAgenciaCommand { Id = id };
            await _deleteAgenciaHandler.HandleAsync(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var agenciaDto = await _agenciaQueryService.GetAgenciaByIdAsync(id);
            if (agenciaDto == null)
            {
                return NotFound();
            }


            var countVeiculos = await _agenciaQueryService.CountVeiculosByAgenciaAsync(id);
            var alugueis = await _agenciaQueryService.GetAlugueisByAgenciaAsync(id);

            var result = new
            {
                Agencia = agenciaDto,
                NumeroVeiculos = countVeiculos,
                Alugueis = alugueis.Select(a => new
                {
                    a.Id,
                    a.DataInicio,
                    a.DataFim,
                    a.Valor,
                    a.Status,
                    Veiculo = new { a.Veiculo.Marca, a.Veiculo.Modelo, a.Veiculo.Placa, Agencia = a.Agencia.Nome }
                })
            };

            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAgenciaIds()
        {
            var agencias = await _agenciaQueryService.GetAllAgenciasAsync();

            var agenciaIds = agencias.Select(a => a.Id).ToList();

            return Ok(agenciaIds);
        }

    }
}
