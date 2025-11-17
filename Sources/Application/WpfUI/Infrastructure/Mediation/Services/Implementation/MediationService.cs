using System.Threading.Tasks;
using MediatR;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Mediation.Models;

namespace Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Mediation.Services.Implementation
{
    public class MediationService(IMediator mediator, IInformationPublisher infoPublisher) : IMediationService
    {
        public async Task<T> SendAsync<T>(ICommand<T> command)
        {
            infoPublisher.Publish(InformationEntry.CreatWorkOnProgress());
            var result = await mediator.Send(command);
            infoPublisher.Publish(InformationEntry.CreateWorkDone());

            return result;
        }

        public async Task SendAsync(ICommand command)
        {
            infoPublisher.Publish(InformationEntry.CreatWorkOnProgress());
            await mediator.Send(command);
            infoPublisher.Publish(InformationEntry.CreateWorkDone());
        }

        public async Task<T> SendAsync<T>(IQuery<T> query)
        {
            infoPublisher.Publish(InformationEntry.CreatWorkOnProgress());
            var result = await mediator.Send(query);
            infoPublisher.Publish(InformationEntry.CreateWorkDone());

            return result;
        }
    }
}