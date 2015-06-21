namespace ClientInterfaces.ServicesProxy
{
    public interface IServiceProxyFactory
    {
        IItemServiceProxy CreateItemServiceProxy();
        // some other service factories ...
    }
}
