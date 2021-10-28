using Autofac;
using Autofac.Extras.AttributeMetadata;
using Autofac.Features.Metadata;
using MediatR;
using MediatRPad;
using MediatRPad.Controls;
using MediatRPad.Properties;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace MediatRPadCore
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("es");

            using (var scope = BuildContainer().BeginLifetimeScope())
            {
                var form = scope.Resolve<MainForm>();

                Application.Run(form);
            }
        }

        public static IContainer BuildContainer()
        {
            var assemblies = new[] { typeof(Program).Assembly, typeof(MainForm).Assembly };
            var builder = new ContainerBuilder();

            builder.RegisterModule<AttributedMetadataModule>();
            builder.Register(ctx => new ResourceManager(typeof(Resources))).SingleInstance();
            builder.RegisterType<Localizer>().AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<MainForm>().AsSelf().SingleInstance();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsAssignableTo<IMainFormComponent>())
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsDefined(typeof(ToolBarButtonMetaData)))
                .AsImplementedInterfaces();

            builder.RegisterAdapter<Meta<IRequest>, ButtonConfiguration>((ctx, m) =>
            {
                var localizer = ctx.Resolve<ILocalizer>();
                var mediator = ctx.Resolve<IMediator>();
                var button = new ButtonConfiguration
                {
                    Text = localizer.Localize(m.Metadata["Text"]!.ToString()!),
                    Order = (int)m.Metadata["Order"]!,
                    ParentMenuName = m.Metadata["ParentMenuName"]!.ToString(),
                };

                button.Click += (o, e) => { mediator.Send(m.Value); };

                return button;
            });

            builder.RegisterAssemblyModules(assemblies);

            return builder.Build();
        }        
    }

    
}