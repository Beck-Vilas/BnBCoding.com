using System.ComponentModel.DataAnnotations;


namespace bnbapp.Models
{
    public class Alibaba
    {
        [Required]
        public int Id { get; set; }

        public string sender { get; set; }
        public string message { get; set; }
        public string dateTime { get; set; }

    }
}