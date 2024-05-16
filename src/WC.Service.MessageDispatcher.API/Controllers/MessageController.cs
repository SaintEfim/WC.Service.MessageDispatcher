using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WC.Library.Web.Controllers;
using WC.Service.MessageDispatcher.API.Models.Message;
using WC.Service.MessageDispatcher.Domain.Models;
using WC.Service.MessageDispatcher.Domain.Services.Message;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.MessageDispatcher.API.Controllers;

/// <summary>
///     The chat type management controller.
/// </summary>
[Route("api/[controller]")]
public class MessageController : CrudApiControllerBase<ChatController, IMessageManager,
    IMessageProvider, MessageModel, MessageDto>
{
    public MessageController(IMapper mapper, ILogger<ChatController> logger, IEnumerable<IValidator> validators, IMessageManager manager, IMessageProvider provider) : base(mapper, logger, validators, manager, provider)
    {
    }

    [HttpGet]
    [SwaggerOperation(OperationId = nameof(MessageGet))]
    [SwaggerResponse(Status200OK, Type = typeof(List<MessageDto>))]
    public async Task<ActionResult<List<MessageDto>>> MessageGet(
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(cancellationToken));
    }

    [HttpGet("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(MessageGetById))]
    [SwaggerResponse(Status200OK)]
    public async Task<ActionResult<List<MessageDto>>> MessageGetById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetOneById(id, cancellationToken));
    }

    [HttpPost]
    [SwaggerOperation(OperationId = nameof(MessageCreate))]
    [SwaggerResponse(Status200OK)]
    public async Task<IActionResult> MessageCreate(MessageDto message,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Create(message, cancellationToken));
    }

    [HttpPatch("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(MessageUpdate))]
    [SwaggerResponse(Status200OK)]
    public async Task<IActionResult> MessageUpdate(Guid id, [FromBody] JsonPatchDocument<MessageDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Update(id, patchDocument, cancellationToken));
    }

    [HttpDelete("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(MessageDelete))]
    [SwaggerResponse(Status200OK)]
    public async Task<IActionResult> MessageDelete(Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Delete(id, cancellationToken));
    }
}