﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreVSWeb.Controllers
{
    public class ScottController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
