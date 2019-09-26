using System.Collections.Generic;

namespace PartyInvates.Models
{
    public class Repositoty
    {
        private static readonly List<GuestResponse> responses = new List<GuestResponse>();

        public static IEnumerable<GuestResponse> Responses => responses;

        public static void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}