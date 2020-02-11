using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GdzieZjemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        // Post
        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _tokenService.GenerateToken(model.Username,model.Password);
            if(user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }
        
        
    
    }
}