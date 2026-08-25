using GFBA.Application.UseCases.FichasBA.Registrar;
using GFBA.Communication.Requests;
using GFBA.Communication.Responses;
using GFBA.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFBA.Api.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize(Roles = Roles.ORIENTADOR)]
public class FichasController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegistrarFichaBAJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessages), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Registrar(
        [FromServices] IRegistrarFichaBAUseCase useCase, 
        [FromBody] RequestFichaBAJson request)
    {
        var response = await useCase.Executar(request);

        return Created(string.Empty, response);
    }
}
