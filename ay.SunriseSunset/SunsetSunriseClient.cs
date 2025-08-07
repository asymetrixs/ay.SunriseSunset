using System.Net.Http.Json;
using ay.SunriseSunset.Models;
using Microsoft.Extensions.Logging;

namespace ay.SunriseSunset;

public class SunsetSunriseClient : IDisposable
{
    private readonly ILogger<SunsetSunriseClient>? _logger;

    private readonly HttpClient _httpClient = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="SunsetSunriseClient"/> class.
    /// </summary>
    public SunsetSunriseClient()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SunsetSunriseClient"/> class.
    /// </summary>
    /// <param name="logger">Logger</param>
    public SunsetSunriseClient(ILogger<SunsetSunriseClient> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Methods returns data from api.sunrise-sunset.org
    /// </summary>
    /// <param name="latitude">Latitude</param>
    /// <param name="longitude">Longitude</param>
    /// <param name="cancellationToken">Optional: Cancellation Token</param>
    /// <returns></returns>
    public async Task<Root?> Fetch(decimal latitude, decimal longitude, CancellationToken cancellationToken = default)
    {
        var apiEndpointUrl = $"https://api.sunrise-sunset.org/json?lat={latitude}&lng={longitude}&formatted=0";

        try
        {
            return await _httpClient
                .GetFromJsonAsync<Root>(apiEndpointUrl, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception e)
        {
            _logger?.LogError(e, e.Message);
        }

        return null;
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _httpClient.Dispose();
        }
    }
}
