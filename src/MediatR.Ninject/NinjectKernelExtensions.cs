using Ninject;

namespace MediatR.Ninject
{
    public static class NinjectKernelExtensions
    {
        /// <summary>
        /// Loads the MediaR Ninject Module in the given kernel.
        /// <see cref="MediatRModule"/>
        /// </summary>
        /// <param name="kernel"></param>
        /// <returns></returns>
        public static IKernel BindMediatR(this IKernel kernel)
        {
            kernel.Load<MediatRModule>();
            return kernel;
        }
    }
}