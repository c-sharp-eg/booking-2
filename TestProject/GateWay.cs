using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject
{
    class GateWay
    {
        [Fact]
        public async Task TestGetAll()
        {
            int testId = 1;
            var mockLogger = new Mock<ILogger<ConcertsController>>();
            var mockService = new Mock<IGatewayService>();
            mockService.Setup(c => c.GetConcerts(testId, testId))
                .ReturnsAsync(GetTestConcerts());
            mockService.Setup(c => c.GetPerfomerById(testId))
                .ReturnsAsync(GetPerfomer(testId));
            mockService.Setup(c => c.GetVenueById(testId))
                .ReturnsAsync(GetVenue(testId));
            var controller = new ConcertsController(mockService.Object, mockLogger.Object);

            // Act
            var result = await controller.Get(testId, testId);

            // Assert
            var requestResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<ConcertRequest>>(requestResult.Value);
            Assert.Single(model);
        }
    }
}
