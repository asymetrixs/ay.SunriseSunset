# ay.SunriseSunset

This project implements the JSON endpoint at [https://api.sunrise-sunset.org/](https://api.sunrise-sunset.org/).

## Integration

Usage:

```csharp
// Optionally pass ILogger<SunriseSunsetClient> for exmaple via dependency injection
var sunriseSunsetClient = new SunriseSunsetClient();

// Optionally pass a Cancellation Token
var result = await sunriseSunsetClient.Fetch(51.4347790, 13.410530);

// Don't forget to dispose
sunriseSunsetClient.Dispose();
```
