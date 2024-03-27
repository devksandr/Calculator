namespace Calculator.Backend.Data.Models.DTO
{
    public class HistoryDTO
    {
        public double Param1 { get; set; }
        public double Param2 { get; set; }
        public double Result { get; set; }
        public required string OperationName { get; set; }
    }
}
