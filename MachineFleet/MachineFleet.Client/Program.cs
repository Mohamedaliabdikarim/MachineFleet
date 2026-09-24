using MachineFleet.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace MachineFleet.Client;

internal class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        // Add to DI
        builder.Services.AddScoped<IMachineService, InMemoryMachineService>();

        await builder.Build().RunAsync();
    }
}