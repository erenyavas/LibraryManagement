using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation
{
    internal class DatabaseHelper
    {
        public MySqlConnection GetDatabaseConnection()
        {
            return new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=''");
        }
    }
}
