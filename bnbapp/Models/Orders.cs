using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace bnbapp.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ProjName { get; set; }


        [Required]
        public string Start { get; set; }
        [Required]
        public string End { get; set; }
        [Required]
        public string ProjDesc { get; set; }

        public string Website { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public int Completion { get; set; }
        [Required]
        public string Payment { get; set; }
        [Required]
        public int TotalPayed { get; set; }
        [Required]
        public int TotalDue { get; set; }
        [Required]
        public int Total { get; set; }


    }
}