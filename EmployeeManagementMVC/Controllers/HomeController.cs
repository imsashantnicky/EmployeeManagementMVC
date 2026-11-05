using Microsoft.AspNetCore.Mvc;
namespace EmployeeManagementMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}