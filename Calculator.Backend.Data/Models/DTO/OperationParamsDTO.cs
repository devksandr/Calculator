using Calculator.Backend.Data.Converters;
using Calculator.Backend.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Calculator.Backend.Data.Models.DTO
{
    public class OperationParamsDTO
    {
        public double Param1 { get; set; }
        public double Param2 { get; set; }
        [JsonConverter(typeof(OperationTypeConverter))]
        public OperationType OperationType { get; set; }
    }
}
