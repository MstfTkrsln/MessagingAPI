using System;
using System.Collections.Generic;
using MessagingAPI.Models;
using MessagingAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessagingAPI.Controllers
{
    [Route("api/blacklist")]
    public class BlackListController : Controller
    {
        private IBlackListRepository _blackListRepository { get; set; }
        private IUserRepository _userRepository { get; set; }
        private IErrorLogRepository _errorLogRepository { get; set; }


        public BlackListController(IBlackListRepository blackListRepository, IUserRepository userRepository, IErrorLogRepository errorLogRepository)
        {
            _blackListRepository = blackListRepository;
            _userRepository = userRepository;
            _errorLogRepository = errorLogRepository;
        }

        [HttpPost, Authorize, Route("block")]
        public IActionResult Block(string blockedUserName)
        {
            try
            {
                User user = _userRepository.GetUserByName(blockedUserName);
                if (user == null)
                    return BadRequest("User could not found!");

                BlackList message = new BlackList();
                message.BlockedUserId = user.UserId;
                message.UserId = Convert.ToInt32(this.User.FindFirst("UserId").Value);

                _blackListRepository.Insert(message);
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
