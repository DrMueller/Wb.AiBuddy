using JetBrains.Annotations;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection;
using Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Settings.Provisioning.Models;
using System.Configuration;

namespace Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class WpfUiRegistryCollection : ServiceRegistry
    {
        public WpfUiRegistryCollection()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<WpfUiRegistryCollection>();
                scanner.WithDefaultConventions();
                scanner.AddAllTypesOf<IViewModel>();
            });

            var appSettingsSection = App.Configuration.GetSection(AppSettings.SectionKey);

            this
                .AddOptions<AppSettings>()
                .Bind(appSettingsSection)
                .ValidateOnStart();

            this.AddMediatR(f => f.RegisterServicesFromAssemblyContaining<WpfUiRegistryCollection>());
            this.AddWpfCore();
        }
    }
}