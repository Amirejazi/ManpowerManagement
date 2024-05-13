using MP_Management.Application.Models;

namespace MP_Management.Application.Contracts.Infrastructure
{
	public interface IEmailSender
	{
		Task<bool> SendEmail(Email email);
	}
}
