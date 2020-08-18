using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_proekt.Models
{
    public class PizzaService
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual List<Pizza> pizzas { get; set; }

        public PizzaService()
        {
            pizzas = new List<Pizza>();
        }

    }
}