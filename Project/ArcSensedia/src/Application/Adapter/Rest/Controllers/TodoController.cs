using Application.Adapter.Rest.Contract.Request;
using Application.Adapter.Rest.Contract.Response;
using Application.Adapter.Rest.Validators.ErrorDefinition;
using Microsoft.AspNetCore.Mvc;

namespace Application.Adapter.Rest.Controllers;

[Route("/v1/todo")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly ITodoService _service;

    public TodoController(ITodoService todoService)
    {
        _service = todoService;
    }


    /// <summary>
    /// Criação de um TodoItem
    /// </summary>
    /// <param name="todoRequest"></param>
    /// <returns></returns>
    /// <response code="200">Ignorado</response>
    /// <response code="201">Criado</response>
    /// <response code="400">Requisição inválida</response> 
    /// <response code="401">Autenticação inválida</response> 
    /// <response code="404">Não encontrado.</response> 
    /// <response code="500">Erro interno do servidor ou serviço</response> 
    [ProducesResponseType(200, Type = typeof(TodoResponse))]
    [ProducesResponseType(201, Type = typeof(TodoResponse))]
    [ProducesResponseType(400, Type = typeof(ErrorResponse))]
    [ProducesResponseType(401, Type = typeof(ErrorResponse))]
    [ProducesResponseType(404, Type = typeof(ErrorResponse))]
    [ProducesResponseType(422, Type = typeof(ErrorResponse))]
    [ProducesResponseType(500, Type = typeof(ErrorResponse))]
    [HttpPost]
    public ActionResult<TodoResponse> Post([FromBody] TodoRequest todoRequest)
    {
        _service.Create(new Todo());

        return CreatedAtAction(nameof(Post), new TodoResponse());
    }

    /// <summary>
    /// Busca de um TodoItem
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Ok</response>
    /// <response code="400">Requisição inválida</response> 
    /// <response code="401">Autenticação inválida</response> 
    /// <response code="404">Não encontrado</response> 
    /// <response code="500">Erro interno do servidor ou serviço</response> 
    [ProducesResponseType(200, Type = typeof(TodoResponse))]
    [ProducesResponseType(400, Type = typeof(ErrorResponse))]
    [ProducesResponseType(401, Type = typeof(ErrorResponse))]
    [ProducesResponseType(404, Type = typeof(ErrorResponse))]
    [ProducesResponseType(422, Type = typeof(ErrorResponse))]
    [ProducesResponseType(500, Type = typeof(ErrorResponse))]
    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> Get(string id)
    {
        var todo = await _service.GetById(id);

        return Ok(todo);
    }


    /// <summary>
    /// Busca de um TodoItem com query
    /// </summary>
    /// <param name="filters"></param>
    /// <returns></returns>
    /// <response code="200">Ok</response>
    /// <response code="400">Requisição inválida</response> 
    /// <response code="401">Autenticação inválida</response> 
    /// <response code="404">Não encontrado.</response> 
    /// <response code="500">Erro interno do servidor ou serviço</response> 
    [ProducesResponseType(200, Type = typeof(TodoResponse))]
    [ProducesResponseType(400, Type = typeof(ErrorResponse))]
    [ProducesResponseType(401, Type = typeof(ErrorResponse))]
    [ProducesResponseType(404, Type = typeof(ErrorResponse))]
    [ProducesResponseType(422, Type = typeof(ErrorResponse))]
    [ProducesResponseType(500, Type = typeof(ErrorResponse))]
    [HttpGet("query")]
    public async Task<ActionResult<Todo>> GetPages([FromQuery] FilterBase filters)
    {
        var todos = await _service.GetPages(filters.SkipSize, filters.LimitSize);

        return Ok(todos);
    }

    /// <summary>
    /// Atualização de um TodoItem
    /// </summary>
    /// <param name="todo"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Ok</response>
    /// <response code="400">Requisição inválida</response> 
    /// <response code="401">Autenticação inválida</response> 
    /// <response code="404">Não encontrado.</response> 
    /// <response code="500">Erro interno do servidor ou serviço</response> 
    [ProducesResponseType(200, Type = typeof(TodoResponse))]
    [ProducesResponseType(400, Type = typeof(ErrorResponse))]
    [ProducesResponseType(401, Type = typeof(ErrorResponse))]
    [ProducesResponseType(404, Type = typeof(ErrorResponse))]
    [ProducesResponseType(422, Type = typeof(ErrorResponse))]
    [ProducesResponseType(500, Type = typeof(ErrorResponse))]
    [HttpPut("{id}")]
    public async Task<ActionResult<Todo>> Put([FromBody] Todo todo, string id)
    {
        await _service.Update(id, todo);

        return Ok(todo);
    }

    /// <summary>
    /// Delete de um TodoItem
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Ok</response>
    /// <response code="400">Requisição inválida</response> 
    /// <response code="401">Autenticação inválida</response> 
    /// <response code="404">Não encontrado.</response> 
    /// <response code="500">Erro interno do servidor ou serviço</response>
    [ProducesResponseType(200, Type = typeof(TodoResponse))]
    [ProducesResponseType(400, Type = typeof(ErrorResponse))]
    [ProducesResponseType(401, Type = typeof(ErrorResponse))]
    [ProducesResponseType(404, Type = typeof(ErrorResponse))]
    [ProducesResponseType(422, Type = typeof(ErrorResponse))]
    [ProducesResponseType(500, Type = typeof(ErrorResponse))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _service.Delete(id);

        return Ok();
    }
}
