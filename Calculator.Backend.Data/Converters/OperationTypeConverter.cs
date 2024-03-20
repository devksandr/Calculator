using Calculator.Backend.Data.Enums;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Calculator.Backend.Data.Converters
{
    public class OperationTypeConverter : JsonConverter<OperationType>
    {
        public override OperationType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                return OperationType.Undefined;
            }

            var operationTypeValue = reader.GetString();
            if (operationTypeValue == null)
            {
                return OperationType.Undefined;
            }

            OperationType operationType;
            if (!Enum.TryParse(operationTypeValue.ToString(), ignoreCase: true, out operationType))
            {
                return OperationType.Undefined;
            }

            return operationType;
        }

        public override void Write(Utf8JsonWriter writer, OperationType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
