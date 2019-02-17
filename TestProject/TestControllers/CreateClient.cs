using booking.client.Abstract;
using booking.client.Controllers;
using booking.client.Model;
using booking.client.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.TestControllers
{
    public class CreateClient
    {
        /*
        [Fact]
        public async Task PostConcertReturnsCreaterAtActionResultTest()
        {
            // Arrange
            string testId = "100";
            Client concert = GetTestClients().FirstOrDefault(p => p.Id == testId);
            var mockLogger = new Mock<ILogger<ClientController>>();
            var mockRepo = new Mock<IClientRepository>();
            mockRepo.Setup(c => c.Add(concert))
                .Returns(EntityState.Added);
            mockRepo.Setup(c => c.SaveChanges())
                .Returns(Task.CompletedTask);
            var controller = new ConcertsController(mockRepo.Object, mockLogger.Object);

            // Act
            var result = await controller.PostConcert(concert);

            // Assert
            var requestResult = Assert.IsType<CreatedAtActionResult>(result);
            var model = Assert.IsType<Concert>(requestResult.Value);
            Assert.Equal(concert.Id, model.Id);
            Assert.Equal(concert.VenueId, model.VenueId);
            Assert.Equal(concert.PerfomerId, model.PerfomerId);
            Assert.Equal(concert.Date, model.Date);
        }
        

        private List<Client> GetTestClients()
        {
            var clients = new List<Client>();
            clients.Add(new Client()
            {
                Id = "100",
                Firstname = "Анна",
                Middlename = "Михайловна",
                Lastname = "Козакова",
                Age = 43
            });
            clients.Add(new Client()
            {
                Id = "101",
                Firstname = "Макар",
                Middlename = "Брониславович",
                Lastname = "Румянцев",
                Age = 24
            });
            clients.Add(new Client()
            {
                Id = "102",
                Firstname = "Наталия",
                Middlename = "Мироновна",
                Lastname = "Васильева",
                Age = 30
            });
        }
        */
    }
}
