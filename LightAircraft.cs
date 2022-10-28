using System;
using System.Collections.Generic;
namespace Assignment
{
    public class LightAircraft
    {
        List<Customer> passengers = new List<Customer>();
        string departurePlace;
        string arrivalPlace;
        string departureTime;
        int distance;
        int travelTime;

        public decimal TravelTime { get { return travelTime; } private set { } }
        public string DeparturePlace { get { return departurePlace; } private set { } }
        public string ArrivalPlace { get { return arrivalPlace; } private set { } }
        public string DepartureTime { get { return departureTime; } private set { } }
        public int Distance { get { return distance; } private set { } }

        public LightAircraft(string departurePlace, string arrivalPlace, string departureTime, int distance)
        {
            this.departurePlace = departurePlace;
            this.arrivalPlace = arrivalPlace;
            this.departureTime = departureTime;
            this.distance = distance;
            decimal minuteMultiplier = Decimal.Divide(distance, 800);
            travelTime =  Decimal.ToInt32(minuteMultiplier * 60) + 30;

            Console.WriteLine();
            Console.WriteLine($"Light Aircraft from {departurePlace} to {arrivalPlace} added");
            Console.WriteLine();
        }

        public void AddPassenger(Customer customer, ref bool Registered)
        {
            if (passengers.Count != 6)
            {
                passengers.Add(customer);
                Console.WriteLine($"Customer {customer.Name} added to Light Aircraft service.");
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
