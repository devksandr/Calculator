using Calculator.Backend.Data.Converters;
using Calculator.Backend.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Calculator.Backend.Data.Models.DTO
{
    public class OperationParamsDTO
    {
        private const int NUMBER_LIMIT = 1_000_000_000;

        [Range(-NUMBER_LIMIT, NUMBER_LIMIT)]
        public double Param1 { get; set; }
        [Range(-NUMBER_LIMIT, NUMBER_LIMIT)]
        public double Param2 { get; set; }
        [JsonConverter(typeof(OperationTypeConverter))]
        public OperationType OperationType { get; set; }
    }
}
