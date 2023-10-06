using MediatR;
using System.Net;
using System.Net.Mail;
using TaskManager.Services.Core;

namespace TaskManager.Services.Business
{
    public class SendEmailQueryHandler : IRequestHandler<SendEmailQuery>
    {

        public SendEmailQueryHandler()
        {

        }
        public async Task Handle(SendEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var fromAddress = new MailAddress("no-reply@task-express.com", "Task Express");
                var toAddress = new MailAddress("saleem.alnashawaty@gmail.com", "Saleem Nashawaty");
                const string fromPassword = "dzzbyqnztsyajwvz";
                string subject = "New Task";
                string body = $"New Task Id: {request.Message}";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    await smtp.SendMailAsync(message);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("On sending Email Exception: " + ex.Message);
            }
        }
    }
}
