using System;
using System.Collections.Generic;

namespace Assignment
{
    public class MainIndex
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<Customer> customers = new List<Customer>();
            List<LightAircraft> lightAircrafts = new List<LightAircraft>();
            List<Helicopter> helicopters = new List<Helicopter>();
            Initiate(ref employees, ref customers, ref helicopters, ref lightAircrafts);
        }

        static void Initiate(ref List<Employee> employees, ref List<Customer> customers, ref List<Helicopter> helicopters, ref List<LightAircraft> lightAircrafts)
        {

            Console.WriteLine("Select one of the following option: ");
            Console.WriteLine("1) Register as an Employee");
            Console.WriteLine("2) Log in as an Employee");
            Console.WriteLine("3) Exit");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (index)
            {
                default:
                    Console.WriteLine("Invalid Input");
                    Initiate(ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    break;

                case 1: //Register Employee state
                    RegisterEmployee(out Employee employee);

                    employees.Add(employee); //Add the registered employee to a list

                    Initiate(ref employees, ref customers, ref helicopters, ref lightAircrafts); // Return back to the menu
                    break;

                case 2:
                    if(employees.Count < 1) //Check if there are any registered employess
                    {
                        Console.WriteLine("No Registered Employees"); //If no employees are registered
                        Console.WriteLine(); //
                        Initiate(ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    }
                    else if (employees.Count > 0)
                    {
                        AuthenticateEmployee(ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    }
                    break;

                case 3:
                    Exit();
                    break;
            }

        }

        static Employee RegisterEmployee(out Employee employee)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            employee = new Employee(name, email, password);

            return employee;
        }

        static void AuthenticateEmployee(ref List<Employee> employees, ref List<Customer> customers, ref List<Helicopter> helicopters, ref List<LightAircraft> lightAircrafts)
        {
            bool authentication = false;

            while (authentication == false)
            {
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                foreach (Employee employee in employees)
                {
                    if (email == employee.Email)
                    {
                        if (password == employee.Password)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"{employee.Name} successfully authenticated.");
                            Console.WriteLine("");
                            authentication = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (authentication == false)
                {
                    Console.WriteLine("Incorrect details entered.");
                }
            }

            AuthenticatedMenu(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
        }

        static void AuthenticatedMenu(ref bool authentication, ref List<Employee> employees, ref List<Customer> customers, ref List<Helicopter> helicopters, ref List<LightAircraft> lightAircrafts)
        {
            Console.WriteLine("1) Register a new Customer");
            Console.WriteLine("2) Register a new Light Aircraft");
            Console.WriteLine("3) Register a new Helicopter");
            Console.WriteLine("4) View Existing Services");
            Console.WriteLine("5) View Existing Times");
            Console.WriteLine("6) Add a customer to a flying service");
            Console.WriteLine("7) View Flight Passengers");
            Console.WriteLine("8) Log Out");
            int state = int.Parse(Console.ReadLine());

            switch (state)
            {
                default:
                    Console.WriteLine("Invalid Input");
                    AuthenticatedMenu(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    break;

                case 1:
                    RegisterCustomer(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    break;

                case 2:
                    RegisterLightAircraft(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    break;

                case 3:
                    RegisterHelicopter(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    break;

                case 4:
                    ViewServices(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    break;

                case 5:
                    ViewTimes(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    break;

                case 6:
                    AddCustomerToService(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    break;

                case 8:
                    DisplayServicePassengers(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    break;

                case 7:
                    EmployeeLogOut(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
                    break;

                
            }
        }

        static void EmployeeLogOut(ref bool authentication, ref List<Employee> employees, ref List<Customer> customers, ref List<Helicopter> helicopters, ref List<LightAircraft> lightAircrafts)
        {
            authentication = false;
            Console.WriteLine("");
            Console.WriteLine("Logging out employee");
            Console.WriteLine("");
            Initiate(ref employees, ref customers, ref helicopters, ref lightAircrafts);
        }

        static void RegisterCustomer(ref bool authentication, ref List<Employee> employees, ref List<Customer> customers, ref List<Helicopter> helicopters, ref List<LightAircraft> lightAircrafts)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: "); ;
            string email = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Phone Number: ");
            int number = int.Parse(Console.ReadLine());

            Customer customer = new Customer(name, email, address, number);
            Console.WriteLine();
            Console.WriteLine($"{customer.Name} was registered successfully.");
            Console.WriteLine();
            customers.Add(customer);

            AuthenticatedMenu(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
        }

        static void RegisterLightAircraft(ref bool authentication, ref List<Employee> employees, ref List<Customer> customers, ref List<Helicopter> helicopters, ref List<LightAircraft> lightAircrafts)
        {
            Console.WriteLine("");
            Console.Write("Departure Place: ");
            string departurePlace = Console.ReadLine();
            Console.Write("Arrival Place: ");
            string arrivalPlace = Console.ReadLine();
            Console.Write("Departure Time: ");
            string departureTime = Console.ReadLine();
            Console.Write("Distance: ");
            int distance = int.Parse(Console.ReadLine());
            LightAircraft lightAircraft = new LightAircraft(departurePlace, arrivalPlace, departureTime, distance);
            lightAircrafts.Add(lightAircraft);
            AuthenticatedMenu(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
        }

        static void RegisterHelicopter(ref bool authentication, ref List<Employee> employees, ref List<Customer> customers, ref List<Helicopter> helicopters, ref List<LightAircraft> lightAircrafts)
        {
            Console.WriteLine("");
            Console.Write("Departure Place: ");
            string departurePlace = Console.ReadLine();
            Console.Write("Arrival Place: ");
            string arrivalPlace = Console.ReadLine();
            Console.Write("Departure Time: ");
            string departureTime = Console.ReadLine();
            Console.Write("Distance: ");
            int distance = int.Parse(Console.ReadLine());
            Helicopter helicopter = new Helicopter (departurePlace, arrivalPlace, departureTime, distance);
            helicopters.Add(helicopter);
            AuthenticatedMenu(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
        }

        static void ViewServices(ref bool authentication, ref List<Employee> employees, ref List<Customer> customers, ref List<Helicopter> helicopters, ref List<LightAircraft> lightAircrafts)
        {
            Console.WriteLine();
            Console.WriteLine("Light Aircrafts: ");
            if (lightAircrafts.Count < 1)
            {
                Console.WriteLine("No existing Light Aircraft services.");
            }
            else
            {
                foreach (LightAircraft tempaircraft in lightAircrafts)
                {
                    Console.WriteLine($"Light Aircraft {tempaircraft.DeparturePlace} {tempaircraft.ArrivalPlace} {tempaircraft.Distance}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Helicopters: ");
            if (helicopters.Count < 1)
            {
                Console.WriteLine("No existing Helicopter services.");
                Console.WriteLine();
            }
            else
            {
                foreach (Helicopter temphelicopter in helicopters)
                {
                    Console.WriteLine($"Helicopter {temphelicopter.DeparturePlace} {temphelicopter.ArrivalPlace} {temphelicopter.Distance}");
                }
                Console.WriteLine();
            }
            AuthenticatedMenu(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
        }

        static void ViewTimes(ref bool authentication, ref List<Employee> employees, ref List<Customer> customers, ref List<Helicopter> helicopters, ref List<LightAircraft> lightAircrafts)
        {
            Console.WriteLine();
            Console.WriteLine("Light Aircrafts: ");
            if (lightAircrafts.Count < 1)
            {
                Console.WriteLine("No existing Light Aircraft services.");
            }
            else
            {
                foreach (LightAircraft tempaircraft in lightAircrafts)
                {
                    Console.WriteLine($"Light Aircraft {tempaircraft.DeparturePlace} {tempaircraft.ArrivalPlace} {tempaircraft.DepartureTime} {tempaircraft.TravelTime} minutes");

                }
            }

            Console.WriteLine();
            Console.WriteLine("Helicopters: ");
            if (helicopters.Count < 1)
            {
                Console.WriteLine("No existing Helicopter services.");
                Console.WriteLine();
            }
            else
            {
                foreach (Helicopter temphelicopter in helicopters)
                {
                    Console.WriteLine($"Helicopter {temphelicopter.DeparturePlace} {temphelicopter.ArrivalPlace} {temphelicopter.DepartureTime} {temphelicopter.TravelTime} minutes");
                }
                Console.WriteLine();
            }
            AuthenticatedMenu(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
        }

        static void AddCustomerToService(ref bool authentication, ref List<Employee> employees, ref List<Customer> customers, ref List<Helicopter> helicopters, ref List<LightAircraft> lightAircrafts)
        {

            Console.WriteLine();
            for (int i = 0; i < customers.Count; i++) // Print list of registered Customers
            {
                Console.WriteLine($"{i + 1} {customers[i].Name}");
            }
            Console.Write("Get the customer number: ");
            int customerNum = int.Parse(Console.ReadLine()) - 1; // Set variable for selected customer
            int flightNum = 0;
            bool Registered = false;
            while (Registered == false)
            {
                GetFlightNum(ref flightNum, ref lightAircrafts, ref helicopters);


                if (flightNum > lightAircrafts.Count)
                {
                    flightNum = flightNum - lightAircrafts.Count - 1;
                    helicopters[flightNum].AddPassenger(customers[customerNum], ref Registered);
                }
                else if (flightNum <= lightAircrafts.Count)
                {
                    flightNum = flightNum - 1;
                    lightAircrafts[flightNum].AddPassenger(customers[customerNum], ref Registered);
                }
            }
            Console.WriteLine();
            AuthenticatedMenu(ref authentication, ref employees, ref customers, ref helicopters, ref lightAircrafts);
        }

        static void DisplayServicePassengers(ref bool authentication, ref List<Employee> employees, ref List<Customer> customers, ref List<Helicopter> helicopters, ref List<LightAircraft> lightAircrafts)
        {
            int flightNum = 0;
            GetFlightNum(ref flightNum, ref lightAircrafts, ref helicopters);

            if (flightNum > lightAircrafts.Count)
            {
                flightNum = flightNum - lightAircrafts.Count - 1;
                helicopters[flightNum].DisplayPassengers();
            }
            else if (flightNum <= lightAircrafts.Count)
            {
                flightNum = flightNum - 1;
                lightAircrafts[flightNum].DisplayPassengers();
            }
        }

        static void GetFlightNum(ref int flightNum, ref List<LightAircraft> lightAircrafts, ref List<Helicopter> helicopters)
        {
            for (int i = 0; i < lightAircrafts.Count; i++)
            {
                Console.WriteLine($"{i + 1} {lightAircrafts[i].DeparturePlace} {lightAircrafts[i].ArrivalPlace}");
            }
            for (int i = 0; i < helicopters.Count; i++)
            {
                Console.WriteLine($"{i + 1 + lightAircrafts.Count} {helicopters[i].DeparturePlace} {helicopters[i].ArrivalPlace}");
            }
            Console.Write("Get the flight number: ");
            flightNum = int.Parse(Console.ReadLine());
        }

        static void Exit()
        {
            Console.WriteLine("Exiting application...");
            Environment.Exit(-1);
        }
    }
}
