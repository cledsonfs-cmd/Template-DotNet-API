using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Template_DotNet_API.Data;
using Template_DotNet_API.Enums;
using Template_DotNet_API.Models.DTOs;
using Template_DotNet_API.Services;

namespace Template_DotNet_API.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, TokenService tokenService, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _context = context;
            _tokenService = tokenService;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                new ApplicationUser { UserName = request.Username, Email = request.Email, Role = Role.User },
                request.Password!
            );

            if (result.Succeeded)
            {
                request.Password = "";
                CreatedAtAction(nameof(Register), new { email = request.Email, role = request.Role }, request);
                var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);
                var accessToken = _tokenService.CreateToken(userInDb);
                return Ok(new AuthResponse
                {
                  uuid = userInDb.Id,
                  email = userInDb.Email,
                  nome = userInDb.UserName,
                  token = accessToken,
                  provedor = "",
                  imageUrl = "",
                  role = userInDb.Role
                });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email!);
            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password!);
            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (userInDb is null)
            {
                return Unauthorized();
            }

            var accessToken = _tokenService.CreateToken(userInDb);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                uuid = userInDb.Id,
                email = userInDb.Email,
                nome = userInDb.UserName,
                token = accessToken,
                provedor = "",
                imageUrl = "",
                role = userInDb.Role
            });
        }

        [HttpPost("logout")]        
        public async Task<ActionResult<AuthResponse>> Logout()
        {
          Response.Headers.Remove("Authorization");
          
          return Ok(new MessageDTO { 
            message = "Logout efetuado com sucesso!",
          });
        }

        [HttpPost("refresh")]        
        public async Task<ActionResult<AuthResponse>> Refresh([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email!);
            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password!);
            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (userInDb is null)
            {
                return Unauthorized();
            }

            var accessToken = _tokenService.CreateToken(userInDb);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                uuid = userInDb.Id,
                email = userInDb.Email,
                nome = userInDb.UserName,
                token = accessToken,
                provedor = "",
                imageUrl = "",
                role = userInDb.Role
            });
        }

        [HttpGet("users")]
        public async Task<ActionResult<AuthResponse>> Users()
        {
          var usuarios = _context.Users;
          List<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();
          foreach(var user in usuarios){
            var userDTO = new UsuarioDTO()
            {
              uuid = user.Id,
              email = user.Email,
              nome = user.UserName,
              provedor = "",
              imageUrl = "",
              role = user.Role
            };
            usuarioDTOs.Add(userDTO);
          }
          return Ok(usuarioDTOs);
        }
    }
}
