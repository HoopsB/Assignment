using System;
namespace Assignment
{
    public class Customer
    {
        string name;
        string email;
        string address;
        int phNumber;

        public string Name { get { return name; } private set { } }
        public string Email { get { return email; } private set { } }
        public string Address { get { return address; } private set { } }
        public int PHNumber { get { return phNumber; } private set { } }

        public Customer(string name, string email, string address, int phNumber)
        {
            this.name = name;
            this.email = email;
            this.address = address;
            this.phNumber = phNumber;
        }
    }
}
