namespace MediatRPad
{
    internal class MenuConstants
    {
        public class Names
        {
            public const string File = "File";
            public const string Help = "Help";
        }

        public class Options
        {
            public const string Open = "Open";
            public const string Save = "Save";
            public const string Print = "Print";
            public const string Exit = "Exit";
            public const string About = "About";
        }
        
        public class Order
        {
            public const int Open = 0;
            public const int About = 0;
            public const int Save = 1;
            public const int Print = 2;
            public const int Exit = 3;
        }        
    }    
}
