namespace typeRacingAPI.Models {
    public class Player {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required float Score { get; set; }
        public required float Accuracy { get; set; }
        public required DateTime Timestamp { get; set; }
    }
}
