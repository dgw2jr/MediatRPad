using MediatR;
using MediatRPad.Controls;

namespace MediatRPad.Messages
{
    [ToolBarButtonMetaData("About", 4)]
    public class AboutMessage : IRequest { }
}