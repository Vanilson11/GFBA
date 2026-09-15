using GFBA.Application.UseCases.AcaoBA.Registrar;
using GFBA.Communication.Requests;
using GFBA.Communication.Responses;
using GFBA.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFBA.Api.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize(Roles = Roles.ORIENTADOR)]
public class AcaoBaController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegistrarAcaoBaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessages), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessages), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Registrar(
        [FromServices] IRegistrarAcaoBaUseCase useCase,
        [FromBody] RequestRegistrarAcaoBaJson request,
        [FromRoute] Guid idFichaBa)
    {
        var response = await useCase.Executar(request);

        return Ok(response);
    }
}
