using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Model
{
#nullable disable

    public class MailgunConfiguration
    {
        [Required]
        public string SmtpServer { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class ConventionsHandicapConfigurationOptions
    {
        [Required]
        public string ConventionsHandicapMail { get; set; }
        [Required]
        public Uri ConventionsHandicapUri { get; set; }
        [Required]
        public string TableStorageConnectionString { get; set; }
        [Required]
        public string SqlServerDbConnectionString { get; set; }
        [Required]
        public MailgunConfiguration MailgunConfiguration { get; set; }
    }

#nullable enable
}
