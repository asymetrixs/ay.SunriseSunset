using ay.SunriseSunset.Models;

namespace ay.SunriseSunset.Abstractions;

public interface ISunsetSunriseClient : IDisposable
{
    Task<Root?> Fetch(decimal latitude, decimal longitude, CancellationToken cancellationToken = default);
}
