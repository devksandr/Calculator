namespace Calculator.Backend.Data.Models.Entities
{
    public class History
    {
        public Guid Id { get; set; }
        public float Param1 { get; set; }
        public float Param2 { get; set; }
        public float Result { get; set; }

        public Guid OperationId { get; set; }
        public Operation Operation { get; set; }
    }
}
