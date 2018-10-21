using System;
using System.Collections.Generic;
using MessagingAPI.Models;
using MessagingAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessagingAPI.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private IUserRepository _userRepository { get; set; }
        private IErrorLogRepository _errorLogRepository { get; set; }


        public UserController(IUserRepository userRepository, IErrorLogRepository errorLogRepository)
        {
            _userRepository = userRepository;
            _errorLogRepository = errorLogRepository;
        }

        [HttpPost, Authorize, Route("create")]
        public IActionResult Create([FromBody] UserModel userModel)
        {
            try
            {
                if (userModel == null || userModel.UserName == null || userModel.Password == null)
                    return BadRequest("Username and Password can not be null!");

                _userRepository.Insert(new User() { UserName = userModel.UserName, Password = userModel.Password });
                return Ok(true);
            }
            catch (Exception ex)
            {
                _errorLogRepository.Insert(new ErrorLog() { Text = ex.ToString() });
                return BadRequest("Error Occured!");
            }
        }

    }
}
