using ay.SunriseSunset.Configuration;
using ay.SunriseSunset.Models;

namespace ay.SunriseSunset.Abstractions;

public interface ISunriseSunsetClient : IDisposable
{
    Task<SunriseSunsetData?> Fetch(
        decimal latitude,
        decimal longitude,
        DateOnly date,
        TimeZoneInfo? timeZoneInfo = null,
        CancellationToken cancellationToken = default);

    Task<SunriseSunsetData?> Fetch(SunriseSunsetConfiguration sunriseSunsetConfiguration,
        DateOnly date,
        TimeZoneInfo? timeZoneInfo = null,
        CancellationToken cancellationToken = default);
}
