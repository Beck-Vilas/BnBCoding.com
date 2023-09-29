using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace bnbapp.Models
{
    public class Email
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        
        public string Subject { get; set; }

        public string Body { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string IsAttachment { get; set; }
    }
}
