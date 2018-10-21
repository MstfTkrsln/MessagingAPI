using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MessagingAPI.Models;
using MessagingAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MessagingAPI.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private IUserRepository _userRepository { get; set; }
        private IErrorLogRepository _errorLogRepository { get; set; }


        public AuthController(IUserRepository userRepository, IErrorLogRepository errorLogRepository)
        {
            _userRepository = userRepository;
            _errorLogRepository = errorLogRepository;
        }


        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
            try
            {

                if (loginModel == null)
                    return BadRequest("Invalid client request");

                User user = _userRepository.GetUserByName(loginModel.UserName);

                if (user != null && user.Password == loginModel.Password)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("armut.com.secret.key"));

                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>() { new Claim("UserId", user.UserId.ToString()) },
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: signinCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                _errorLogRepository.Insert(new ErrorLog() { Text = ex.ToString() });
                return BadRequest("Error Occured!");
            }
        }
    }
}
