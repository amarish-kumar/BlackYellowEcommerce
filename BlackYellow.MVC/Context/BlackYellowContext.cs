
using MySql.Data.MySqlClient;

namespace BlackYellow.MVC.Context
{
    public class BlackYellowContext
    {
        // criando a conexão com o banco de dados MYSQL
        public System.Data.IDbConnection Connection
        {
            get
            {
                return GetConnection();
            }
        }

        private System.Data.IDbConnection GetConnection()
        {
            return new MySqlConnection(ConfigConnection); ;
        }


        public static string ConfigConnection { get; set; }


    }
}
