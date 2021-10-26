using MediatR;
using MediatRPad.Controls;
using System;

namespace MediatRPad.MessageHandlers
{
    [ToolBarButtonMetaData("Exit", 3, "File")]
    public class ExitMessage : IRequest { }

    public class ExitMessageHandler : IRequestHandler<ExitMessage>
    {
        public void Handle(ExitMessage message)
        {
            Environment.Exit(0);
        }
    }
}