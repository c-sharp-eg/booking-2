using booking.client.Abstract;
using booking.client.Model;
using booking.client.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Linq;
using booking.common.ViewModel;

namespace TestProject.TestControllers
{
    public class TestGetClientById
    {
        [Fact]
        public void TestGetClient()
        {
            String testid = "100";
            var testClients = GetTestClients();
            ClientModel client = GetTestClients().FirstOrDefault(p => p.Id == testid);
            //var mockLogger = new Mock<ILogger<ClientController>>();
            var mockRepo = new Mock<IClientRepository>();

            mockRepo.Setup(c => c.Get(testid))
               .Returns(client);
            var controller = new ClientController(mockRepo.Object);

            // Act
            var result = controller.GetbyId(testid);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ClientModel>>(result);
            var model = Assert.IsType<OkObjectResult>(actionResult.Result);
            //Assert.Equal(3, (model.Value as IEnumerable<Client>).Count());
            Assert.Single((model as IEnumerable<ClientModel>));
            
        }



        private IEnumerable<ClientModel> GetTestClients()
        {
            var clients = new List<ClientModel>
            {
                new ClientModel()
                {
                    Id = "100",
                    Firstname = "Анна",
                    Middlename = "Михайловна",
                    Lastname = "Козакова",
                    Age = 43
                },
                new ClientModel()
                {
                    Id = "101",
                    Firstname = "Макар",
                    Middlename = "Брониславович",
                    Lastname = "Румянцев",
                    Age = 24
                },
                new ClientModel()
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

