using System.ComponentModel.DataAnnotations;

namespace bnbapp.Models
{
    public class Company
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Razao_Social { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}