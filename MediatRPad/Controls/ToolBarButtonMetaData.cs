using System;
using System.ComponentModel.Composition;

namespace MediatRPad.Controls
{
    [MetadataAttribute]
    public class ToolBarButtonMetaData : Attribute
    {
        public ToolBarButtonMetaData(string text, int order)
        {
            Text = text;
            Order = order;
        }

        public string Text { get; }

        public int Order { get; }
    }
}