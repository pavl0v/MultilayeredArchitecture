using System;
using System.Collections.Generic;

namespace ServiceInterfaces
{
    public interface IDALItemManager
    {
        /// <summary>
        /// Add new item to database
        /// </summary>
        /// <param name="dao">New item</param>
        /// <returns>New item ID</returns>
        long Add(IItemDAO dao);

        /// <summary>
        /// Delete item from database
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <returns>Success of operation</returns>
        bool Delete(long id);

        /// <summary>
        /// Retrieve item from database
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <returns>Item</returns>
        IItemDAO Get(long id);

        /// <summary>
        /// Retrieve all items from database
        /// </summary>
        /// <returns>Items collection</returns>
        List<IItemDAO> GetAll();

        /// <summary>
        /// Save existing item
        /// </summary>
        /// <param name="dao">Item</param>
        /// <returns>Success of operation</returns>
        bool Update(IItemDAO dao);

        /// <summary>
        /// Check if item exist in database
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <returns>Check result</returns>
        bool IsExist(long id);
    }
}
