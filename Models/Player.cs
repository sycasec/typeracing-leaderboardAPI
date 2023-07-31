namespace typeRacingAPI.Models {
    public class Player {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required float Score { get; set; }
        public required float Accuracy { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
