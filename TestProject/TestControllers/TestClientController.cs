using System;
using System.Collections.Generic;
using booking.common.ViewModel;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using booking.client.Controllers;
using booking.client.Abstract;
using booking.client.Repository;
using Xunit;


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Threading.Tasks;


namespace TestProject.TestControllers
{
    public class TestClientController
    {

        [Fact]
        public void TestGetAllClients()
        {
            // Arrange
            int page = 1, size = 2;
            var testClients = GetTestClients().Skip((page - 1) * size).Take(size);
            var mockLogger = new Mock<ILogger<ClientController>>();
            var mockRepo = new Mock<ClientRepository>();
            //var mockService = new Mock<IClientService>();

            //вот это зачем?
            //mockRepo.Setup(c => c.GetAll(page, size))
            //   .Returns(testClients);
            var controller = new ClientController(mockRepo.Object);

            // Act
            var result = controller.GetAll(page, size);
            
            // Assert
            // var requestResult = Assert.IsType<IEnumerable<Concert>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ClientModel>>(
                result);
            Assert.Equal(2, model.Count());
        }

        private List<ClientModel> GetTestClients()
        {
            var clients = new List<ClientModel>();
            clients.Add(new ClientModel()
            {
                Id = "100",
                Firstname="Анна",
                Middlename="Михайловна",
                Lastname = "Козакова",
                Age =43
            });
            clients.Add(new ClientModel()
            {
                Id = "101",
                Firstname = "Макар",
                Middlename = "Брониславович",
                Lastname = "Румянцев",
                Age =24
            });
            clients.Add(new ClientModel()
            {
                Id = "102",
                Firstname = "Наталия",
                Middlename = "Мироновна",
                Lastname = "Васильева",
                Age =30
            });
           
            return clients;
        }
    }


}
