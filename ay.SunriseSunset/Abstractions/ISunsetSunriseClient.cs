namespace ay.SunriseSunset.Abstractions;

public interface ISunsetSunriseClient : IDisposable
{
    Task<Models.SunriseSunset?> Fetch(decimal latitude, decimal longitude,
        CancellationToken cancellationToken = default);
}
