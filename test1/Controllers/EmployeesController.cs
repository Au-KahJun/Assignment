using Microsoft.AspNetCore.Mvc;

namespace test1.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

    }
}
