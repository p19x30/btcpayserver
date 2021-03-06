﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BTCPayServer.Services.Mails
{
    public class EmailSettings
    {
        [Required]
        public string Server
        {
            get; set;
        }

        [Required]
        public int? Port
        {
            get; set;
        }

        [Required]
        public String Login
        {
            get; set;
        }

        [Required]
        public String Password
        {
            get; set;
        }

        [EmailAddress]
        public string From
        {
            get; set;
        }

        public bool EnableSSL
        {
            get; set;
        }

        public SmtpClient CreateSmtpClient()
        {
            SmtpClient client = new SmtpClient(Server, Port.Value);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(Login, Password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Timeout = 10000;
            return client;
        }
    }
}
