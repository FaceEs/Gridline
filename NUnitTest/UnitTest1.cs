using NUnit.Framework;
using Gridnine.FlightCodingTest;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTest
{
    public class Tests
    {
        List<Flight> flights;
        FlightFilter filter;
        [SetUp]
        public void Setup()
        {
            FlightBuilder builder = new FlightBuilder();
            flights = builder.GetFlights().ToList();
        }

        [Test]
        public void Test1Quest()
        {
            filter = new FlightFilter(0);
            if (filter.FFiltreOut(flights).Count != 0)
            {
                Assert.Pass();
            }
            else Assert.Fail();
            
        }

        [Test]
        public void Test2Quest()
        {
            filter = new FlightFilter(1);
            if (filter.FFiltreOut(flights).Count != 0)
            {
                Assert.Pass();
            }
            else Assert.Fail();

        }
        [Test]
        public void Test3Quest()
        {
            filter = new FlightFilter(2);
            if (filter.FFiltreOut(flights).Count != 0)
            {
                Assert.Pass();
            }
            else Assert.Fail();

        }
        [Test]
        public void TestNotAllowedFilterType()
        {
            filter = new FlightFilter(5);
            if (filter.FFiltreOut(flights) == null)
            {
                Assert.Pass();
            }
            else Assert.Fail();

        }
        [Test]
        public void TestEmptyFlights()
        {
            filter = new FlightFilter(5);
            if (filter.FFiltreOut(new List<Flight>()) == null)
            {
                Assert.Pass();
            }
            else Assert.Fail();

        }
        [Test]
        public void TestNullFlights()
        {
            filter = new FlightFilter(5);
            if (filter.FFiltreOut(null) == null)
            {
                Assert.Pass();
            }
            else Assert.Fail();

        }
    }
}