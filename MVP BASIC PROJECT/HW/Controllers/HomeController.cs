using HW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HW.Controllers
{
    public class HomeController : Controller
    {
        NorthwindDbContext context = new NorthwindDbContext();
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Index()
        {

            List<Employee> employees = context.Employees.Select(a => new Employee()
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                Title = a.Title,
                EmployeeId = a.EmployeeId
            }).ToList();

            return View(employees);
        }

        public IActionResult Orders(int id)
        {

            List<Order> orders = context.Orders.Include(a => a.Customer)
            .Where(a => a.EmployeeId == id)
            .Select(a => new Order()
            {
                OrderId = a.OrderId,
                OrderDate = a.OrderDate,
                Customer = a.Customer
            }).ToList();

            return View(orders);
        }
        public IActionResult ProductDetail(int id)  
        {
            List<OrderDetail> orderDetails = context.OrderDetails.Include(a => a.Product)
                                                    .Where(a => a.OrderId == id)
                                                    .Select(a => new OrderDetail()
                                                    {
                                                        Product = a.Product,
                                                        Quantity = a.Quantity,
                                                        UnitPrice = a.UnitPrice

                                                    }).ToList();

            return View(orderDetails);
        }
        public IActionResult Profile(int id)
        {
            Employee employee = context.Employees.SingleOrDefault(a => a.EmployeeId == id);

            if (employee == null)
            {
                ViewBag.Message = "No such employee found!";
                return View();
            }
            else
            {
                EmployeeDetailViewModel model = new EmployeeDetailViewModel()
                    {
                    Name = employee.FirstName, 
                    Surname = employee.LastName,
                    Title = employee.Title,
                    BirthDate = employee.BirthDate,
                    City = employee.City,
                    Phone = employee.HomePhone,
                    Country = employee.Country,
                    EmployeeId =employee.EmployeeId
                };
                
                return View(model);
            }    
        }

        [HttpPost("{id}")]
        public IActionResult Update([FromRoute]int id, EmployeeDetailViewModel model)
        {
            Employee employee = context.Employees.SingleOrDefault(a => a.EmployeeId == id);

            if (employee != null)
            {
                employee.City = model.City;
                employee.Country = model.Country;
                employee.HomePhone = model.Phone;
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

   
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}