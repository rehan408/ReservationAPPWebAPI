namespace ReservationAPI.Models
{
    public class ReservationData
    {
        public int Id { get; set; } // Primary key
        public DateTime arrivalDate { get; set; }
        public DateTime departureDate { get; set; }
        public string roomSize { get; set; }
        public int roomQuantity { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string zipCode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string extras { get; set; }
        public string payment { get; set; }
        public string note { get; set; }
        public string tags { get; set; }
        public bool reminder { get; set; }
        public bool newsletter { get; set; }
        public bool confirm { get; set; }
    }
}
