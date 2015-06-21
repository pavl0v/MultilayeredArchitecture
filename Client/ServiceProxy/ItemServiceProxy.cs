using ClientInterfaces;
using ClientInterfaces.DTO;
using ClientInterfaces.Models;
using ClientInterfaces.ServicesProxy;
using ServiceProxy.ItemServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceProxy
{
    public class ItemServiceProxy : IItemServiceProxy
    {
        private ItemServiceRef.IItemService serviceProxy = null;

        public ItemServiceProxy(ItemServiceRef.IItemService serviceProxy)
        {
            this.serviceProxy = serviceProxy;
        }

        public IResult<IItemDTO> GetItem(long id)
        {
            IResult<IItemDTO> res = new Result<IItemDTO>();

            try
            {
                ItemServiceClient client = this.serviceProxy as ItemServiceClient;
                ResponseOfTypeItem resp = client.GetItem(id);
                client.Close();

                if (resp.IsSuccessful)
                {
                    res.IsSuccessful = true;
                    res.Message = "";
                    res.Method = resp.Method;
                    res.Result = resp.Result;
                }
                else
                {
                    res.IsSuccessful = false;
                    res.Message = resp.Message;
                    res.Method = resp.Method;
                    res.Result = null;
                }
            }
            catch(Exception ex)
            {
                res.IsSuccessful = false;
                res.Message = ex.Message;
                res.Method = "GetItem";
                res.Result = null;
            }

            return res;
        }

        public IResult<List<IItemDTO>> GetItems()
        {
            IResult<List<IItemDTO>> res = new Result<List<IItemDTO>>();

            List<IItemDTO> items = new List<IItemDTO>();

            try
            {
                ItemServiceClient client = this.serviceProxy as ItemServiceClient;
                ResponseOfTypeArrayOfItem resp = client.GetItems();
                client.Close();

                if (resp.IsSuccessful)
                {

                    foreach (IItemDTO dto in resp.Result)
                    {
                        items.Add(dto);
                    }

                    res.IsSuccessful = true;
                    res.Message = "";
                    res.Method = resp.Method;
                    res.Result = items;
                }
                else
                {
                    res.IsSuccessful = false;
                    res.Message = resp.Message;
                    res.Method = resp.Method;
                    res.Result = items;
                }
            }
            catch (Exception ex)
            {
                res.IsSuccessful = false;
                res.Message = ex.Message;
                res.Method = "GetItems";
                res.Result = items;
            }

            return res;
        }

        public IResult<bool> DeleteItem(long id)
        {
            IResult<bool> res = new Result<bool>();

            try
            {
                ItemServiceClient client = this.serviceProxy as ItemServiceClient;
                ResponseOfTypeboolean resp = client.DeleteItem(id);
                client.Close();

                if (resp.IsSuccessful)
                {
                    res.IsSuccessful = true;
                    res.Message = "";
                    res.Method = resp.Method;
                    res.Result = resp.Result;
                }
                else
                {
                    res.IsSuccessful = false;
                    res.Message = resp.Message;
                    res.Method = resp.Method;
                    res.Result = false;
                }
            }
            catch (Exception ex)
            {
                res.IsSuccessful = false;
                res.Message = ex.Message;
                res.Method = "DeleteItem";
                res.Result = false;
            }

            return res;
        }

        public IResult<long> UpdateItem(IItem bo)
        {
            IResult<long> res = new Result<long>();

            Item dto = new Item();
            dto.ID = bo.ID;
            dto.Name = bo.Name;
            dto.ParameterA = bo.ParameterA;
            dto.ParameterB = bo.ParameterB;
            dto.Product = bo.Product;

            try
            {
                ItemServiceClient client = this.serviceProxy as ItemServiceClient;
                ResponseOfTypelong resp = client.UpdateItem(dto);
                client.Close();

                if (resp.IsSuccessful)
                {
                    res.IsSuccessful = true;
                    res.Message = "";
                    res.Method = resp.Method;
                    res.Result = resp.Result;
                }
                else
                {
                    res.IsSuccessful = false;
                    res.Message = resp.Message;
                    res.Method = resp.Method;
                    res.Result = 0;
                }
            }
            catch (Exception ex)
            {
                res.IsSuccessful = false;
                res.Message = ex.Message;
                res.Method = "UpdateItem";
                res.Result = 0;
            }

            return res;
        }
    }
}
