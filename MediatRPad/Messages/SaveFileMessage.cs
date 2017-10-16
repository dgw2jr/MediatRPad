using MediatR;
using MediatRPad.Controls;

namespace MediatRPad.Messages
{
    [ToolBarButtonMetaData("Save", 2)]
    public class SaveFileMessage : IRequest { }
}