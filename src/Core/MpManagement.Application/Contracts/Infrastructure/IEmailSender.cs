using MpManagement.Application.Models;

namespace MpManagement.Application.Contracts.Infrastructure
{
	public interface IEmailSender
	{
		Task<bool> SendEmail(Email email);
	}
}
