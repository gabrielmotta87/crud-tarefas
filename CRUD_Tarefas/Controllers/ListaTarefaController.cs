using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Models.Errors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CRUD_Tarefas.Controllers;

[ApiController]
[Route("api")]
public class ListaTarefaController : ControllerBase
{
    private readonly IListaTarefaService _listaTarefaService;

    public ListaTarefaController(IListaTarefaService listaTarefaService)
    {
        _listaTarefaService = listaTarefaService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ListaTarefaResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Busca todas as listas de tarefas.")]
    public async Task<IActionResult> BuscarListas()
    {
        var listasDeTarefasDto = await _listaTarefaService.BuscarTodasListasDeTarefaAsync();

        return Ok(listasDeTarefasDto);
    }

    [HttpGet("{responsavel}")]
    [ProducesResponseType(typeof(ListaTarefaResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Busca a lista de tarefa especificada.")]
    public async Task<IActionResult> BuscarListaPorResponsavel([FromRoute] string responsavel)
    {
        var listaDeTarefasDto = await _listaTarefaService.BuscarListaDeTarefaPorResponsavelAsync(responsavel);

        return Ok(listaDeTarefasDto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Adiciona uma nova lista de tarefa.")]
    public async Task<IActionResult> CriarNovaListaDetarefas([FromBody] ListaTarefaRequestDto tarefasRequestDto)
    {
        await _listaTarefaService.AdicionarListaDeTarefasAsync(tarefasRequestDto);

        return StatusCode(201);
    }

    [HttpPut("{responsavel}")]
    [ProducesResponseType(typeof(ICollection<TarefaRequestDto>), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Atualiza a lista de tarefas especificada.")]
    public async Task<IActionResult> CriarNovaListaDetarefas([FromRoute] string responsavel, [FromBody] ICollection<TarefaRequestDto> tarefasRequestDto)
    {
        await _listaTarefaService.AtualizarListaDeTarefasAsync(responsavel, tarefasRequestDto);

        return StatusCode(204);
    }

    [HttpDelete("{responsavel}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Remove a lista de tarefas especificada.")]
    public async Task<IActionResult> CriarNovaListaDetarefas([FromRoute] string responsavel)
    {
        await _listaTarefaService.RemoverListaDeTarefasAsync(responsavel);

        return StatusCode(204);
    }
}