namespace Shared.Commands
{
    public interface ICommandHandler<in T>
    {
        ICommandResult Handle(T command);
    }
}
