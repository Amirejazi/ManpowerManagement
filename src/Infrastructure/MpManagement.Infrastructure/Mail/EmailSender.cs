﻿using Microsoft.Extensions.Options;
using MpManagement.Application.Contracts.Infrastructure;
using MpManagement.Application.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace MpManagement.Infrastructure.Mail
{
	public class EmailSender : IEmailSender
	{
		private readonly EmailSetting _emailSettings;

		public EmailSender(IOptions<EmailSetting> emailSettings)
        {
			_emailSettings = emailSettings.Value;
		}
        public async Task<bool> SendEmail(Email email)
		{
			var client = new SendGridClient(_emailSettings.ApiKey);
			var to = new EmailAddress(email.To);
			var from = new EmailAddress
			{
				Email = _emailSettings.FromAddress,
				Name = _emailSettings.FromName
			};
			var message = MailHelper.CreateSingleEmail(to, from, email.Subject, email.Body, email.Body);
			var response = await client.SendEmailAsync(message);
			return response.StatusCode == HttpStatusCode.OK ||
				response.StatusCode == HttpStatusCode.Accepted;

		}
	}
}
