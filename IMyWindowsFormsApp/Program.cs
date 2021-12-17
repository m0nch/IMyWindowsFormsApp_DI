using IMyWindowsFormsApp.Data;
using IMyWindowsFormsApp.Repositories;
using IMyWindowsFormsApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMyWindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureService(services);

            using(ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureService(IServiceCollection services)
        {
            services.AddDbContext()
                    .AddRepositories()
                    .AddServices()
                    .AddScoped<MainForm>();
        }
    }
}
