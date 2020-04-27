﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    public class StatusController : Controller
    {
        // GET /status -> 200 ok
        [HttpGet("/status")]
        public ActionResult GetTheStatus()
        {
            var response = new GetStatusResponse
            {
                Message = "Everything is golden!",
                CheckedBy = "The H I V E",
                WhenLastChecked = DateTime.Now
            };
            return Ok(response);
        }
    }

    public class GetStatusResponse
    {
        public string Message { get; set; }
        public string CheckedBy { get; set; }
        public DateTime WhenLastChecked { get; set; }
    }
}