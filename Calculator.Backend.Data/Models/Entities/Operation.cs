namespace Calculator.Backend.Data.Models.Entities
{
    public class Operation
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Alias { get; set; }
        public required string Sign { get; set; }
    }
}
