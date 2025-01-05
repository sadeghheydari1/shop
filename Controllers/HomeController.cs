using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProjectC_.Models;

namespace ProjectC_.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string name,string email,string password){
      

  Context db=new Context();
  User user=new User();
  user.NameFamily=name;
  user.Email=email;
  user.Password=password;
  db.TblUser.Add(user);
  db.SaveChanges();
  ViewBag.Message="ثبت نام شما با موفقیت انجام شد";

    return View();
    }

    public IActionResult Login()
    {
        return View();
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
