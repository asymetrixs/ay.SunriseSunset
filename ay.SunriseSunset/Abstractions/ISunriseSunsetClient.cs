namespace ay.SunriseSunset.Abstractions;

public interface ISunriseSunsetClient : IDisposable
{
    Task<Models.SunriseSunset?> Fetch(decimal latitude, decimal longitude,
        CancellationToken cancellationToken = default);
}
