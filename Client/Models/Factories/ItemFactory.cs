using ClientInterfaces;
using ClientInterfaces.DTO;
using ClientInterfaces.Factories;
using ClientInterfaces.Models;
using ClientInterfaces.ServicesProxy;

namespace Models.Factories
{
    public class ItemFactory : IItemFactory
    {
        private IServiceProxyFactory serviceProxyFactory = null;

        public ItemFactory(IServiceProxyFactory serviceProxyFactory)
        {
            this.serviceProxyFactory = serviceProxyFactory;
        }

        public IResult<IItem> CreateItem()
        {
            IResult<IItem> res = new Result<IItem>();

            IItem o = new Models.Item(this.serviceProxyFactory);

            res.IsSuccessful = true;
            res.Message = "";
            res.Method = "CreateItem";
            res.Result = o;

            return res;
        }

        public IResult<IItem> CreateItem(long id)
        {
            IResult<IItem> res = new Result<IItem>();

            IItemServiceProxy s = this.serviceProxyFactory.CreateItemServiceProxy();

            IResult<IItemDTO> dto = s.GetItem(id);
            if (!dto.IsSuccessful)
            {
                res.IsSuccessful = false;
                res.Message = dto.Message;
                res.Method = dto.Method;
                res.Result = null;
            }
            else
            {
                res = this.CreateItem(dto.Result);
            }

            return res;
        }

        public IResult<IItem> CreateItem(IItemDTO dto)
        {
            IResult<IItem> res = new Result<IItem>();

            IItem o = new Models.Item(this.serviceProxyFactory, dto);

            res.IsSuccessful = true;
            res.Message = "";
            res.Method = "CreateItem";
            res.Result = o;

            return res;
        }
    }
}
