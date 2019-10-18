using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidation.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc;

    using ModelValidation.Infrastructure;

    public class Appointment
    {
        [Required]
        [Display(Name = "Имя клиента")]
        public string ClientName { get; set; }

        [UIHint("Date")]
        [Required(ErrorMessage = "Введите дату")]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        [MustBeTrue(ErrorMessage = "Вы должны принять условия соглашения")]
        // [Range(typeof(bool), "true", "true", ErrorMessage = "Вы должны принять условия")]
        public bool TermsAccepted { get; set; }
    }
}