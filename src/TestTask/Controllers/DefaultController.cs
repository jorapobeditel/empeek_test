using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Controllers
{
    [Route("")]
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("index.htm");
        }
    }
}
