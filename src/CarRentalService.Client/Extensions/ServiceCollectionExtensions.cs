using CarRentalService.Client;
using CarRentalService.Client.Settings;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IHttpClientBuilder AddCarRentalApiClient(this IServiceCollection services, Action<CarRentalApiClientSettings> configuration)
    {
        var settings = new CarRentalApiClientSettings();
        configuration.Invoke(settings);

        var builder = services.AddHttpClient<ICarRentalApiClient, CarRentalApiClient>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(settings.BaseAddress);
            return new CarRentalApiClient(httpClient);
        });

        return builder;
    }
}