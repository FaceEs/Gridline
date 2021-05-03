using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightBuilder builder = new FlightBuilder();
            List<Flight> flights = builder.GetFlights().ToList<Flight>();
            FlightFilter filter1 = new FlightFilter(0);
            FlightFilter filter2 = new FlightFilter(1);
            FlightFilter filter3 = new FlightFilter(2);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Все полеты");
            Console.ResetColor();
            PrintFlights(flights);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание №1");
            Console.ResetColor();
            PrintFlights(filter1.FFiltreOut(flights));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание №2");
            Console.ResetColor();
            PrintFlights(filter2.FFiltreOut(flights));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание №3");
            Console.ResetColor();
            PrintFlights(filter3.FFiltreOut(flights));

            Console.ReadLine();
        }
        static void PrintFlights(List<Flight> flights)
        {
            int fligntNum = 0;
            foreach (var flight in flights)
            {
                fligntNum++;
                Console.WriteLine("\tПолет №" + fligntNum + ":");
                for (int i = 0; i < flight.Segments.Count; i++)
                {
                    Console.WriteLine("\t\0\0 Сегмент №" + i + ". Время отлета - " + flight.Segments[i].DepartureDate + ". Время прилета - " + flight.Segments[i].ArrivalDate);
                }
            }
        }
    }
}
