using System.ComponentModel.DataAnnotations;

namespace CPWeCommerceSite.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Username { get; set; }
    }
}
