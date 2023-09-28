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



    public IActionResult TraerDatosDelUsuario(){
        List<Entidad> _listaUsuarios=new List <Entidad>();
        _listaUsuarios=BD.ObtenerUsuarios();
        return View("Bienvenida");
    }

    // EN REGISTRO verifica si el usuario ya existe y verifica si la contraseña cumple con todos los requerimientos
    [HttpPost]
    public IActionResult VerificarRegistro( string _username, string _contra, string _repe, string _nombre, string _gmail, int _tel)
    {
        List<Entidad> _listaUsuarios=new List<Entidad>();
        _listaUsuarios=BD.ObtenerUsuarios();
        bool ok = false;
        
        foreach (Entidad unUsr in _listaUsuarios)
        {
            if (unUsr.Username != _username)
            {
                if (_contra==_repe)
                {
                    ok = true;
                    return View("RegistroExitosos");
                }
            } 
            else
            {
                return View ("RegistroNoExitoso");
            }    
        }
        return ok;
    }


    public IActionResult VerificarIngresos (string _username, string _contra) // EN LOGIN verifica que el usuario exista y que la contraseña sea correcta
    {
        List<Entidad> _listaUsuarios=new List<Entidad>();
        _listaUsuarios=BD.ObtenerUsuarios();
        bool ok;
        foreach (Entidad unUsr in _listaUsuarios)
        {
            if (unUsr.Username == _username)
            {
                if (unUsr.Contrasenia==_contra)
                {
                    ok = true;
                    return View("Bienvenida");
                }    
            }      
        }
    }
}






//LOGIN te pide usuario y contraseña. tenes que verificar si la cuenta está registrada. cuando entras te salta un cartel de bienvenida y si te equivocaste de contraseña te manda a olvidar a contraseña
//REGISTRO te pide usuario, nombre, contraseña 2 veces, mail y telefono. la contraseña debe de tener por lo menos, un carácter especial, una letra en mayúscula y al menos 8 caracteres. Cuando entras te manda un cartel de cuenta creada y un lin a iniciar sesión. EN LA MISMA PÄGINA, si la cuenta ya fue creada anteriormente te dice que ya existe esa cuenta y te pone un link de iniciar sesión
//OLVIDE te pregunta tu usuario y te da tu contraseña
//BIENVENIDA te muestra los datos de tu cuenta
//EN BD traer lista con todos los usuarios