using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WC.Library.Web.Controllers;
using WC.Library.Web.Models;
using WC.Service.MessageDispatcher.API.Models.Chat;
using WC.Service.MessageDispatcher.Domain.Models;
using WC.Service.MessageDispatcher.Domain.Services.Chat;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.MessageDispatcher.API.Controllers;

/// <summary>
///     The chat management controller.
/// </summary>
[Route("api/[controller]")]
public class ChatController : CrudApiControllerBase<ChatController, IChatManager, IChatProvider, ChatModel, ChatDto>
{
    /// <inheritdoc />
    public ChatController(IMapper mapper, ILogger<ChatController> logger, IEnumerable<IValidator> validators,
        IChatManager manager, IChatProvider provider) : base(mapper, logger, validators, manager, provider)
    {
    }

    /// <summary>
    /// Retrieves a list of chats.
    /// </summary>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet]
    [SwaggerOperation(OperationId = nameof(ChatGet))]
    [SwaggerResponse(Status200OK, Type = typeof(List<ChatDto>))]
    public async Task<ActionResult<List<ChatDto>>> ChatGet(CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(cancellationToken));
    }

    /// <summary>
    /// Retrieves a chat by its ID.
    /// </summary>
    /// <param name="id">The ID of the chat to retrieve.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(ChatGetById))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<ActionResult<ChatDto>> ChatGetById(Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await GetOneById(id, cancellationToken));
    }

    /// <summary>
    /// Creates a new chat.
    /// </summary>
    /// <param name="chat">The chat data.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPost]
    [SwaggerOperation(OperationId = nameof(ChatCreate))]
    [SwaggerResponse(Status200OK)]
    public async Task<IActionResult> ChatCreate(ChatDto chat, CancellationToken cancellationToken = default)
    {
        return Ok(await Create(chat, cancellationToken));
    }

    /// <summary>
    /// Updates a chat by ID.
    /// </summary>
    /// <param name="id">The ID of the chat to update.</param>
    /// <param name="patchDocument">The JSON patch document containing updates.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPatch("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(ChatUpdate))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    public async Task<IActionResult> ChatUpdate(Guid id, [FromBody] JsonPatchDocument<ChatDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        return Ok(await Update(id, patchDocument, cancellationToken));
    }

    /// <summary>
    /// Deletes a chat by ID.
    /// </summary>
    /// <param name="id">The ID of the chat to delete.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpDelete("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(ChatDelete))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status204NoContent, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status400BadRequest, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status409Conflict, Type = typeof(ErrorDto))]
    public async Task<IActionResult> ChatDelete(Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await Delete(id, cancellationToken));
    }
}