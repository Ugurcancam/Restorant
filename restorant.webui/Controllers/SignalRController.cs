using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace restorant.webui.Controllers
{
    [Route("[controller]")]
    public class SignalRController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }


    }
}