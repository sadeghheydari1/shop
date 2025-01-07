using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
    public IActionResult Register(User us){
      
  if(!ModelState.IsValid)
  {
    return View();
  }      

  Context db=new Context();

  if(db.TblUser.Any(a=>a.Email==us.Email))
  {
    ViewBag.Error="این ایمیل قبلا ثبت شده است";
    return View();
  }

  User user=new User();
  user.NameFamily=us.NameFamily;
  user.Email=us.Email;
  user.Password=us.Password;
  db.TblUser.Add(user);
  db.SaveChanges();
  ViewBag.Message="ثبت نام شما با موفقیت انجام شد";

    return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(DLogin lg){
      if(!ModelState.IsValid)
      {
        return View();
      }
      Context db=new Context();
      if(db.TblUser.Any(a=>a.Email==lg.Email && a.Password==lg.Password))
      {
       
       //create cookie
        var claims=new List<Claim>
        {
        new Claim(ClaimTypes.Name,lg.Email)
      };
      var identity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
      var principal=new ClaimsPrincipal(identity);
      HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
      
      

        
        return RedirectToAction("Profile","Home");
      }
      ViewBag.Error="ایمیل یا رمز عبور اشتباه است";
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

[Authorize]
    public IActionResult Profile()
    {
        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
