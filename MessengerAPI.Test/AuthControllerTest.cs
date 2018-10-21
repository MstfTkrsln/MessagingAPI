using MessagingAPI.Controllers;
using MessagingAPI.Models;
using MessagingAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MessengerAPI.Test
{
    public class AuthControllerTest
    {
        [Fact]
        public void Login()
        {
            MessengerDbContext context = new MessengerDbContext();
            UserRepository userRepo = new UserRepository(context);
            ErrorLogRepository errorRepo = new ErrorLogRepository(context);

            AuthController controller = new AuthController(userRepo, errorRepo);

            var res=controller.Login(new LoginModel() { UserName = "MustafaTekeraslan", Password = "1903" });

            Assert.IsType<OkObjectResult>(res);

        }
    }
}
