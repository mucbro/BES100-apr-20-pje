using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LibraryApi.Controllers
{
    public class StatusController : Controller
    {

        ISystemTime systemTime;

        IConfiguration config;

        public StatusController(ISystemTime systemTime, IConfiguration config)
        {
            this.systemTime = systemTime;
            this.config = config;
        }



        // GET /status -> 200 ok
        [HttpGet("/status")]
        public ActionResult GetTheStatus()
        {
            var response = new GetStatusResponse
            {
                Message = "Everything is golden! " + config.GetValue<string>("appName"),
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
        public ActionResult GetEmployees([FromQuery] string dept = "All")
        {
            return Ok($"Returning employees for department {dept}");
        }


        [HttpPost("employees")]
        public ActionResult HireEmployee([FromBody]EmployeeCreateRequest employeeToHire)
        {
            return Ok($"Hiring {employeeToHire.lastName} as a {employeeToHire.department}");
        }

        [HttpGet("whoami")]
        public ActionResult WhoAmI([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Ok($"I see you are running {userAgent}");
        }

    }

    public class GetStatusResponse
    {
        public string Message { get; set; }
        public string CheckedBy { get; set; }
        public DateTime WhenLastChecked { get; set; }
    }


    public class EmployeeCreateRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string department { get; set; }
    }

}