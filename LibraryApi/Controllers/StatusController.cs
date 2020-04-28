using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    public class StatusController : Controller
    {

        ISystemTime systemTime;

        public StatusController(ISystemTime systemTime)
        {
            this.systemTime = systemTime;
        }

        // GET /status -> 200 ok
        [HttpGet("/status")]
        public ActionResult GetTheStatus()
        {
            var response = new GetStatusResponse
            {
                Message = "Everything is golden!",
                CheckedBy = "The H I V E",
                WhenLastChecked = systemTime.GetCurrent() //see startup
            };
            return Ok(response);
            //one last thing
        }
        //Get /employees/93/salary
        //use route constraints to ensure you can enter "bob" as employee id
        //route constraint says id must be a positive, whole integer.
        [HttpGet("employees/{employeeId:int:min(1)}/salary")]
        public ActionResult GetEmployeeSalary(int employeeId)
        {
            return Ok($"Employee {employeeId} has a salary of $72,000.00");
        }

        //GET /employees?dept=DEV
        [HttpGet("employees")]
        public ActionResult GetEmployees([FromQuery] string dept= "All")
        {
            return Ok($"Returning employees for department {dept}");
        }
    }

    public class GetStatusResponse
    {
        public string Message { get; set; }
        public string CheckedBy { get; set; }
        public DateTime WhenLastChecked { get; set; }
    }
}