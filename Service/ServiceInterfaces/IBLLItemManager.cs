using ServiceInterfaces;
using System;
using System.Collections.Generic;

namespace ServiceInterfaces
{
    public interface IBLLItemManager
    {
        /// <summary>
        /// Retrieve item from database
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <returns>Item</returns>
        IItemBO GetItem(long id);

        /// <summary>
        /// Create new item
        /// </summary>
        /// <returns>Item</returns>
        IItemBO CreateItem();

        /// <summary>
        /// Delete item from database
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <returns>Success of operation</returns>
        bool DeleteItem(long id);

        /// <summary>
        /// Retrieve all items from database
        /// </summary>
        /// <returns>Items collection</returns>
        List<IItemBO> GetItems();
    }
}
