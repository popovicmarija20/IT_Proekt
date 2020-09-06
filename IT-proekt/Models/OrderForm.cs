using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_proekt.Models
{
    public class OrderForm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Must enter valid name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Must enter valid surname")]
        public string Surname { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Must enter valid address")]
        public string Address { get; set; }




        [Required]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Must contain 5 numbers")]
        public string CardNumber { get; set; }
        [Required]
        [RegularExpression("^[0-9][0-9]/[0-9][0-9]$", ErrorMessage = "Date must be in format 00/00")]
        public string Expiration { get; set; }
        [Required]

        [RegularExpression("^[0-9]{3}$", ErrorMessage = "Must contain 3 numbers")]

        public string Cvc { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Must contain letters")]

        public string CardOwner { get; set; }

    }
}