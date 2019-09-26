namespace PartyInvates.Models
{
    public class GuestResponse
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public bool? WillAttend { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Name)}: {Name}, {nameof(Email)}: {Email}, {nameof(Phone)}: {Phone}, {nameof(WillAttend)}: {WillAttend}";
        }
    }
}