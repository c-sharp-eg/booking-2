
using booking.common.ViewModel;
using booking.flight.Abstract;
using booking.flight.Controllers;
using booking.flight.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.TestFlights
{
    public class CreateFlight
    {
        
        [Fact]
        public async Task TestCreateFlight()
        {
            // Arrange
            string testId = "100";
            Flight flight = GetTestFlights().FirstOrDefault(p => p.Id == testId);
            Aircraft aircraft = GetTestAircrafts().FirstOrDefault(p => p.Id == testId);
            //var mockLogger = new Mock<ILogger<ClientController>>();
            var testAircraft = GetTestAircrafts();
            var mockRepoAircraft = new Mock<IAircraftRepository>();
            var mockRepoFlight = new Mock<IFlightRepository>();
            mockRepoFlight.Setup(c => c.Add(flight));
            mockRepoAircraft.Setup(c => c.Add(aircraft));
            var controller = new FlightController(mockRepoFlight.Object, mockRepoAircraft.Object);

            // Act
            var result =  controller.Post(flight);

            // Assert
            var actionResult = Assert.IsType<OkResult>(result);
           
            var model = Assert.IsType<OkResult>(actionResult);
            
        }

        [Fact]
        public async Task TestCreateAircraft()
        {
            // Arrange
            string testId = "100";
            FlightModel flight = GetTestFlights().FirstOrDefault(p => p.Id == testId);
            AircraftModel aircraft = GetTestAircrafts().FirstOrDefault(p => p.Id == testId);
            //var mockLogger = new Mock<ILogger<ClientController>>();
            var testAircraft = GetTestAircrafts();
            var mockRepoAircraft = new Mock<IAircraftRepository>();
            var mockRepoFlight = new Mock<IFlightRepository>();
            mockRepoFlight.Setup(c => c.Add(flight));
            mockRepoAircraft.Setup(c => c.Add(aircraft));
            var controller = new AircraftController(mockRepoAircraft.Object);

            // Act
            var result = controller.Post(aircraft);

            // Assert
            var actionResult = Assert.IsType<OkResult>(result);

            var model = Assert.IsType<OkResult>(actionResult);

        }

        /*
        [Fact]
        public async Task TestCreateClient()
        {
            // Arrange
            string testId = "100";
            Client client = GetTestClients().FirstOrDefault(p => p.Id == testId);
            //var mockLogger = new Mock<ILogger<ClientController>>();

            var mockRepo = new Mock<IClientRepository>();
            mockRepo.Setup(c => c.Add(client));
            //mockRepo.Setup(c => c.SaveChanges())
            //    .Returns(Task.CompletedTask);
            var controller = new ClientController(mockRepo.Object);

            // Act
            var result = controller.Post(client);

            // Assert
            var actionResult = Assert.IsType<OkResult>(result);

            var model = Assert.IsType<OkResult>(actionResult);
            /*
            Assert.Equal(client.Id, model.Id);
            Assert.Equal(client.Firstname, model.Firstname);
            Assert.Equal(client.Middlename, model.Middlename);
            Assert.Equal(client.Lastname, model.Lastname);
            Assert.Equal(client.Age, model.Age);
            */




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
