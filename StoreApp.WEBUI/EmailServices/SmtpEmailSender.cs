using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.EmailServices
{
    public class SmtpEmailSender : IEmailService
    {

        //private const string SendGridKey = "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";


        //public Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{

        //    return Execute(SendGridKey, subject, htmlMessage, email);
        //}

        //private Task Execute(string sendGridKey, string subject, string message, string email)
        //{
        //    var client = new SendGridClient(sendGridKey);

        //    var msg = new SendGridMessage()
        //    {
        //        From = new EmailAddress("info@storeapp.com","Store App"),
        //        Subject=subject,
        //        PlainTextContent=message,
        //        HtmlContent=message
        //    };

        //    msg.AddTo(new EmailAddress(email));

        //    return client.SendEmailAsync(msg);
        //}


        private int _port;
        private string _host;
        private string _username;
        private string _password;
        private bool _enableSSL;

        public SmtpEmailSender( string host, int port, string username, string password, bool enableSSL)
        {
            this._port = port;
            this._host = host;
            this._enableSSL = enableSSL;
            this._username = username;
            this._password = password;
        }



        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(this._host, this._port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = _enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(this._username, email, subject, htmlMessage)
                {
                    IsBodyHtml = true
                });

        }

    }
}

