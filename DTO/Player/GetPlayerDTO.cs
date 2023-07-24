namespace typeRacingAPI.DTO.Player {
    public class GetPlayerDTO {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required float Score { get; set; }
        public required float Accuracy { get; set; }
    }
}
