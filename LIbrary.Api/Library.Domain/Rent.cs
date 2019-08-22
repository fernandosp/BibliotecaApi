using System;

namespace Library.Domain
{
    public sealed class Rent : Entity
    {
        public User User { get; set; }
        public Book Book { get; set; }
        public Reserve Reserve { get; set; }
        public int IdBook { get; set; }
        public int idReserve { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Pendency { get; set; }
        public string ObservationOfUser { get; set; }
        public decimal TotalRentValue { get; set; }
    }
}