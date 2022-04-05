using Microsoft.AspNetCore.SignalR.Client;
using WanderLost.Shared.Interfaces;
using HubClientSourceGenerator;

namespace WanderLost.Client.Services
{
    [AutoHubClient(typeof(IMerchantHubClient))]
    [AutoHubServer(typeof(IMerchantHubServer))]
    public partial class MerchantHubClient : IAsyncDisposable
    {
        public HubConnection HubConnection {get; init; }

        public MerchantHubClient(IConfiguration configuration)
        {
            HubConnection = new HubConnectionBuilder()
                .WithUrl(configuration["SocketEndpoint"])
                .WithAutomaticReconnect(new[] {
                    TimeSpan.FromSeconds(10),
                    TimeSpan.FromSeconds(30),
                    TimeSpan.FromMinutes(1), 
                    TimeSpan.FromMinutes(5),
                    TimeSpan.FromMinutes(5),
                })
                .Build();
            HubConnection.ServerTimeout = TimeSpan.FromMinutes(2);
            HubConnection.KeepAliveInterval = TimeSpan.FromMinutes(1);
        }

        public async ValueTask DisposeAsync()
        {
            if(HubConnection is not null)
            {
                await HubConnection.DisposeAsync();
            }
            GC.SuppressFinalize(this);
        }
    }
}
