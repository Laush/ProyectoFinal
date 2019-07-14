using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericas
{
    public class EmailService
    {
        private string emailRemitente = "unlam.friendstrip@gmail.com";
        private string nombreRemitente = "Equipo de FriendsTrip";
        private string passwordRemitente = "unlam2019";
         public void enviarMensaje(string emailDestinatario, string nombreDestinatario, string asunto, string cuerpoMensaje)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(nombreRemitente, emailRemitente));
            message.To.Add(new MailboxAddress(nombreDestinatario, emailDestinatario));
            message.Subject = asunto;

            message.Body = new TextPart("plain")
            {
                Text = cuerpoMensaje

            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(emailRemitente, passwordRemitente);

                client.Send(message);
                client.Disconnect(true);
            }
        }
        
    }
}
