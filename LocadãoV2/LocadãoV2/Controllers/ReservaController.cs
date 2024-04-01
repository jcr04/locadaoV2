using Microsoft.AspNetCore.Mvc;
using Locadão.Application.Commands;
using Locadão.Application.Queries;
using Locadao.Application.Interfaces.Commands;


namespace Locadão.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly IReservaQueryService _reservaQueryService;
    private readonly ICommandHandler<CreateReservaCommand> _createReservaHandler;
    // Adicione handlers para outros comandos conforme necessário, por exemplo, CancelarReservaCommand

    public ReservasController(
        IReservaQueryService reservaQueryService,
        ICommandHandler<CreateReservaCommand> createReservaHandler)
    {
        _reservaQueryService = reservaQueryService;
        _createReservaHandler = createReservaHandler;
        // Inicialize outros handlers aqui
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservaCommand command)
    {
        try
        {
            var reservaId = await _createReservaHandler.HandleAsync(command);
            var reserva = await _reservaQueryService.GetReservaByIdAsync(reservaId);
            return CreatedAtAction(nameof(GetById), new { id = reservaId }, reserva);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var reserva = await _reservaQueryService.GetReservaByIdAsync(id);
        if (reserva == null) return NotFound();
        return Ok(reserva);
    }

    // Adicione endpoints para outras operações, como cancelar reserva, listar reservas de um cliente, etc.
}
