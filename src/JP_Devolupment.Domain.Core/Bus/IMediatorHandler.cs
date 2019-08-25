using System.Threading.Tasks;
using JP_Devolupment.Domain.Core.Commands;
using JP_Devolupment.Domain.Core.Events;


namespace JP_Devolupment.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
