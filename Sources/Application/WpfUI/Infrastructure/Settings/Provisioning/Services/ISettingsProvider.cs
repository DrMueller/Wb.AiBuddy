using Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Settings.Provisioning.Models;

namespace Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Settings.Provisioning.Services
{
    public interface ISettingsProvider
    {
        AppSettings AppSettings { get; }
    }
}