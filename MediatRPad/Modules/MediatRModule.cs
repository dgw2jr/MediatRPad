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

#if DEBUG
            builder.RegisterGeneric(typeof(DebugMessageTimingsBehavior<,>))
                .As(typeof(IPipelineBehavior<,>))
                .InstancePerLifetimeScope();
#endif
        }
    }
}
