using HW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


/* Northwind veritabanı üzerinde çalışacak bir MVC uygulaması geliştireceksiniz. Uygulamanın akışı ve ekranları aşağıdaki gibi olacak:
 
1. İlk olarak çalışanların listelendiği ekran açılacak. Bu ekranda çalışanın adı, soyadı ve ünvanı yer alacak.

2. Bu ekranda her çalışanın yanında Siparişler ve Profilim linkleri yer alacak

3. Siparişler linkine tıklandığında o çalışanın ilgilendiği siparişler listelenecek. Sipariş no, sipariş tarihi ve müşteri adı yer alacak.
   Ayrıca her siparişin yanında Ürünler linki yer alacak.

4. Ürünler linkine tıklandığında o siparişte yer alan ürünlerin adı ve miktarının listelendiği ekran açılacak.

5. Profilim linkine tıklandığında o çalışanın adı, soyadı, pozisyonu, doğum tarihi, telefonu ve adresi bilgilerinin yer aldığı sayfa açılacak. 
   İstenirse bu sayfa üzerinden iletişim bilgileri güncellenebilecek.*/

namespace HW.Controllers
{
    public class HomeController : Controller
    {
        //  NorthwindDbContext context = new NorthwindDbContext();
        NorthwindDbContext context = new NorthwindDbContext();
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            
            return View(context.Employees.ToList());
        }
        
        public IActionResult Profil()
        {

            return View(context.Employees.ToList());
        }

        public IActionResult Siparisler()
        {

            return View(context.Orders.ToList());
        }
        
        public IActionResult UrunDetay()  //ürünlerin adı ve miktarının listelendiği ekran açılacak.
        {
            
            return View(context.Products.ToList());
        }

        
        public IActionResult EmployeeEdit()
        {

            return View(context.Employees.ToList());
        }

        [HttpGet]

        public IActionResult EditedEmployeeInfo()
        {
            return View(context.Employees.ToList());
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