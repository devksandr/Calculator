using Calculator.Backend.Data.Enums;

namespace Calculator.Backend.Data.Models.ServiceModels.History
{
    public class AddHistoryServiceModel
    {
        public double Param1 { get; set; }
        public double Param2 { get; set; }
        public double Result { get; set; }
        public OperationType OperationType { get; set; }
    }
}
