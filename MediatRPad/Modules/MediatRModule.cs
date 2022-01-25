using System;
using System.Collections.Generic;
using Autofac;
using MediatR;
using MediatRPad.Notifications.PipelineBehaviors;

namespace MediatRPad.Modules
{
    internal class MediatRModule : Module
    {
        private readonly Type[] _handlerInterfaces = {
            typeof(IRequestHandler<>),
            typeof(IRequestHandler<,>),
            typeof(INotificationHandler<>)
        };

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var handlerInterface in _handlerInterfaces)
            {
                builder.RegisterAssemblyTypes(ThisAssembly)
                    .AsClosedTypesOf(handlerInterface);
            }

            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly)
                .AsImplementedInterfaces();

            // request handlers
            builder.Register<ServiceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.ResolveOptional(t);
                })
                .InstancePerLifetimeScope();

#if DEBUG
            builder.RegisterGeneric(typeof(DebugMessageTimingsBehavior<,>))
                .As(typeof(IPipelineBehavior<,>))
                .InstancePerLifetimeScope();
#endif
        }
    }
}
