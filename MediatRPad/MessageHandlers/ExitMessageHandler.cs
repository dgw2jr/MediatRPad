using MediatR;
using MediatRPad.Controls;
using System;

namespace MediatRPad.MessageHandlers
{
    [ToolBarButtonMetaData(MenuConstants.Options.Exit, MenuConstants.Order.Exit, MenuConstants.Names.File)]
    public class ExitMessage : IRequest { }

    public class ExitMessageHandler : IRequestHandler<ExitMessage>
    {
        public void Handle(ExitMessage message)
        {
            Environment.Exit(0);
        }
    }
}