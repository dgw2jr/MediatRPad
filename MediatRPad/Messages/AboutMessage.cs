using MediatR;
using MediatRPad.Controls;

namespace MediatRPad.Messages
{
    [ToolBarButtonMetaData("About", 3)]
    public class AboutMessage : IRequest { }
}