namespace Calculator.Backend.Data.Models.DTO
{
    public class HistoryDTO
    {
        public float Param1 { get; set; }
        public float Param2 { get; set; }
        public float Result { get; set; }
        public required string OperationName { get; set; }
    }
}
