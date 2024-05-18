using MP_Management.MVC.Services.Client.Interfaces;

namespace MP_Management.MVC.Services.Client.Impeliments
{
	public partial class Client: IClient
	{
        public HttpClient HttpClient {
			get
			{
				return _httpClient;
			}
		}
    }
}
