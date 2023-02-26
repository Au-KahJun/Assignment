using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test1.Data;
using test1.Models;
using test1.Models.Domain;

namespace test1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCdbSContext mvcDbSContext;
        public EmployeesController(MVCdbSContext mvcDbSContext)
        {
            this.mvcDbSContext = mvcDbSContext;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await mvcDbSContext.Employees.ToListAsync();
            return View(employees);
        }

        public IActionResult Add()
        {

            return View();
        }


        //public MVCdbSContext MvcDbSContext { get; }

        [HttpPost]

        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {





                Id = Guid.NewGuid(),

                UID = addEmployeeRequest.UID,

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

            var usernameCheking = mvcDbSContext.Employees.Any(x => x.UserName.Equals(employee.UserName));


            if (ModelState.IsValid)
            {

                await mvcDbSContext.Employees.AddAsync(employee);
                await mvcDbSContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Add");
            }
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await mvcDbSContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {
                var viewModel = new UpdateEmployeeVM()
                {

                    Id = employee.Id,

                    UID = employee.UID,


                    Name = employee.Name,

                    UserName = employee.UserName,


                    Password = employee.Password,

                    ConfPassword = employee.ConfPassword,

                    Position = employee.Position,

                    Team = employee.Team,

                    Security = employee.Security,

                    Email = employee.Email,

                    CreatedDate = employee.CreatedDate,

                    Status = employee.Status
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeVM model)
        {
            var employee = await mvcDbSContext.Employees.FindAsync(model.Id);
            if (employee != null)
            {
                employee.Id = model.Id;
                employee.UID = model.UID;
                employee.Name = model.Name;
                employee.Password = model.Password;
                employee.ConfPassword = model.ConfPassword;
                employee.Position = model.Position;
                employee.Team = model.Team;
                employee.Security = model.Security;
                employee.Email = model.Email;
                employee.CreatedDate = model.CreatedDate;
                employee.Status = model.Status;

                await mvcDbSContext.SaveChangesAsync();

                return RedirectToAction("index");


            }

            return RedirectToAction("index");
        }

    }
}