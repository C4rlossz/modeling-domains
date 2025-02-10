using System.Windows.Input;
using PaymentContext.Shared.Commands;
using ICommand = System.Windows.Input.ICommand;

namespace PaymentContext.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}