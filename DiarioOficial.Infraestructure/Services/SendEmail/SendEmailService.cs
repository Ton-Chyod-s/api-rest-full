using System.Net;
using System.Net.Mail;
using DiarioOficial.CrossCutting.DTOs.SendEmail;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.Services.SendEmail;
using DotNetEnv;
using Newtonsoft.Json.Linq;
using OneOf;

namespace DiarioOficial.Infraestructure.Services.SendEmail
{
    public class SendEmailService : ISendEmailService
    {
        public async Task<OneOf<bool, BaseError>> SendAsyncEmail(RequestSendEmailDTO requestSendEmailDTO)
        {
            var envValue = EnvValue();

            var smtpClient = CreateSmtpClient(envValue["SMTP_SERVER"]!.ToString(), int.Parse(envValue["SMTP_PORT"]!.ToString()), envValue["EMAIL"]!.ToString(), envValue["EMAIL_PASSWORD"]!.ToString());
           
            var mailMessage = CreateMailMessage(envValue["EMAIL"]!.ToString(), requestSendEmailDTO.Subject, requestSendEmailDTO.Body);

            mailMessage.To.Add(requestSendEmailDTO.From);

            await smtpClient.SendMailAsync(mailMessage);

            return true;
        }

        internal JObject EnvValue()
        {
            string basePath = "C:\\Users\\Klay\\OneDrive\\Documentos\\GitHub Ton-Chyod-S\\api-rest-full\\config\\.env";

            var lol = Env.Load(basePath);

            var smtpServer = Env.GetString("SMTP_SERVER");
            var smtpPort = Env.GetString("SMTP_PORT");
            var email = Env.GetString("EMAIL");
            var emailPassword = Env.GetString("EMAIL_PASSWORD");

            return new JObject {
                { "SMTP_SERVER", smtpServer },
                { "SMTP_PORT", int.Parse(smtpPort) },
                { "EMAIL", email },
                { "EMAIL_PASSWORD", emailPassword }
            };
        }

        internal SmtpClient CreateSmtpClient(string smtpServer, int smtpPort, string email, string password)
        {
            return new SmtpClient(smtpServer)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true // Habilitar SSL 465 para SSL
            };
        }

        internal MailMessage CreateMailMessage(string email, string subject, string body)
        {
            return new MailMessage
            {
                From = new MailAddress(email),
                Subject = subject,
                Body = body,
                IsBodyHtml = true // Altere para 'true' se o corpo for HTML
            };
        }

    }
}
