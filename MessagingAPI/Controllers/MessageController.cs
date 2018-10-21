using System;
using System.Collections.Generic;
using MessagingAPI.Models;
using MessagingAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessagingAPI.Controllers
{
    [Route("api/message")]
    public class MessageController : Controller
    {
        private IMessageRepository _messageRepository { get; set; }
        private IUserRepository _userRepository { get; set; }
        private IErrorLogRepository _errorLogRepository { get; set; }
        private IBlackListRepository _blackListRepository { get; set; }


        public MessageController(IMessageRepository messageRepository, IUserRepository userRepository, IErrorLogRepository errorLogRepository, IBlackListRepository blackListRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _errorLogRepository = errorLogRepository;
            _blackListRepository = blackListRepository;
        }

        [HttpPost, Authorize, Route("send")]
        public IActionResult Send([FromBody] MessageModel messageModel)
        {
            try
            {
                User user = _userRepository.GetUserByName(messageModel.ToUserName);
                if (user == null)
                    return BadRequest("User could not found!");

                int currentUserId = Convert.ToInt32(this.User.FindFirst("UserId").Value);

                List<BlackList> blackList = _blackListRepository.GetBlackListByUserId(user.UserId);
                bool isBlocked=blackList.Exists(b => b.BlockedUserId == currentUserId);
                if(isBlocked)
                    return BadRequest(string.Format("{0} blocked you!",messageModel.ToUserName));


                Message message = new Message();
                message.Content = messageModel.Content;
                message.ToUserId = user.UserId;
                message.FromUserId = currentUserId;

                _messageRepository.Insert(message);
                return Ok(true);
            }
            catch (Exception ex)
            {
                _errorLogRepository.Insert(new ErrorLog() { Text = ex.ToString() });
                return BadRequest("Error Occured!");
            }
        }

        [HttpGet, Authorize, Route("history")]
        public IActionResult GetMyHistory()
        {
            try
            {
                var messages = _messageRepository.GetMessagesByUserId(Convert.ToInt32(this.User.FindFirst("UserId").Value));

                return Ok(messages);
            }
            catch (Exception ex)
            {
                _errorLogRepository.Insert(new ErrorLog() { Text = ex.ToString() });
                return BadRequest("Error Occured!");
            }
        }

    }
}
