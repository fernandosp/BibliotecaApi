using System;

namespace Library.Domain
{
    public class Reserve : Entity
    {
        public User User { get; set; }
        public Book Book { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReservationToDate { get; set; }
        public DateTime ReturnPrevision { get; set; }
        public bool IsActive { get; set; }
    }
}
