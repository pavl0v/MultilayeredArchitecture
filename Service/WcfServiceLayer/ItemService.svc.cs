using ServiceInterfaces;
using System;
using System.Collections.Generic;
using WcfServiceLayer.Contracts;

namespace WcfServiceLayer
{
    public class ItemService : IItemService
    {
        private IBLLItemManager itemManager = null;

        public ItemService(IBLLItemManager itemManager)
        {
            this.itemManager = itemManager;
        }

        public Response<Item> GetItem(long id)
        {
            Response<Item> res = new Response<Item>("GetItem");

            try
            {
                IItemBO bo = this.itemManager.GetItem(id);

                if (bo != null)
                {
                    Item item = new Item(bo);
                    res.IsSuccessful = true;
                    res.Result = item;
                }
                else
                {
                    res.IsSuccessful = false;
                    res.Message = "Item not found";
                    res.Result = null;
                }
            }
            catch (Exception ex)
            {
                res.IsSuccessful = false;
                res.Message = ex.Message;
                res.Result = null;
            }

            return res;
        }

        public Response<List<Item>> GetItems()
        {
            Response<List<Item>> res = new Response<List<Item>>("GetItems");

            List<Item> items = new List<Item>();

            try
            {
                List<IItemBO> bo = this.itemManager.GetItems();
                foreach (IItemBO i in bo)
                {
                    Item item = new Item(i);
                    items.Add(item);
                }

                res.IsSuccessful = true;
                res.Result = items;
            }
            catch (Exception ex)
            {
                res.IsSuccessful = false;
                res.Message = ex.Message;
                res.Result = null;
            }

            return res;
        }

        public Response<bool> DeleteItem(long id)
        {
            Response<bool> res = new Response<bool>("DeleteItem");

            try
            {
                bool del = this.itemManager.DeleteItem(id);
                //Item item = new Item(bo);

                res.IsSuccessful = del;
                res.Result = del;
            }
            catch (Exception ex)
            {
                res.IsSuccessful = false;
                res.Message = ex.Message;
                res.Result = false;
            }

            return res;
        }

        public Response<long> UpdateItem(Item item)
        {
            Response<long> res = new Response<long>("UpdateItem");

            try
            {
                IItemBO bo = this.itemManager.GetItem(item.ID);
                if (bo == null)
                    bo = this.itemManager.CreateItem();

                bo.Name = item.Name;
                bo.ParameterA = item.ParameterA;
                bo.ParameterB = item.ParameterB;
                bool save = bo.Save();

                res.IsSuccessful = save;
                res.Result = bo.ID;
            }
            catch (Exception ex)
            {
                res.IsSuccessful = false;
                res.Message = ex.Message;
                res.Result = 0;
            }

            return res;
        }
    }
}
