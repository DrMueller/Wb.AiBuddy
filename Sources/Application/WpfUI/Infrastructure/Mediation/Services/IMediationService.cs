using System.Threading.Tasks;
using Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Mediation.Models;

namespace Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Mediation.Services
{
    public interface IMediationService
    {
        Task<T> SendAsync<T>(ICommand<T> command);

        Task SendAsync(ICommand command);

        Task<T> SendAsync<T>(IQuery<T> query);
    }
}