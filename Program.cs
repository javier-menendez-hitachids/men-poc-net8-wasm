using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MenulioPocWasm;
using Contentful.Core.Configuration;
using Contentful.Core;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add Contentful client
builder.Services.AddScoped<IContentfulClient>(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    var options = new ContentfulOptions
    {
        DeliveryApiKey = "0HeeMkqQH9tkxxq6LtRuGyvXwAKKWHgMlM0pMWv5NzA",
        SpaceId = "j3vmcasldixe",
        PreviewApiKey = "zZeHGwlP9Xe2wckGwYzoei7a89X5kJdB0yKLi-qLLZo", // Optional
        Environment = "master" // Optional, defaults to "master"
    };
    return new ContentfulClient(httpClient, options);
});

await builder.Build().RunAsync();
