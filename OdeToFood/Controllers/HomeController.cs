﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController 
    {
        public string Index()
        {
            return "Hello, from the HomeController";
        }
    }
}
