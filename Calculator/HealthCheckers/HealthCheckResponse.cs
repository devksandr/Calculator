using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text;

namespace Calculator.Backend.HealthCheckers
{
    public static class HealthCheckResponse
    {
        public static Task WriteResponse(HttpContext context, HealthReport healthReport)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions { Indented = true };

            using var memoryStream = new MemoryStream();
            using (var jsonWriter = new Utf8JsonWriter(memoryStream, options))
            {
                jsonWriter.WriteStartObject();

                foreach (var healthReportEntry in healthReport.Entries)
                {
                    bool entryStatus = healthReportEntry.Value.Status == HealthStatus.Unhealthy ? false : true;
                    jsonWriter.WriteString(healthReportEntry.Key, entryStatus.ToString());
                }

                jsonWriter.WriteEndObject();
            }

            return context.Response.WriteAsync(
                Encoding.UTF8.GetString(memoryStream.ToArray()));
        }
    }
}
