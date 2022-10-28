using System;
using System.Collections.Generic;
namespace Assignment
{
    public class Helicopter
    {
        List<Customer> passengers = new List<Customer>();
        string departurePlace;
        string arrivalPlace;
        string departureTime;
        int distance;
        int travelTime;
        int cost;

        public int TravelTime { get { return travelTime; } private set { } }
        public string DeparturePlace { get { return departurePlace; } private set { } }
        public string ArrivalPlace { get { return arrivalPlace; } private set { } }
        public string DepartureTime { get { return departureTime; } private set { } }
        public int Distance { get { return distance; } private set { } }
        public int Cost { get { return cost; } private set { } }

        public Helicopter(string departurePlace, string arrivalPlace, string departureTime, int distance)
        {
            this.departurePlace = departurePlace;
            this.arrivalPlace = arrivalPlace;
            this.departureTime = departureTime;
            this.distance = distance;
            decimal minuteMultiplier = Decimal.Divide(distance, 800);
            travelTime = Decimal.ToInt32(minuteMultiplier * 60) + 30;

            Console.WriteLine();
            Console.WriteLine($"Helicopter from {departurePlace} to {arrivalPlace} added");
            Console.WriteLine();
        }

        public void AddPassenger(Customer customer, ref bool Registered)
        {
            if (passengers.Count != 2)
            {
                passengers.Add(customer);
                Console.WriteLine($"Customer {customer.Name} added to Helicopter service.");
                Registered = true;
            }
            else
            {
                Console.WriteLine("This flight is full, please select another service.");
                Registered = false;
            }
        }

        public void DisplayPassengers()
        {
            for (int i = 0; i < passengers.Count; i++)
            {
                Console.WriteLine($"{i + 1} {passengers[i].Name}");
            }
        }

    }
}
