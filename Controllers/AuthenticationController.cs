using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using My_Fight_APP.Models;
using My_Fight_APP.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace My_Fight_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }
        [HttpPost("registerAdmin")]
        public async Task<IActionResult> RegisterAdmin ([FromBody] RegisterModel model)
        {
            var userExist = await _userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel
                {
                    IsSuccessful = false,
                    Error="User already exists"
                });

            }
            var user = new User()
            {
                Email = model.Email,
                UserName = model.UserName,
                Password = model.Password,
                SecurityStamp= Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { IsSuccessful=false, Error =$"{result.Errors.ToString()}" });
            


            //if(!await _roleManager.RoleExistsAsync(UserRoles.Admin));
            //await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            return Ok(new ResponseModel { Error="New Admin Created", IsSuccessful=true });
        }

        //[Authorize]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRole = await _userManager.GetRolesAsync(user);
                var authClaim = new List<Claim> 
                
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach(var UserRole in userRole)
                {
                    authClaim.Add(new Claim(ClaimTypes.Role, UserRole));
                }
                var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(5),
                    claims: authClaim,
                    signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256));

                return Ok(new {
                token= new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
                });

                
            }
            return Unauthorized();
        }
       
    }
}
