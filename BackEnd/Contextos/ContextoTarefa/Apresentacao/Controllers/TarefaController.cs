using Aplicacao.Comandos.CriarTarefa;
using Microsoft.AspNetCore.Mvc;

namespace Apresentacao.Controllers;

[ApiController]
[Route("tarefas")]
public sealed class TarefaController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CriarAsync(
        [FromBody] CriarTarefaCommand command,
        [FromServices] CriarTarefaCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var response = await handler.HandleAsync(
            command,
            cancellationToken);

        return Created(
            $"/tarefas/{response.Id}",
            response);
    }
}