using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tp1_javascript_login.Models;

namespace tp1_javascript_login.Controllers;

public class Account : Controller
{
    private readonly ILogger<Account> _logger;

    public Account(ILogger<Account> logger)
    {
        _logger = logger;
    }

    public IActionResult Registro ()
    {
        return View();
    }

}
