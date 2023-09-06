using Gav.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gav.Controllers.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is GavException)
            context.Result = new ObjectResult("Não foi possível realizar a operação pelo seguinte motivo: " + context.Exception.Message)
            {
                StatusCode = 400 
            };
        else if (context.Exception is Exception)
            context.Result = new ObjectResult("Ocorreu o seguinte erro durante a operação: " + context.Exception.Message)
            {
                StatusCode = 500 
            };
        
        context.ExceptionHandled = true;
    }
}