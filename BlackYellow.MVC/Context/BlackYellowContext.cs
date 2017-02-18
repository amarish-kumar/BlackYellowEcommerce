
using MySql.Data.MySqlClient;  

namespace BlackYellow.MVC.Context
{
    public class BlackYellowContext
    {
        // criando a conexão com o banco de dados MYSQL
        public MySqlConnection Connection = new MySqlConnection("Server=localhost;Database=BlackYellowDb; Uid=root;Pwd=root;SslMode=None;");
    }
}
