using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WC.Library.Web.Controllers;
using WC.Service.MessageDispatcher.API.Models.Chat;
using Swashbuckle.AspNetCore.Annotations;
using WC.Service.MessageDispatcher.Domain.Models;
using WC.Service.MessageDispatcher.Domain.Services.Chat;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.MessageDispatcher.API.Controllers;

/// <summary>
///     The chat type management controller.
/// </summary>
[Route("api/[controller]")]
public class ChatController : CrudApiControllerBase<ChatController, IChatManager,
    IChatProvider, ChatModel, ChatDto>
{
    public ChatController(IMapper mapper, ILogger<ChatController> logger, IEnumerable<IValidator> validators,
        IChatManager manager, IChatProvider provider) : base(mapper, logger, validators, manager, provider)
    {
    }

    [HttpGet]
    [SwaggerOperation(OperationId = nameof(ChatGet))]
    [SwaggerResponse(Status200OK, Type = typeof(List<ChatDto>))]
    public async Task<ActionResult<List<ChatDto>>> ChatGet(
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(cancellationToken));
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(ChatGetById))]
    [SwaggerResponse(Status200OK)]
    public async Task<ActionResult<List<ChatDto>>> ChatGetById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetOneById(id, cancellationToken));
    }

    [HttpPost]
    [SwaggerOperation(OperationId = nameof(ChatCreate))]
    [SwaggerResponse(Status200OK)]
    public async Task<IActionResult> ChatCreate(ChatDto chat,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Create(chat, cancellationToken));
    }

    [HttpPatch("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(ChatUpdate))]
    [SwaggerResponse(Status200OK)]
    public async Task<IActionResult> ChatUpdate(Guid id, [FromBody] JsonPatchDocument<ChatDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Update(id, patchDocument, cancellationToken));
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(ChatDelete))]
    [SwaggerResponse(Status200OK)]
    public async Task<IActionResult> ChatDelete(Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Delete(id, cancellationToken));
    }
}