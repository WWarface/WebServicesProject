using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebServicesProject.Services;

namespace WebServicesProject.Controllers
{
    public class HomeController : Controller
    {
        private IEmailSender emailSender;

        public HomeController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Brand()
        {
            return View();
        }

        public IActionResult Specials()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string YourName,string Email,string Phone,string Message)
        {
            StringBuilder builder=new StringBuilder();
            builder.Append($"Hi, its {YourName}!\n my phone is {Phone}/n {Message}");
            await emailSender.SendEmailAsync("matyiokin2002@gmail.com", "LAB2", "SDsddsdsds");
            return RedirectToAction("Index");
        }
    }
}
