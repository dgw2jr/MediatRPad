using MediatR;
using MediatRPad.Controls;

namespace MediatRPad.Messages
{
    [ToolBarButtonMetaData("Open", 1)]
    public class OpenFileMessage : IRequest { }
}