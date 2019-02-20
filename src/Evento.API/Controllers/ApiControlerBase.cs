using System;
using Microsoft.AspNetCore.Mvc;

namespace Evento.API.Controllers
{
    [Route("[controller]")]
    public class ApiControlerBase : Controller
    {
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ? 
        Guid.Parse(User.Identity.Name) :
        Guid.Empty;
    }
}