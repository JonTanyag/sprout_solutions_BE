using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sprout.data.Entity;
using sprout.data.Models;
using sprout.service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sprout_solutions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<controller>
        [HttpGet]
        public EmployeeModel Get()
        {
            var employees = _employeeService.GetAll();

            return employees;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Employee Get(string id)
        {
            var employee = _employeeService.GetById(id);

            return employee;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            _employeeService.CreateEmployee(employee);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Calculate(string id, double days)
        {
            _employeeService.Calculate(id, days);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
