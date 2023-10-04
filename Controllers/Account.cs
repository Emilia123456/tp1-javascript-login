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
    public IActionResult VerificarRegistro( string _username, string _contra, string _repe, string _nombre, string _gmail, int _tel, int _id)
    {
        string TXT;
        Entidad entidad = BD.ObtenerPorNombre(_username);
            if (entidad == null)
            {
                Console.WriteLine("pipi");
                if (_contra==_repe)
                {
                    BD.AgregarUsuarios(new Entidad(_username, _contra, _nombre, _gmail, _tel, _id));
                    TXT="Registro exitoso";
                    ViewBag.txt=TXT;
                }else{
                    TXT="Registro no exitoso. Repita la contraseña correctamente";
                    ViewBag.txt=TXT;
                }    
            } 
            else
            {
                TXT="Registro no exitoso. El usuario ya existe, intentelo de nuevo";
                ViewBag.txt=TXT;
            }    
        
        return View ("Respuesta");
    }


    public IActionResult VerificarInicio(string _username, string _contra) // EN LOGIN verifica que el usuario exista y que la contraseña sea correcta
    {
        List<Entidad> _listaUsuarios=new List<Entidad>();
        _listaUsuarios=BD.ObtenerUsuarios();
        string TXT;
        foreach (Entidad unUsr in _listaUsuarios)
        {
            if (unUsr.Username == _username)
            {
                if (unUsr.Contrasenia==_contra)
                {
                    ViewBag.Usuario=unUsr;
                    return View("Bienvenida");
                }    
                else{
                    TXT="Contraseña incorrecta";
                    ViewBag.txt=TXT;
                    return View("Respuesta");
                }
            }  
        }
        ViewBag.listaUsuarios=_listaUsuarios;
        return View();
    }

    public IActionResult Respuesta(){
       return View();
    }

    public IActionResult Login(){
       return View();
    }

    public IActionResult Bienvenida(){
        List<Entidad> _listaUsuarios=new List<Entidad>();
        ViewBag._listaUsuarios=BD.ObtenerUsuarios();
       
       return View();
    }

    public IActionResult Olvide(){
        
       return View();
    }

    public IActionResult Contrasenia(string _username){
        Entidad ent = BD.ObtenerPorNombre(_username);
        ViewBag.contra=ent.Contrasenia;
       return View();
    }
    
}




//LOGIN te pide usuario y contraseña. tenes que verificar si la cuenta está registrada. cuando entras te salta un cartel de bienvenida y si te equivocaste de contraseña te manda a olvidar a contraseña
//REGISTRO te pide usuario, nombre, contraseña 2 veces, mail y telefono. la contraseña debe de tener por lo menos, un carácter especial, una letra en mayúscula y al menos 8 caracteres. Cuando entras te manda un cartel de cuenta creada y un lin a iniciar sesión. EN LA MISMA PÄGINA, si la cuenta ya fue creada anteriormente te dice que ya existe esa cuenta y te pone un link de iniciar sesión
//OLVIDE te pregunta tu usuario y te da tu contraseña
//BIENVENIDA te muestra los datos de tu cuenta
//EN BD traer lista con todos los usuarios