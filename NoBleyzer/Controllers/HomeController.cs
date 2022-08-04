using Microsoft.AspNetCore.Mvc;

namespace NoBleyzer.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController: ControllerBase
    {
        [HttpGet]
        public string Welcome()
        {
            return "Hello world!";
        }

        [HttpGet]
        public User GetUser()
        {
            User user = new User();
            user.Name = "Oleg";
            return user;
        }
    }
}
