using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace WebAPITest1.UnitTests.Helpers { 
    internal static class MockHttpMessageHandler<T>
    {
        internal static Mock<HttpMessageHandler> SetupBasicGetResoureceList(List<T> expectedResponse)
        {
            var mockResponse = new HttpRequestMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
            };

            mockResponse.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpRequestMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                 ).ReturnsAsync(mockResponse);

            return handlerMock;
        }
    }
}