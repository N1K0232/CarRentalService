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


    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            People = await carRentalApiClient.GetPeopleAsync();
            return Page();
        }
        catch (HttpRequestException)
        {
            People = null;
            return Redirect("/Error");
        }
    }
}