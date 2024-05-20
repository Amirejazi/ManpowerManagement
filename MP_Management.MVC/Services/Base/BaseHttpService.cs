﻿using Hanssens.Net;
using MP_Management.MVC.Services.Client.Impeliments;
using MP_Management.MVC.Services.Client.Interfaces;
using System.Net.Http.Headers;

namespace MP_Management.MVC.Services.Base
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

		protected Response<Guid> ConvertApiException<Guid>(ApiException exception)
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
