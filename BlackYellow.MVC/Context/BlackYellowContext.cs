
using MySql.Data.MySqlClient;  

namespace BlackYellow.MVC.Context
{
    public class BlackYellowContext
    {
        // criando a conexão com o banco de dados MYSQL
        public MySqlConnection Connection = new MySqlConnection("Server=localhost;Database=blackyellowdb; Uid=root;Pwd=Senac2016;SslMode=None;");
    }
}
