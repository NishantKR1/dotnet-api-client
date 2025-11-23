using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApiClientReference.Service;
using ApiClientReference.Interfaces;
using ApiClientReference.Models;


var builder = Host.CreateDefaultBuilder(args)
.ConfigureServices(services =>
{
    services.AddHttpClient<IApiClient, ApiClient>();
});


var host = builder.Build();


var api = host.Services.GetRequiredService<IApiClient>();


var result = await api.GetAsync<UserDto>("https://jsonplaceholder.typicode.com/users/1");


if (!result.IsSuccess)
{
    Console.WriteLine($"Error: {result.Error.StatusCode} - {result.Error.Message}");
    Console.WriteLine(result.Error.RawResponse);
}
else
{
    Console.WriteLine($"User: {result.Data.Name}");
}