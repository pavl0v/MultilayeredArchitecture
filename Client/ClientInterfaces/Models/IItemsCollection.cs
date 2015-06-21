using ClientInterfaces.Models;
using System;
using System.Collections.Generic;

namespace ClientInterfaces.Models
{
    public interface IItemsCollection
    {
        long AddItem(IItem item);
        bool DeleteItem(long id);
        List<IItem> GetItems();
    }
}
