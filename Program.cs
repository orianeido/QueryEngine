using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            hardCodedUsers(users);
            Data data = new Data(users);

            SQL query = new SQL(getQueryFromUser(), data);

            Console.WriteLine(query.runQuery());
            Console.ReadLine();
        }

        static void hardCodedUsers(List<User> users)
        {
            users.Add(new User("avi@gmail.com", "Avi Orinae", 52));
            users.Add(new User("noa@gmail.com", "Noa Ventura", 25));
            users.Add(new User("ido@gmail.com", "Ido Oriane", 24));
        }
        static string getQueryFromUser()
        {
            string query;
            Console.WriteLine("Please Enter Your Query:");
            Console.WriteLine("Format - FROM <Source> WHERE <Expression> SELECT <Field>");
            query = Console.ReadLine();
            return query;
        }
    }
}
