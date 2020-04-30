using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogGrooming.Models
{
    public class Client
    {
        [Key]
        [Required]
        [Display(Name = "Client Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Human Name")]
        public string Name { get; set; }

        [Display(Name = "Dog Name")]
        public string DogName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Appointment Time")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }


        // empty constructor
        public Client()
        { }


        //public class ClientCart : Cart
        //{
        //    public ClientCart()
        //    { }


        
    }
}