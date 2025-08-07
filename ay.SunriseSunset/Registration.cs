using ay.SunriseSunset.Abstractions;
using ay.SunriseSunset.Configuration;
using ay.SunriseSunset.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ay.SunriseSunset;

public static class Registration
{
    public static IServiceCollection AddSunriseSunset(this IServiceCollection services,
        IConfiguration configuration)
    {
        var config = configuration.GetSection("SunriseSunset").Get<SunriseSunsetConfiguration>()
                     ?? throw new ArgumentException("Missing configuration section 'SunriseSunset'");

        return services.AddSingleton<ISunriseSunsetClient, SunriseSunsetClient>()
            .AddSingleton(config);
    }
}
