using MpManagement.Web.Services.Client.Interfaces;

namespace MpManagement.Web.Services.Client.Impeliments
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
