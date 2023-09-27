public class Entidad{
    public string Username {get; set;}
    public string Contrasenia {get; set;}
    public string Nombre {get; set;}
    public string Mail {get; set;}
    public int Telefono {get; set;}
    public int Id {get; set;}

    public Entidad(){
        
    }

    public Entidad(string username, string contrasenia, string nombre, string mail, int telefono, int id){
        Username = username;
        Contrasenia = contrasenia;
        Nombre = nombre;
        Mail = mail;
        Telefono = telefono;
        Id = id;
    }
}