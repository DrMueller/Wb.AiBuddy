using Microsoft.Extensions.Configuration;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services;
using Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.DependencyInjection;
using Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Settings.Config.Services;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container;

namespace Mmu.Wb.TimeBuddy.WpfUI
{
    public partial class App
    {
        internal static IHideableView HideableView { get; private set; }

        internal static IConfiguration Configuration { get; } = ConfigurationFactory.Create(typeof(App).Assembly);

        [SuppressMessage("Usage", "VSTHRD100:Avoid async void methods", Justification = "WPF expects void")]
        protected override async void OnStartup(StartupEventArgs e)
        {
            var assembly = typeof(App).Assembly;
            var windowConfig = WindowConfiguration.CreateWithDefaultIcon(assembly, "AI Buddy", 620, 600);

            var config = new WpfAppConfiguration(assembly, windowConfig);
            var container = ContainerFactory.Create();

            HideableView = await AppStartService.StartAppAsync(
                config,
                container);

            HideableView.StartApp();
        }
    }
}