using MediatR;
using MediatRPad.Controls;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRPad.MessageHandlers
{
    [ToolBarButtonMetaData(MenuConstants.Options.Exit, MenuConstants.Order.Exit, MenuConstants.Names.File)]
    public class ExitMessage : IRequest { }

    public class ExitMessageHandler : IRequestHandler<ExitMessage, Unit>
    {
        public async Task<Unit> Handle(ExitMessage message, CancellationToken token)
        {
            Environment.Exit(0);

            return await Unit.Task;
        }
    }
}