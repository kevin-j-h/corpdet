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
        public EmployeesController(applicationdbcontext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeesViewModel viewModel)
        {

            var emp = new employees
            {
                First_Name = viewModel.First_Name,
                Last_Name = viewModel.Last_Name,
                date_of_birth = viewModel.date_of_birth,
                date_of_hire = viewModel.date_of_hire,
                deptid = viewModel.deptid,
                position = viewModel.position

            };
            await dbContext.emps.AddAsync(emp);
            await dbContext.SaveChangesAsync();

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var Employees = await dbContext.emps.ToListAsync();
            return View(Employees);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var emp = await dbContext.emps.FindAsync(id);

            return View(emp);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(employees viewModel)
        {
            var emp = await dbContext.emps.FindAsync(viewModel.Id);

            if (emp is not null)
            {
                emp.First_Name = viewModel.First_Name;
                emp.Last_Name = viewModel.Last_Name;
                emp.date_of_birth = viewModel.date_of_birth;
                emp.date_of_hire = viewModel.date_of_hire;
                emp.deptid = viewModel.deptid;
                emp.position = viewModel.position;
            }
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Employees");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(employees viewModel)
        {
            var emps = await dbContext.emps
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (emps is not null)
            {
                dbContext.emps.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employees");
        }
    }
}
