using System;

namespace ConventionsHandicap.App.Controllers.Dto
{
    public class UserDto
    {
        public UserDto(Guid id, string email, bool mailConfirmed)
        {
            Id = id;
            Email = email;
            MailConfirmed = mailConfirmed;
        }

        public Guid Id { get; set; }

        public string Email { get; set; }

        public bool MailConfirmed { get; set; }
    }
}