namespace Calculator.Backend.Data.Models.Entities
{
    public class History
    {
        public Guid Id { get; set; }
        public double Param1 { get; set; }
        public double Param2 { get; set; }
        public double Result { get; set; }

        public Guid OperationId { get; set; }
        public Operation Operation { get; set; }
    }
}
