using Calculator.Backend.Data.Converters;
using Calculator.Backend.Data.Enums;
using System.Text.Json.Serialization;

namespace Calculator.Backend.Data.Models.DTO
{
    public class OperationParamsDTO
    {
        public float Param1 { get; set; }
        public float Param2 { get; set; }
        [JsonConverter(typeof(OperationTypeConverter))]
        public OperationType OperationType { get; set; }
    }
}
