using Shared.Commands;

namespace Domain.Commands.Results
{
    public class GenericCommandResult : ICommandResult
    {
        public string Message { get; set; }
    }
}
