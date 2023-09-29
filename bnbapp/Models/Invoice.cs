using System.ComponentModel.DataAnnotations;

namespace bnbapp.Models
{
    public class Invoice
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string BillingId { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string Date { get; set; }
        public string OrderId { get; set; }


    }
}