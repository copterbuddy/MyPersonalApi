using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonalApi.Service.Controllers
{
    //[Route("api/[controller]")]
    public class TempController : Controller
    {
        [HttpGet("TestGithubAction")]
        public IActionResult TestGithubAction()
        {
            return Ok("TestGithubAction Successful");

        }
    }
}
