﻿using ConventionsHandicap.EntityFramework;
using ConventionsHandicap.Model;
using ConventionsHandicap.Shared;
using MimeKit;
using System;

namespace ConventionsHandicap.App.Shared
{
    public class ConventionsHandicapMailMessage
    {
        public bool IsMailToConventionsHandicap { get; }
        public MailboxAddress To { get; }
        public string Subject { get; }
        public string Content { get; }
      

        public ConventionsHandicapMailMessage(string to, string subject, string content)
        {
            To = new MailboxAddress(to, to);
            Subject = subject;
            Content = content;
        }
    }
}
