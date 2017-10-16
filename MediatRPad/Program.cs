using System;
using System.Collections.Generic;
using System.Linq;
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
                .SingleInstance();

            builder.RegisterAssemblyTypes(thisAssembly)
                .Where(t => t.IsDefined(typeof(ToolBarButtonMetaData)))
                .AsImplementedInterfaces();

            builder.RegisterAdapter<Meta<IRequest>, ButtonConfiguration>((ctx, m) =>
            {
                var mediator = ctx.Resolve<IMediator>();
                var button = new ButtonConfiguration
                {
                    Text = (string) m.Metadata["Text"],
                    Order = (int)m.Metadata["Order"]
                };

                button.Click += (o, e) => { mediator.Send(m.Value); };

                return button;
            });

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(thisAssembly).Where(t =>
                    t.GetInterfaces().Any(i => i.IsClosedTypeOf(typeof(IRequestHandler<>))
                                               || i.IsClosedTypeOf(typeof(IRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(IAsyncRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(IAsyncRequestHandler<>))
                                               || i.IsClosedTypeOf(typeof(ICancellableAsyncRequestHandler<,>))
                                               || i.IsClosedTypeOf(typeof(INotificationHandler<>))
                                               || i.IsClosedTypeOf(typeof(IAsyncNotificationHandler<>))
                                               || i.IsClosedTypeOf(typeof(ICancellableAsyncNotificationHandler<>))
                    )
                )
                .AsImplementedInterfaces();

            // request handlers
            builder.Register<SingleInstanceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.ResolveOptional(t);
                })
                .InstancePerLifetimeScope();

            // notification handlers
            builder.Register<MultiInstanceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                })
                .InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
