using System.Text.Json.Serialization;

namespace ay.SunriseSunset.Models;

public record Root
{
    [JsonPropertyName("results")]
    public required Results Results { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("tzid")]
    public required string Tzid { get; set; }
}
