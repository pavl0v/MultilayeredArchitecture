using ClientInterfaces;
using ClientInterfaces.DTO;
using ClientInterfaces.Factories;
using ClientInterfaces.Models;
using ClientInterfaces.ServicesProxy;
using System.Collections.Generic;

namespace Models.Models
{
    public class ItemsCollection : IItemsCollection
    {
        private IServiceProxyFactory serviceProxyFactory = null;
        private IObjectFactory objectFactory = null;

        public ItemsCollection(IServiceProxyFactory serviceProxyFactory, IObjectFactory objectFactory)
        {
            this.serviceProxyFactory = serviceProxyFactory;
            this.objectFactory = objectFactory;
        }

        public List<IItem> GetItems()
        {
            List<IItem> res = new List<IItem>();

            IItemServiceProxy s = this.serviceProxyFactory.CreateItemServiceProxy();
            IResult<List<IItemDTO>> dto = s.GetItems();
            if (dto.IsSuccessful)
            {
                IItemFactory f = this.objectFactory.CreateItemFactory();
                foreach (IItemDTO d in dto.Result)
                {
                    IResult<IItem> item = f.CreateItem(d);
                    res.Add(item.Result);
                }
            }

            return res;
        }

        public long AddItem(IItem item)
        {
            IItemServiceProxy s = this.serviceProxyFactory.CreateItemServiceProxy();
            IResult<long> id = s.UpdateItem(item);
            return id.Result;
        }

        public bool DeleteItem(long id)
        {
            IItemServiceProxy s = this.serviceProxyFactory.CreateItemServiceProxy();
            IResult<bool> del = s.DeleteItem(id);
            return del.Result;
        }
    }
}
