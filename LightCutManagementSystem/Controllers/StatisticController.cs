﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LightCutManagement.Controllers
{
    public class StatisticController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}