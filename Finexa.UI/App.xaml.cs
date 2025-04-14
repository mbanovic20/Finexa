using System.Configuration;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using Finexa.Data.Db_Context;

namespace Finexa.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; } = null!;

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Ovdje koristi svoj connection string
                    services.AddDbContext<FinexaDbContext>(options =>
                        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FinexaDB;Trusted_Connection=True;"));

                    // Ovdje možeš dodavati i servise (npr. CurrencyService, WalletService itd.)
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            var mainWindow = new MainWindow();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }

}
