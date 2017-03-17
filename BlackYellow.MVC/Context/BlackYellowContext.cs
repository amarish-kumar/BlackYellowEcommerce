
using MySql.Data.MySqlClient;  

namespace BlackYellow.MVC.Context
{
    public class BlackYellowContext
    {
        // criando a conexão com o banco de dados MYSQL
        public MySqlConnection Connection = new MySqlConnection("Server=177.153.22.229;Database=BlackYellow; Uid=root;Pwd=FQVbgq77901;SslMode=None;");
    }
}
