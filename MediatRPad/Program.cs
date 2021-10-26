using System;
using System.Reflection;
using System.Windows.Forms;
using Autofac;
using Autofac.Extras.AttributeMetadata;
using Autofac.Features.Metadata;
using MediatR;
using MediatRPad.Controls;

namespace MediatRPad
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var scope = BuildContainer().BeginLifetimeScope())
            {
                var form = scope.Resolve<MainForm>();

                Application.Run(form);
            }
        }

        public static IContainer BuildContainer()
        {
            var thisAssembly = typeof(Program).Assembly;
            var builder = new ContainerBuilder();

            builder.RegisterModule<AttributedMetadataModule>();

            builder.RegisterType<MainForm>().AsSelf().SingleInstance();
            builder.RegisterAssemblyTypes(thisAssembly)
                .Where(t => t.IsAssignableTo<IMainFormComponent>())
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(thisAssembly)
                .Where(t => t.IsDefined(typeof(ToolBarButtonMetaData)))
                .AsImplementedInterfaces();

            builder.RegisterAdapter<Meta<IRequest>, ButtonConfiguration>((ctx, m) =>
            {
                var mediator = ctx.Resolve<IMediator>();
                var button = new ButtonConfiguration
                {
                    Text = (string)m.Metadata["Text"],
                    Order = (int)m.Metadata["Order"],
                    ParentMenuName = (string)m.Metadata["ParentMenuName"],
                };

                button.Click += (o, e) => { mediator.Send(m.Value); };

                return button;
            });

            builder.RegisterAssemblyModules(thisAssembly);
            
            return builder.Build();
        }
    }
}
