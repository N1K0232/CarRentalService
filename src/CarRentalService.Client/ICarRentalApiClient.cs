using CarRentalApi.Shared.Common;
using CarRentalApi.Shared.Models;

namespace CarRentalService.Client;

public interface ICarRentalApiClient : IDisposable
{
    Task<ListResult<Person>> GetPeopleAsync(int pageIndex = 0, int itemsPerPage = 10);

    Task<ListResult<Vehicle>> GetVehiclesAsync(int pageIndex = 0, int itemsPerPage = 10);

    Task<ListResult<Reservation>> GetReservationsAsync(int pageIndex = 0, int itemsPerPage = 10);
}