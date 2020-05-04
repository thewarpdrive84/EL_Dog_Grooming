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

        [Required(ErrorMessage = "The Name field is required")]
        [Display(Name = "Human Name")]
        public string Name { get; set; }

        [Display(Name = "Dog Name")]
        public string DogName { get; set; }

        [Display(Name = "Phone")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The Email field is required")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Date field is required")]
        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Time field is required")]
        [Display(Name = "Appointment Time")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        // constructor
        public Client(int _id, string _name, string _dogname, string _phone, string _email, DateTime _date, DateTime _time)
        {
            Id = _id;
            Name = _name;
            DogName = _dogname;
            Phone = _phone;
            Email = _email;
            Date = _date;
            Time = _time;
        }


        // empty client constructor
        public Client()
        { }
        
    }
}