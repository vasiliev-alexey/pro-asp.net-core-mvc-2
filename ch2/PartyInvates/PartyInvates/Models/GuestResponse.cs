using System.ComponentModel.DataAnnotations;

namespace PartyInvates.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Введите ваше имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свое имя")]
      //  [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage = "Пожалуйста, введите свой адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите свой номер телефона")]

        public string Phone { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите, примете ли участие")]
        public bool? WillAttend { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Name)}: {Name}, {nameof(Email)}: {Email}, {nameof(Phone)}: {Phone}, {nameof(WillAttend)}: {WillAttend}";
        }
    }
}