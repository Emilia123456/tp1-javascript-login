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



}