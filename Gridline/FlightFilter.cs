using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gridnine.FlightCodingTest;

namespace Gridnine.FlightCodingTest
{
    public class FlightFilter
    {
        int _filterType;
        /// <summary>
        /// Создание класса фильтрации перелетов по определенному типу
        /// </summary>
        /// <param name="filterType">Тип фильтрации</param>
        public FlightFilter(int filterType)
        {
            _filterType = filterType;
        }
        /// <summary>
        /// Отфильтровать заданные перелеты в соотвествии с заданым фильтром
        /// </summary>
        /// <returns></returns>
        public List<Flight> FFiltreOut(List<Flight> flightsIn)
        {
            if(flightsIn == null || flightsIn.Count == 0)
            {
                return null;
            }
            List<Flight> flightsOut = new List<Flight>();
            switch (_filterType)
            {
                case 0:
                    foreach (var flight in flightsIn)
                    {
                        if (SegmentCheck(0, flight.Segments[0].DepartureDate, DateTime.Now))
                        {
                            flightsOut.Add(flight);
                        }
                    }
                    break;
                case 1:
                    foreach (var flight in flightsIn)
                    {
                        foreach (var segment in flight.Segments)
                        {
                            if (!SegmentCheck(1, segment.ArrivalDate, segment.DepartureDate))
                            {
                                flightsOut.Add(flight);
                                break;
                            }
                        }
                    }
                    break;
                case 2:
                    foreach (var flight in flightsIn)
                    {
                        TimeSpan timeOnEarth = new TimeSpan();
                        for (int i = 0; i < flight.Segments.Count-1; i++)
                        {
                            TimeSpan test = flight.Segments[i + 1].DepartureDate.Subtract(flight.Segments[i].ArrivalDate);
                            timeOnEarth = timeOnEarth.Add(test);
                        }
                        if (timeOnEarth.TotalHours <= 2)
                        {
                            flightsOut.Add(flight);
                        }
                    }
                    break;
                default:
                    Console.Error.WriteLine("Wrong rule for sort flights");
                    return null;
            }
            return flightsOut;
        }
        /// <summary>
        /// Выполнение проверки Сегмента в соответвии с необходимым правилом проверки сегмента
        /// </summary>
        /// <param name="rule">Правило проверки</param>
        /// <param name="date1">Переменная для проверки</param>
        /// <param name="date2">Проверочное значение</param>
        /// <param name="segment">Сегмент для проверки</param>
        /// <returns></returns>
        private bool SegmentCheck(int rule, DateTime date1, DateTime date2 = new DateTime(), Segment segment = null)
        {
            switch (rule)
            {
                case 0:
                    if (date1 > date2)
                    {
                        return true;
                    }else
                    {
                        return false;
                    }
                case 1:
                    if (date1 < date2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    if (date1 == date2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    Console.Error.WriteLine("Wrong rule for sort segment");
                    return false;
            }
        }
    }
}
