using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lifeway.Controllers
{
    public class ExamsController : Controller
    {
        public IActionResult ExamResults()
        {
            return View();
        }
    }
}
