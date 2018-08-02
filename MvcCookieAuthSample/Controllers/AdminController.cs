﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MvcCookieAuthSample.Controllers
{
    public class AdminController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}