using System.ComponentModel.DataAnnotations;

namespace bnbapp.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        public string Year { get; set; }

    }
}