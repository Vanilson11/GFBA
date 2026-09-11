using GFBA.Application.UseCases.DoLogin;
using GFBA.Communication.Requests;
using GFBA.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GFBA.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseDoLoginJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessages), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login(
        [FromServices] IDoLoginUseCase useCase,
        [FromBody] RequestDoLoginJson request)
    {
        var response = await useCase.Executar(request);
        
        return Ok(response);
    }
}
