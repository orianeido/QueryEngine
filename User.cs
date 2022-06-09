using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Engine
{
    class User
    {
        public string Email;
        public string FullName;
        public int Age;

        public User(string email, string fullName, int age)
        {
            Email = email;
            FullName = fullName;
            Age = age;
        }

        public string userValuesByFields(string[] fields)
        {
            string s = "";
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == "FullName")
                {
                    s += FullName + " ";
                }
                else if (fields[i] == "Email")
                {
                    s += Email +" ";
                }
                else
                {
                    s += Age + " ";
                }
            }
            s += "\n";
            return s;
        }
    }
}
