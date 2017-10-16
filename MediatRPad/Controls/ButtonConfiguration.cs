using System;

namespace MediatRPad.Controls
{
    public class ButtonConfiguration
    {
        public string Text { get; set; }

        public EventHandler Click { get; set; }

        public int Order { get; internal set; }
    }
}