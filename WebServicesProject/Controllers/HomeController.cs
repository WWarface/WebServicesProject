using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebServicesProject.Services;

namespace WebServicesProject.Controllers
{
    public class HomeController : Controller
    {
        private IEmailSender emailSender;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        public HomeController(IEmailSender emailSender, ILogger<HomeController> logger, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _logger = logger;
            this.emailSender = emailSender;
        }
        public IActionResult Index()
        {
            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -   {HttpContext.Request.Path}; remoteIP -  {_contextAccessor.HttpContext.Connection.RemoteIpAddress}");

            return View();
        }

        public IActionResult About()
        {
            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -   {HttpContext.Request.Path}; remoteIP -  {_contextAccessor.HttpContext.Connection.RemoteIpAddress}");

            return View();
        }

        public IActionResult Brand()
        {
            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -   {HttpContext.Request.Path}; remoteIP -  {_contextAccessor.HttpContext.Connection.RemoteIpAddress}");

            return View();
        }

        public IActionResult Specials()
        {
            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -   {HttpContext.Request.Path}; remoteIP -  {_contextAccessor.HttpContext.Connection.RemoteIpAddress}");

            return View();
        }

        public IActionResult Contact()
        {
            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -   {HttpContext.Request.Path}; remoteIP -  {_contextAccessor.HttpContext.Connection.RemoteIpAddress}");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string YourName,string Email,string Phone,string Message)
        {
            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -   {HttpContext.Request.Path}; remoteIP -  {_contextAccessor.HttpContext.Connection.RemoteIpAddress}");

            StringBuilder builder=new StringBuilder();
            builder.Append($"Hi, its {YourName}!\n my phone is {Phone}/n {Message}");
            await emailSender.SendEmailAsync("matyiokin2002@gmail.com", "LAB2", "SDsddsdsds");
            return RedirectToAction("Index");
        }
    }
}
