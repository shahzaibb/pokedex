using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace Pokedex.Tests
{
	public class MockHttpMessageHandler : Mock<HttpMessageHandler>
	{
		public MockHttpMessageHandler CreatMockMessageHandler(HttpResponseMessage response)
		{
			this.Protected()
				.Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(response);
			return this;
		}
	}
}

