using test1.Models;
using Microsoft.AspNetCore.Mvc;
using test1.Models.Domain;
using test1.Data;

namespace test1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCdbSContext mvcDbSContext;
        public EmployeesController(MVCdbSContext mvcDbSContext)
        {
            this.mvcDbSContext = mvcDbSContext;
        }

        public MVCdbSContext MvcDbSContext { get; }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        public async Task<IActionResult>  Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),


                Name = addEmployeeRequest.Name,

                UserName = addEmployeeRequest.UserName,


                Password = addEmployeeRequest.Password,

                ConfPassword = addEmployeeRequest.ConfPassword,

                Position = addEmployeeRequest.Position,

                Team = addEmployeeRequest.Team,

                Security = addEmployeeRequest.Security,

                Email = addEmployeeRequest.Email,

                CreatedDate = addEmployeeRequest.CreatedDate,

                Status = addEmployeeRequest.Status

            };
            await mvcDbSContext.Employees.AddAsync(employee);
            await mvcDbSContext.SaveChangesAsync();
            return RedirectToAction("Add");
}

    }
}
