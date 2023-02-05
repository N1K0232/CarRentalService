using CarRentalApi.Shared.Common;
using CarRentalApi.Shared.Models;

namespace CarRentalService.Client;

public interface ICarRentalApiClient : IDisposable
{
    Task<ListResult<Person>> GetPeopleAsync(int pageIndex, int itemsPerPage);

    Task<ListResult<Vehicle>> GetVehiclesAsync(int pageIndex, int itemsPerPage);

    Task<ListResult<Reservation>> GetReservationsAsync(int pageIndex, int itemsPerPage);

    Task<IEnumerable<Image>> GetImagesAsync();
}