using ServiceInterfaces;

namespace DataAccessLayer
{
    /// <summary>
    /// Proxy class to implement IItemDAO interface
    /// </summary>
    class ItemDAO : IItemDAO
    {
        public long ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public double ParameterA
        {
            get;
            set;
        }

        public double ParameterB
        {
            get;
            set;
        }

        public ItemDAO()
        {

        }
    }
}
