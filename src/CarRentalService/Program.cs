var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddCarRentalApiClient(options =>
{
    options.BaseAddress = builder.Configuration.GetValue<string>("AppSettings:BaseAddress");
});

var app = builder.Build();
app.UseExceptionHandler("/Error");
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();