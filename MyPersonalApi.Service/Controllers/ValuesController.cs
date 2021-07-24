using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalApi.Service.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        //[Route("api/[controller]")]
        public class PersonalController : Controller
        {
            //private readonly IPersonalService personalService;

            //public PersonalController(IPersonalService personalService)
            //{
            //    this.personalService = personalService;
            //}

            [HttpGet("TestGithubAction")]
            public IActionResult TestGithubAction()
            {
                return Ok("TestGithubAction Successful");

            }

        }
    }
}
