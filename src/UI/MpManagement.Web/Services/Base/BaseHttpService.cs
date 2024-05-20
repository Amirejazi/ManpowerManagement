using Hanssens.Net;
using MpManagement.Web.Services.Client.Impeliments;
using MpManagement.Web.Services.Client.Interfaces;
using System.Net.Http.Headers;

namespace MpManagement.Web.Services.Base
{
	public class BaseHttpService
	{
		private readonly IClient _client;
		private readonly ILocalStorage _localStorage;

		public BaseHttpService(IClient client, ILocalStorage localStorage)
        {
			_client = client;
			_localStorage = localStorage;
		}

		public Response<Guid> ConvertApiException<Guid>(ApiException exception)
		{
			if (exception.StatusCode == 40)
			{
				return new Response<Guid> { Message = "Validation errors have accured...", ValidationErrors = exception.Response, Success = false };
			}
			else if (exception.StatusCode == 404)
			{
				return new Response<Guid> { Message = "Not Found ...", Success = false };
			}
			else
			{
				return new Response<Guid> { Message = "something went wrong ...", Success = false };
			}
		}

		protected void AddBearerToken()
		{
			if (_localStorage.Exists("token"))
			{
				_client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _localStorage.Get<string>("token"));
			}
		}

	}
}
