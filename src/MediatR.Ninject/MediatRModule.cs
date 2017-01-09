using Ninject;
using Ninject.Modules;
using Ninject.Planning.Bindings.Resolvers;

namespace MediatR.Ninject
{
    /// <summary>
    /// Binds the required MediaR services to the Ninject kernel, including:
    ///  - IMediator
    ///  - SingleInstanceFactory
    ///  - MultiInstanceFactory
    ///  - ContravariantBindingResolver
    /// This does not bind the MediaR handlers - it's not magic.
    /// </summary>
    public class MediatRModule : NinjectModule
    {
        public override void Load()
        {
            Kernel?.Components.Add<IBindingResolver, ContravariantBindingResolver>();

            Kernel?.Bind<IMediator>().To<Mediator>();
            Kernel?.Bind<SingleInstanceFactory>().ToMethod(ctx => t => ctx.Kernel.Get(t));
            Kernel?.Bind<MultiInstanceFactory>().ToMethod(ctx => t => ctx.Kernel.GetAll(t));
        }
    }
}