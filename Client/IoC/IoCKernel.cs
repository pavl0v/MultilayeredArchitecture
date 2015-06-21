using Ninject;

namespace IoC
{
    public class IoCKernel
    {
        private static readonly IKernel kernel = null;

        public static IKernel Kernel
        {
            get { return kernel; }
        } 

        static IoCKernel()
        {
            kernel = new StandardKernel(new IoCKernelModule1());
        }
    }
}
