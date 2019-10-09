namespace Controller__API.Models
{
    using System.Collections.Generic;

    public interface IRepository
    {
        IEnumerable<Reservation> Reservations { get; }
        Reservation this[int id] { get; }
        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        void DeleteReservation(int id);
    }
}