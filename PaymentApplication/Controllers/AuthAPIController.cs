using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PaymentApplication.Models;
using PaymentApplication.Models.ViewModels;
using PaymentApplication.Repository;

namespace PaymentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IUserProfileRepository userProfileRepository;
        private readonly IConfiguration _configuration;
        public AuthAPIController(IUserProfileRepository userProfileRepository, IConfiguration _configuration)
        {
            this.userProfileRepository = userProfileRepository;
            this._configuration = _configuration;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {
                loginViewModel = userProfileRepository.Authenticate(loginViewModel);
                if (loginViewModel.IsValid)
                {
                    SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Helper.SymmetricSecurityKey(_configuration)));
                    SigningCredentials signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                   
                    List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginViewModel.UserProfile.FirstName+loginViewModel.UserProfile.LastName),
                    new Claim("UId",loginViewModel.UserProfile.PKUserId.ToString()),
                    new Claim(ClaimTypes.Email,loginViewModel.UserProfile.EmailId),
                    new Claim(ClaimTypes.Role,loginViewModel.RoleName),
                    new Claim("RegisteredDate", loginViewModel.UserProfile.RegisteredDate.ToString()),
                };
                    DateTime tokenExpires_in = DateTime.UtcNow.AddDays(10);
                    JwtSecurityToken tokenOptions = new JwtSecurityToken(
                        claims: claims,
                        expires: tokenExpires_in,
                        signingCredentials: signinCredentials
                    );
                    string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = tokenString, Expires_in = tokenExpires_in });
                }
                else
                    return BadRequest();
            }
            return BadRequest();
        }
    }
}
