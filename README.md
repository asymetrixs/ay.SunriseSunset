# ay.SunriseSunset

This project implements the JSON endpoint at [https://api.sunrise-sunset.org/](https://api.sunrise-sunset.org/).

## Integration

Usage:

```csharp
// Optionally pass ILogger<SunriseSunsetClient> for exmaple via dependency injection
var sunriseSunsetClient = new SunriseSunsetClient();
var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin");
var date = DateOnly.FromDateTime(DateTime.Now.Date); 

// Optionally pass a Cancellation Token
var result = await sunriseSunsetClient.Fetch(
    51.4347790,
    13.410530,
    date,
    timeZoneInfo);

// Don't forget to dispose
sunriseSunsetClient.Dispose();
```

## Service Provider

Register:

```csharp
// configuration is IConfigurationRoot
services.SunriseSunsetSetup(configuration);

```

Retrieve (or as parameter in another service's constructor):

```csharp
var sunriseSunsetClient = serviceProvider.GetService<ISunriseSunsetClient>();
```

Configure in appsettings.json or similar as follows:
```json lines
{
  "SunriseSunset":
  {
    "Latitude": 51.4347790,
    "Longitude": 13.410530    
  }
}
```
