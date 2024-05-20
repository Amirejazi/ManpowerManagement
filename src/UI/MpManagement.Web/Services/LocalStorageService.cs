using Hanssens.Net;
using MpManagement.Web.Contracts;

namespace MpManagement.Web.Services
{
	public class LocalStorageService : ILocalStorageService
	{
		private LocalStorage _localStorage;

		public LocalStorageService()
		{
			var config = new LocalStorageConfiguration
			{
				AutoLoad = true,
				AutoSave = true,
				Filename = "MP_MNGM"
			};
			_localStorage = new LocalStorage(config);
		}
		public void ClearLocalStorage(List<string> keys)
		{
            foreach (var key in keys)
            {
				_localStorage.Remove(key);
            }
        }

		public bool Exist(string key)
		{
			return _localStorage.Exists(key);
		}

		public T GetStorageValue<T>(string key)
		{
			return _localStorage.Get<T>(key);
		}

		public void SetStorageValue<T>(string key, T value)
		{
			_localStorage.Store(key, value);
			// از اهمیت زیادی برخوردار است و مرتب سازی را انجام میدهد Persist()
			_localStorage.Persist();
		}
	}
}
