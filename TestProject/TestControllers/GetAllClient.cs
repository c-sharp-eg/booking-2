using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using booking.client.Controllers;
using booking.client.Model;
using booking.client.Abstract;
using booking.client.Repository;
using Xunit;

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.TestControllers
{
    [TestClass]
    public class GetAllClient
    {

        [TestMethod]
        public void TestGetAllClients()
        {
            // Arrange
            //int page = 1, size = 2;
            var testClients = GetTestClients();//.Skip((page - 1) * size).Take(size);
            var mockLogger = new Mock<ILogger<ClientController>>();
            var mockRepo = new Mock<IClientRepository>();
            //var mockService = new Mock<IClientService>();

            mockRepo.Setup(c => c.GetAll())
               .Returns(testClients);
            var controller = new ClientController(mockRepo.Object);

            // Act
            var result =  controller.GetAll(0,0);
            

            // Assert
            // var requestResult = Assert.IsType<IEnumerable<Concert>>(result);
            var model = Xunit.Assert.IsAssignableFrom<IEnumerable<Client>>(
                result);
            Xunit.Assert.Equal(2, model.Count());
        }

        private List<Client> GetTestClients()
        {
            var clients = new List<Client>();
            clients.Add(new Client()
            {
                Id = "100",
                Firstname="Анна",
                Middlename="Михайловна",
                Lastname = "Козакова",
                Age =43
            });
            clients.Add(new Client()
            {
                Id = "101",
                Firstname = "Макар",
                Middlename = "Брониславович",
                Lastname = "Румянцев",
                Age =24
            });
            clients.Add(new Client()
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
