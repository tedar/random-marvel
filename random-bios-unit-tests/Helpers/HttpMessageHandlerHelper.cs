using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_bios_unit_tests.Helpers
{
    internal class HttpMessageHandlerHelper
    {
        internal static HttpClient CreateHttpClient(HttpStatusCode code, string responseBody) {
            var handlerMock = new Mock<HttpMessageHandler>();
            var res = new HttpResponseMessage
            {
                StatusCode = code,
                Content = new StringContent(responseBody),
            };
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(res);

            var httpClient = new HttpClient(handlerMock.Object);
            return httpClient;
        }
    }
}
