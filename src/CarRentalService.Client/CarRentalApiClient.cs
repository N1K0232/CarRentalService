using System.Net.Http.Json;
using CarRentalApi.Shared.Common;
using CarRentalApi.Shared.Models;

namespace CarRentalService.Client;

public class CarRentalApiClient : ICarRentalApiClient
{
    private HttpClient httpClient;

    public CarRentalApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    public Task<ListResult<Person>> GetPeopleAsync(int pageIndex = 0, int itemsPerPage = 10)
    {
        var resource = $"/api/v1/People/{pageIndex}/{itemsPerPage}";
        return GetAsync<ListResult<Person>>(resource);
    }

    public Task<ListResult<Vehicle>> GetVehiclesAsync(int pageIndex = 0, int itemsPerPage = 10)
    {
        var resource = $"/api/v1/Vehicles/{pageIndex}/{itemsPerPage}";
        return GetAsync<ListResult<Vehicle>>(resource);
    }

    public Task<ListResult<Reservation>> GetReservationsAsync(int pageIndex = 0, int itemsPerPage = 10)
    {
        var resource = $"/api/v1/Reservations/{pageIndex}/{itemsPerPage}";
        return GetAsync<ListResult<Reservation>>(resource);
    }

    private Task<T> GetAsync<T>(string resource) => httpClient.GetFromJsonAsync<T>(resource);


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