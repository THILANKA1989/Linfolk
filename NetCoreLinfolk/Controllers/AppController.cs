using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreLinfolk.Services;
using NetCoreLinfolk.ViewModels;

namespace NetCoreLinfolk.Controllers
{
    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public class AppController : Controller
    {

        private readonly IMailService _mailService;

        public AppController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactView model)
        {
            if(ModelState.IsValid) {
                _mailService.SendMessage(model.Email, model.Subject, model.Message);
                ViewBag.UserMessage = "Email Sent";
                ModelState.Clear();
            } else {
                ViewBag.UserMessage = "Something went wrong!";
            }
            return View();
        }
    }
}