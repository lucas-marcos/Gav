using Gav.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Gav.Controllers.Filters;


public class CustomAuthorizationFilterAttribute : TypeFilterAttribute
{
     public CustomAuthorizationFilterAttribute(params TipoRoles[] role) : base(typeof(CustomAuthorizationFilter))
    {
        Arguments = new object[] { role };
    }   
}