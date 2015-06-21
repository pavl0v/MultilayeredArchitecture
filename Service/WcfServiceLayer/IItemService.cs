using System.Collections.Generic;
using System.ServiceModel;
using WcfServiceLayer.Contracts;

namespace WcfServiceLayer
{
    [ServiceContract]
    public interface IItemService
    {
        [OperationContract]
        Response<Item> GetItem(long id);

        [OperationContract]
        Response<List<Item>> GetItems();

        [OperationContract]
        Response<bool> DeleteItem(long id);

        [OperationContract]
        Response<long> UpdateItem(Item item);
    }
}
