using GFBA.Application.UseCases.Usuarios.Registrar;
using GFBA.Communication.Requests;
using GFBA.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GFBA.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegistrarUsuarioJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessages), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Registrar([FromServices] IRegistrarUsuarioUseCase registrarUsuarioUseCase,[FromBody] RequestRegistrarUsuarioJson request)
    {
        var response = await registrarUsuarioUseCase.Executar(request);

        return Created(string.Empty, response);
    }
}
