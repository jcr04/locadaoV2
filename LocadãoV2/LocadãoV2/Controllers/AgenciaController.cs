using Microsoft.AspNetCore.Mvc;
using Locadao.Application.Commands.Agencias;
using Locadao.Application.Interfaces.Commands;
using Locadão.Application.Queries;

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
            var agencia = await _agenciaQueryService.GetAgenciaByIdAsync(agenciaId);

            return CreatedAtAction(nameof(GetById), new { id = agenciaId }, agencia);
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
            var agencia = await _agenciaQueryService.GetAgenciaByIdAsync(id);
            if (agencia == null)
            {
                return NotFound();
            }

            return Ok(agencia);
        }
    }
}
