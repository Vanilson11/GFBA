using GFBA.Communication.Responses;
using GFBA.Exception;
using GFBA.Exception.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GFBA.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is GFBAException)
        {
            HandleExceptionProject(context);
        }
        else
        {
            UnknowError(context);
        }
    }

    private void HandleExceptionProject(ExceptionContext context)
    {
        var exception = (GFBAException)context.Exception;
        var responseErrorMessages = new ResponseErrorMessages(exception.GetErrors());

        context.HttpContext.Response.StatusCode = exception.StatusCode;
        context.Result = new ObjectResult(responseErrorMessages);
    }

    private void UnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(ResourceErrorMessages.ERRO_DESCONHECIDO);
    }
}
