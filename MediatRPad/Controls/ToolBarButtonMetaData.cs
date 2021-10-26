using System;
using System.ComponentModel.Composition;

namespace MediatRPad.Controls
{
    [MetadataAttribute]
    public class ToolBarButtonMetaData : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">The text to display</param>
        /// <param name="order">The order to display in</param>
        /// <param name="parentMenuName">The parent menu to display under</param>
        public ToolBarButtonMetaData(string text, int order, string parentMenuName)
        {
            Text = text;
            Order = order;
            ParentMenuName = parentMenuName;
        }

        public string Text { get; }
        public string ParentMenuName { get; }
        public int Order { get; }
    }
}