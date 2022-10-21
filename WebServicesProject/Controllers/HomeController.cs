using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
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
            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -  {HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}; remoteIP -  {_contextAccessor?.HttpContext?.Connection.RemoteIpAddress}");

            return View();
        }

        public IActionResult About()
        {

            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -  {HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}; remoteIP -  {_contextAccessor?.HttpContext?.Connection.RemoteIpAddress}");

            return View();
        }

        public IActionResult Brand()
        {
            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -  {HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}; remoteIP -  {_contextAccessor?.HttpContext?.Connection.RemoteIpAddress}");

            return View();
        }

        public IActionResult Specials()
        {
            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -  {HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}; remoteIP -  {_contextAccessor?.HttpContext?.Connection.RemoteIpAddress}");

            return View();
        }

        public IActionResult Contact()
        {
            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -  {HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}; remoteIP -  {_contextAccessor?.HttpContext?.Connection.RemoteIpAddress}");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string YourName,string Email,string Phone,string Message)
        {
            _logger.LogInformation($"time - {DateTime.Now.ToShortTimeString()};path -  {HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}; remoteIP -  {_contextAccessor?.HttpContext?.Connection.RemoteIpAddress}");

            StringBuilder builder =new StringBuilder();
            builder.Append($"Hi, its {YourName}!\n my phone is {Phone}/n {Message}");
            await emailSender.SendEmailAsync("matyiokin2002@gmail.com", "LAB2", "SDsddsdsds");
            return RedirectToAction("Index");
        }
        public IActionResult FileLoad()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileLoad(List<IFormFile> files)
        {
            var size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Files", formFile.FileName);
                    filePaths.Add(filePath);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return View();
        }
    }
}
