using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularDemo.Controllers
{
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        [HttpGet]
        [Route("Index")]
        public IEnumerable<EmployeeMaster> Index()
        {
            return objemployee.GetAllEmployees();
        }

        [HttpPost]
        [Route("Create")]
        public int Create([FromBody] EmployeeMaster employee)
        {
            return objemployee.AddEmployee(employee);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public EmployeeMaster Details(int id)
        {
            return objemployee.GetEmployeeData(id);
        }

        [HttpPut]
        [Route("Edit")]
        public int Edit([FromBody]EmployeeMaster employee)
        {
            return objemployee.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(int id)
        {
            return objemployee.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("GetDepartmentList")]
        public IEnumerable<DepartmentMaster> Details()
        {
            return objemployee.Getdepartments();
        }
    }
}
