using CarRentalApi.Shared.Common;
using CarRentalApi.Shared.Models;
using CarRentalService.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalService.Pages;

public class IndexModel : PageModel
{
    private readonly ICarRentalApiClient carRentalApiClient;

    public IndexModel(ICarRentalApiClient carRentalApiClient)
    {
        this.carRentalApiClient = carRentalApiClient;
    }

    public ListResult<Person> People { get; set; }


    public async Task<IActionResult> OnGetAsync(int pageIndex = 0, int itemsPerPage = 10)
    {
        People = await carRentalApiClient.GetPeopleAsync(pageIndex, itemsPerPage);
        return People != null ? Page() : Redirect("/Error");
    }
}