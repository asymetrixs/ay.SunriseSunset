using System.Net.Http.Json;
using ay.SunriseSunset.Abstractions;
using ay.SunriseSunset.Configuration;
using ay.SunriseSunset.Models;
using Microsoft.Extensions.Logging;

namespace ay.SunriseSunset;

public class SunriseSunsetClient : ISunriseSunsetClient
{
    private readonly ILogger<SunriseSunsetClient>? _logger;

    private readonly HttpClient _httpClient = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="SunriseSunsetClient"/> class.
    /// </summary>
    /// <param name="logger">Logger</param>
    public SunriseSunsetClient(ILogger<SunriseSunsetClient>? logger = null)
    {
        _logger = logger;
    }

    /// <summary>
    /// Methods returns data from api.sunrise-sunset.org
    /// </summary>
    /// <param name="latitude">Latitude</param>
    /// <param name="longitude">Longitude</param>
    /// <param name="date">Date</param>
    /// <param name="cancellationToken">Optional: Cancellation Token</param>
    /// <returns></returns>
    public Task<SunriseSunsetData?> Fetch(decimal latitude,
        decimal longitude,
        DateOnly date,
        CancellationToken cancellationToken = default)
    {
        return Fetch(new SunriseSunsetConfiguration
        {
            Latitude = latitude,
            Longitude = longitude,
        }, date, cancellationToken);
    }

    /// <summary>
    /// Methods returns data from api.sunrise-sunset.org
    /// </summary>
    /// <param name="configuration">Configuration</param>
    /// <param name="date">Date</param>
    /// <param name="cancellationToken">Optional: Cancellation Token</param>
    /// <returns></returns>
    public async Task<SunriseSunsetData?> Fetch(SunriseSunsetConfiguration configuration,
        DateOnly date,
        CancellationToken cancellationToken = default)
    {
        var apiEndpointUrl = $"https://api.sunrise-sunset.org/json" +
                             $"?lat={configuration.Latitude}" +
                             $"&lng={configuration.Longitude}" +
                             $"&date={date.ToString("yyyy-MM-dd")}" +
                             $"&formatted=0";

        try
        {
            return await _httpClient
                .GetFromJsonAsync<SunriseSunsetData>(apiEndpointUrl, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception e)
        {
            _logger?.LogError(e, "{Message}", e.Message);
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
