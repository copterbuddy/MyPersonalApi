﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonalApi.Service.Controllers
{
    public class TempController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
