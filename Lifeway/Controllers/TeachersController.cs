using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lifeway.Controllers
{
    public class TeachersController : Controller
    {
        public IActionResult AllTeachers()
        {
            return View();
        }
    }
}
