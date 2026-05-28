using Aplicacao.Comandos.AtualizarTarefa;
using Aplicacao.Comandos.ConcluirTarefa;
using Aplicacao.Comandos.CriarTarefa;
using Aplicacao.Comandos.ExcluirTarefa;
using Aplicacao.Comandos.IniciarTarefa;
using Aplicacao.Comandos.ReabrirTarefa;
using Aplicacao.Consultas.ObterPorId;
using Aplicacao.Consultas.ObterTodas;
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
        try
        {
            var response = await handler.HandleAsync(
                command,
                cancellationToken);

            return Created(
                $"/tarefas/{response.Id}",
                response);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = ex.Message
            });
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObterPorIdAsync(
        int id,
        [FromServices] ObterTarefaPorIdQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var query = new ObterTarefaPorIdQuery(id);

        var response = await handler.HandleAsync(
            query,
            cancellationToken);

        if (response is null)
            return NotFound();

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> ListarAsync(
    [FromServices] ListarTarefasQueryHandler handler,
    CancellationToken cancellationToken)
    {
        var query = new ListarTarefasQuery();

        var response = await handler.HandleAsync(query, cancellationToken);

        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> ExcluirAsync(
        int id,
        [FromServices] ExcluirTarefaCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var command = new ExcluirTarefaCommand(id);

        var removido = await handler.HandleAsync(
            command,
            cancellationToken);

        if (!removido)
            return NotFound();

        return NoContent();
    }

    [HttpPut("{id:int}/iniciar")]
    public async Task<IActionResult> IniciarAsync(
        int id,
        [FromServices] IniciarTarefaCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var command = new IniciarTarefaCommand(id);

        var resultado = await handler.HandleAsync(
            command,
            cancellationToken);

        if (!resultado.Sucesso)
        {
            if (resultado.Erro == "Tarefa não encontrada.")
                return NotFound();

            return BadRequest(new
            {
                erro = resultado.Erro
            });
        }

        return NoContent();
    }

    [HttpPut("{id:int}/concluir")]
    public async Task<IActionResult> ConcluirAsync(
        int id,
        [FromServices] ConcluirTarefaCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var command = new ConcluirTarefaCommand(id);

        var resultado = await handler.HandleAsync(
            command,
            cancellationToken);

        if (!resultado.Sucesso)
        {
            if (resultado.Erro == "Tarefa não encontrada.")
                return NotFound();

            return BadRequest(new
            {
                erro = resultado.Erro
            });
        }

        return NoContent();
    }

    [HttpPut("{id:int}/reabrir")]
    public async Task<IActionResult> ReabrirAsync(
        int id,
        [FromServices] ReabrirTarefaCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var command = new ReabrirTarefaCommand(id);

        var resultado = await handler.HandleAsync(
            command,
            cancellationToken);

        if (!resultado.Sucesso)
        {
            if (resultado.Erro == "Tarefa não encontrada.")
                return NotFound();

            return BadRequest(new
            {
                erro = resultado.Erro
            });
        }

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> AtualizarAsync(
        int id,
        [FromBody] AtualizarTarefaCommand request,
        [FromServices] AtualizarTarefaCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var command = new AtualizarTarefaCommand(
            id,
            request.Titulo,
            request.Descricao);

        var resultado = await handler.HandleAsync(
            command,
            cancellationToken);

        if (!resultado.Sucesso)
        {
            if (resultado.Erro == "Tarefa não encontrada.")
                return NotFound();

            return BadRequest(new
            {
                erro = resultado.Erro
            });
        }

        return NoContent();
    }
}