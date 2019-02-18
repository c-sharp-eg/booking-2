using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq;
using booking.client.Controllers;
using booking.client.Model;
using booking.client.Repository;
using booking.client.Abstract;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using booking.common.ViewModel;

namespace TestProject.TestControllers
{
    public class GetAllClient
    {
        [Fact]
        public void TestGetAllClients()
        {
            var testClients = GetTestClients();
            var mockLogger = new Mock<ILogger<ClientController>>();
            var mockRepo = new Mock<IClientRepository>();

            mockRepo.Setup(c => c.GetAll())
               .Returns(testClients);
            var controller = new ClientController(mockRepo.Object);

            // Act
            var result = controller.GetAll(0, 0);

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<ClientModel>>>(result);
            var model = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(3, (model.Value as IEnumerable<ClientModel>).Count());
        }

        private IEnumerable<Client> GetTestClients()
        {
            var clients = new List<Client>
            {
                new Client()
                {
                    Id = "100",
                    Firstname = "Анна",
                    Middlename = "Михайловна",
                    Lastname = "Козакова",
                    Age = 43
                },
                new Client()
                {
                    Id = "101",
                    Firstname = "Макар",
                    Middlename = "Брониславович",
                    Lastname = "Румянцев",
                    Age = 24
                },
                new Client()
                {
                    Id = "102",
                    Firstname = "Наталия",
                    Middlename = "Мироновна",
                    Lastname = "Васильева",
                    Age = 30
                }
            };

            return clients;
        }
    }


}
