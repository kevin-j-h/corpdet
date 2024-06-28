using Employees.data;
using Employees.Models;
using Employees.Models.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employees.Controllers
{
    public class EmployeesController : Controller

    {
        private readonly applicationdbcontext dbContext;
        public EmployeesController(applicationdbcontext dbContext )
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult>  Add(AddEmployeesViewModel viewModel)
        {

            var emp = new employees
            {
                First_Name = viewModel.First_Name
            };
            await dbContext.emps.AddAsync(emp);
            await dbContext.SaveChangesAsync();



            return View();
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
           var Employees= await dbContext.emps.ToListAsync();
           return View(Employees);
        }

    }
}
