using System.Data.SqlClient;
using Dapper;
public class BD{
    private static string _connectionString = @"Server=localhost; DataBase=LOGIN;Trusted_Connection=True;";



    public static List<Entidad> ObtenerUsuarios(){ //traemos lista de usuarios
        string sql = "SELECT * FROM USUARIO";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            return db.Query<Entidad>(sql).ToList();
        }
    }

    public static void AgregarUsuarios(Entidad ing){
        string SQL = "INSERT INTO  Usuario (Username, Contrasenia, Nombre, Mail, Telefono) VALUES (@pUsername, @pContrasenia, @pNombre, @pMail, @pTelefono)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(SQL, new {pUsername = ing.Username, pContrasenia= ing.Contrasenia, pNombre= ing.Nombre, pMail= ing.Mail, pTelefono= ing.Telefono});
        }
    }

    


}