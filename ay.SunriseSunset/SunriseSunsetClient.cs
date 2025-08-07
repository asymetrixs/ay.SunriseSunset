using System.Net.Http.Json;
using ay.SunriseSunset.Abstractions;
using Microsoft.Extensions.Logging;

namespace ay.SunriseSunset;

public class SunriseSunsetClient : ISunriseSunsetClient
{
    private readonly ILogger<SunriseSunsetClient>? _logger;

    private readonly HttpClient _httpClient = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="SunriseSunsetClient"/> class.
    /// </summary>
    public SunriseSunsetClient()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SunriseSunsetClient"/> class.
    /// </summary>
    /// <param name="logger">Logger</param>
    public SunriseSunsetClient(ILogger<SunriseSunsetClient> logger)
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
    public async Task<Models.SunriseSunset?> Fetch(decimal latitude, decimal longitude,
        CancellationToken cancellationToken = default)
    {
        var apiEndpointUrl = $"https://api.sunrise-sunset.org/json?lat={latitude}&lng={longitude}&formatted=0";

        try
        {
            return await _httpClient
                .GetFromJsonAsync<Models.SunriseSunset>(apiEndpointUrl, cancellationToken)
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
