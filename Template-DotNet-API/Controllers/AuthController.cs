using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

using Template_DotNet_API.Model.DTO;

namespace Template_DotNet_API.Controllers
{
  [ApiController]
  [Route("api")]
  public class AuthController : ControllerBase{

    [HttpPost("register")]
    public UserDTO Register(RegisterDTO reques)
    {
      UserDTO user = new UserDTO();      
      return user;
    }

    [HttpPost("login")]
    public string Login()
    {
      return "xxxx";
    }

    [HttpPost("logout")]
    public string Logout()
    {
      return "xxxx";
    }

    [HttpPost("refresh")]
    public string Refresh()
    {
      return "xxxx";
    }

    [HttpGet("users")]
    public string Users()
    {
      return "xxxx";
    }

  }
}