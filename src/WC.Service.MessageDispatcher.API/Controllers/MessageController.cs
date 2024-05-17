using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WC.Library.Web.Controllers;
using WC.Library.Web.Models;
using WC.Service.MessageDispatcher.API.Models.Message;
using WC.Service.MessageDispatcher.Domain.Models;
using WC.Service.MessageDispatcher.Domain.Services.Message;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.MessageDispatcher.API.Controllers;

/// <summary>
///     The message type management controller.
/// </summary>
[Route("api/[controller]")]
public class MessageController : CrudApiControllerBase<ChatController, IMessageManager,
    IMessageProvider, MessageModel, MessageDto>
{
    public MessageController(IMapper mapper, ILogger<ChatController> logger, IEnumerable<IValidator> validators, IMessageManager manager, IMessageProvider provider) : base(mapper, logger, validators, manager, provider)
    {
    }
    
    /// <summary>
    /// Retrieves a list of messages.
    /// </summary>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet]
    [SwaggerOperation(OperationId = nameof(MessageGet))]
    [SwaggerResponse(Status200OK, Type = typeof(List<MessageDto>))]
    public async Task<ActionResult<List<MessageDto>>> MessageGet(
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(cancellationToken));
    }
    
    /// <summary>
    /// Retrieves a message by its ID.
    /// </summary>
    /// <param name="id">The ID of the message to retrieve.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(MessageGetById))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<ActionResult<List<MessageDto>>> MessageGetById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetOneById(id, cancellationToken));
    }
    
    /// <summary>
    /// Creates a new chat.
    /// </summary>
    /// <param name="message">The message data.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPost]
    [SwaggerOperation(OperationId = nameof(MessageCreate))]
    [SwaggerResponse(Status200OK)]
    public async Task<IActionResult> MessageCreate(MessageDto message,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Create(message, cancellationToken));
    }
    
    /// <summary>
    /// Updates a message by ID.
    /// </summary>
    /// <param name="id">The ID of the message to update.</param>
    /// <param name="patchDocument">The JSON patch document containing updates.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPatch("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(MessageUpdate))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> MessageUpdate(Guid id, [FromBody] JsonPatchDocument<MessageDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Update(id, patchDocument, cancellationToken));
    }
    
    /// <summary>
    /// Deletes a message by ID.
    /// </summary>
    /// <param name="id">The ID of the message to delete.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpDelete("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(MessageDelete))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status204NoContent, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status400BadRequest, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status409Conflict, Type = typeof(ErrorDto))]
    public async Task<IActionResult> MessageDelete(Guid id,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Delete(id, cancellationToken));
    }
}