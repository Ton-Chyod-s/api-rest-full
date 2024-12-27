using System.Net;
using System.Net.Mail;
using DiarioOficial.CrossCutting.DTOs.SendEmail;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Common;
using DiarioOficial.Domain.Interface.Services.SendEmail;
using OneOf;

namespace DiarioOficial.Infraestructure.Services.SendEmail
{
    public class SendEmailService : ISendEmailService
    {
        public async Task<OneOf<bool, BaseError>> SendAsyncEmail(RequestSendEmailDTO requestSendEmailDTO)
        {
            try
            {
                // Configuração do cliente SMTP
                SmtpClient smtpClient = new SmtpClient("smtp.seuprovedor.com")
                {
                    Port = 587, // Porta do servidor SMTP
                    Credentials = new NetworkCredential("seuemail@exemplo.com", "suasenha"),
                    EnableSsl = true // Habilitar SSL
                };

                // Configuração do e-mail
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("seuemail@exemplo.com"),
                    Subject = requestSendEmailDTO.Subject,
                    Body = "Corpo do e-mail (pode ser texto ou HTML)",
                    IsBodyHtml = true // Altere para 'true' se o corpo for HTML
                };

                // Adicionando destinatários
                mail.To.Add("destinatario@exemplo.com");

                // Enviar e-mail
                await smtpClient.SendMailAsync(mail);

                Console.WriteLine("E-mail enviado com sucesso!");

                return true;
            }
            catch (Exception)
            {
                return new DatabaseError();
            }
        }
    }
}
