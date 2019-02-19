using booking.client.Abstract;
using booking.client.Controllers;
using booking.client.Model;
using booking.common.ViewModel;
using booking.flight.Abstract;
using booking.flight.Controllers;
using booking.flight.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.TestFlights
{
    public class PutFlight
    {
        [Fact]
        public async Task TestPutFlightNotFoundResult()
        {
            // Arrange & Act
            var mockRepoFlight = new Mock<IFlightRepository>();
            var mockRepoAircraft = new Mock<IAircraftRepository>();
            //var mockLogger = new Mock<ILogger<ConcertsController>>();
            var controller = new FlightController(mockRepoFlight.Object, mockRepoAircraft.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result =  controller.Put(id: "0", model: null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task TestPutFlightReturnsNotFoundResultId()
        {
            // Arrange
            String testId = "101";
            FlightModel flight = GetTestFlights()[0];
            var mockRepoFlight = new Mock<IFlightRepository>();
            var mockRepoAircraft = new Mock<IAircraftRepository>();
            var controller = new FlightController(mockRepoFlight.Object, mockRepoAircraft.Object);

            // Act
            var result =  controller.Put(testId, flight);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task TestPutFlightOkResult()
        {
            // Arrange
            String testId = "100";
            FlightModel flight = GetTestFlights()[0];
            var mockRepoFlight = new Mock<IFlightRepository>();
            var mockRepoAircraft = new Mock<IAircraftRepository>();
            
            var controller = new FlightController(mockRepoFlight.Object, mockRepoAircraft.Object);

            // Act
            var result = controller.Put(testId, flight);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task TestPutAircraftNotFoundResult()
        {
            // Arrange & Act
            
            var mockRepoAircraft = new Mock<IAircraftRepository>();
            var controller = new AircraftController(mockRepoAircraft.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = controller.Put(id: "0", model: null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task TestPutAircraftReturnsNotFoundResultId()
        {
            // Arrange
            String testId = "101";
            AircraftModel aircraft = GetTestAircrafts()[0];
            
            var mockRepoAircraft = new Mock<IAircraftRepository>();
            var controller = new AircraftController(mockRepoAircraft.Object);

            // Act
            var result = controller.Put(testId, aircraft);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task TestPutAircraftOkResult()
        {
            // Arrange
            String testId = "100";
            AircraftModel aircraft = GetTestAircrafts()[0];
            var mockRepoAircraft = new Mock<IAircraftRepository>();

            var controller = new AircraftController(mockRepoAircraft.Object);

            // Act
            var result = controller.Put(testId, aircraft);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        private List<FlightModel> GetTestFlights()
        {
            var flights = new List<FlightModel>
            {
                new FlightModel()
                {
                    Id = "100",
                    Number = "SU102",
                    AircraftId = "1000",
                    FreeSeats = 1,
                    Sum = 1000
                },
                new FlightModel()
                {
                    Id = "101",
                    Number = "AR111",
                    AircraftId = "1100",
                    FreeSeats = 10,
                    Sum = 2000
                },
                new FlightModel()
                {
                    Id = "102",
                    Number = "SU115",
                    AircraftId = "1200",
                    FreeSeats = 55,
                    Sum = 3000
                }
            };
            return flights;
        }


        private List<AircraftModel> GetTestAircrafts()
        {
            var aircrafts = new List<AircraftModel>
            {
                new AircraftModel()
                {
                    Id = "1100",
                    Name = "SU102",
                    NumberOfSeats = 1,
                },
                new AircraftModel()
                {
                    Id = "1200",
                    Name = "SU102",
                    NumberOfSeats = 15,
                },
                new AircraftModel()
                {
                    Id = "1300",
                    Name = "SU102",
                    NumberOfSeats = 60,
                }
            };
            return aircrafts;
        }


    }
}
