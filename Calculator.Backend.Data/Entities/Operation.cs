namespace Calculator.Backend.Data.Entities
{
    public class Operation
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
