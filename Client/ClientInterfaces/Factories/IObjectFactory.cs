namespace ClientInterfaces.Factories
{
    public interface IObjectFactory
    {
        IItemFactory CreateItemFactory();
        // some other object factories ...
    }
}
