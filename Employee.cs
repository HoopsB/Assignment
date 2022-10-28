using System;
using System.Collections.Generic;

namespace Assignment
{
    class Employee
    {
        string name;
        string email;
        string password;

        public string Name { get { return name; } private set { } }
        public string Email { get { return email; } private set { } }
        public string Password { get { return password; } private set { } }

        public Employee(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;


            Console.WriteLine("");
            Console.WriteLine($"{name} successfully registered");
            Console.WriteLine();
        }
    }
}
