using System.Net.Http.Json;
using CarRentalApi.Shared.Common;
using CarRentalApi.Shared.Models;

namespace CarRentalService.Client;

public class CarRentalApiClient : ICarRentalApiClient
{
    private HttpClient httpClient = null;
    private CancellationTokenSource cancellationTokenSource = null;

    public CarRentalApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    private CancellationToken CancellationToken
    {
        get
        {
            cancellationTokenSource ??= new CancellationTokenSource();
            return cancellationTokenSource.Token;
        }
    }

    public async Task<ListResult<Person>> GetPeopleAsync(int pageIndex, int itemsPerPage)
    {
        var resource = $"/api/v1/People/{pageIndex}/{itemsPerPage}";

        try
        {
            var people = await httpClient.GetFromJsonAsync<ListResult<Person>>(resource, CancellationToken);
            return people;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<ListResult<Vehicle>> GetVehiclesAsync(int pageIndex, int itemsPerPage)
    {
        var resource = $"/api/v1/Vehicles/{pageIndex}/{itemsPerPage}";

        try
        {
            var vehicles = await httpClient.GetFromJsonAsync<ListResult<Vehicle>>(resource, CancellationToken);
            return vehicles;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<ListResult<Reservation>> GetReservationsAsync(int pageIndex, int itemsPerPage)
    {
        var resource = $"/api/v1/Reservations/{pageIndex}/{itemsPerPage}";

        try
        {
            var reservations = await httpClient.GetFromJsonAsync<ListResult<Reservation>>(resource, CancellationToken);
            return reservations;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Image>> GetImagesAsync()
    {
        var resource = $"/api/v1/Images";

        try
        {
            var images = await httpClient.GetFromJsonAsync<IEnumerable<Image>>(resource, CancellationToken);
            return images;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            httpClient.Dispose();
            httpClient = null;
        }
    }
}