using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PokemonsAPI.Controllers;

[Route("api/[controller]")]
[EnableCors("AllowOrigin")]
[ApiController]
public class ApiControllerBase : ControllerBase
{
}
