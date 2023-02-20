using KLA2023_DevDay;
using KLA2023_DevDay.GameLogic;
using KLA2023_DevDay.GameLogic.GameObjects;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace KLA2023_DevDay
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            Platform[] platforms = new Platform[]
            {
                new(50, 10, 0, WorldSettings.FLOOR),
                new(50, 10, 100, WorldSettings.FLOOR -50),
                new(50, 10, 200, WorldSettings.FLOOR - 25),
                new(50, 10, 300, WorldSettings.FLOOR),
                new(50, 10, 400, WorldSettings.FLOOR + 25),
                new(50, 10, 500, WorldSettings.FLOOR + 50),
            };
            Player player = new(16, 16, 0, WorldSettings.FLOOR, platforms);
            GameObject[] allGameObjects = new GameObject[]
            {
                player
            };
            allGameObjects = allGameObjects.Concat(platforms).ToArray();
            builder.Services.AddSingleton<IWorld, World>(x => new World(allGameObjects));
            builder.Services.AddSingleton<IControls, Controls>(x => new Controls(player));
            builder.Services.AddSingleton<IGraphics, Graphics>(x => new Graphics(player));

            await builder.Build().RunAsync();
        }
    }
}