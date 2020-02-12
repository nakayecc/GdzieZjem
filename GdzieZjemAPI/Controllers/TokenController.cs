using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private readonly ApiContext _context;

        public TokenController(ITokenService tokenService, ApiContext apiContext)
        {
            _tokenService = tokenService;
            _context = apiContext;
        }

        // Post
        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var currentUser =
                _context.Users.SingleOrDefault(x => x.NickName == model.Username && x.Password == model.Password);
            if (currentUser == null)
                return BadRequest(new {message = "Username or password is incorrect"});
            return Ok(_tokenService.GenerateToken(model.Username, model.Password));
        }
    }
}