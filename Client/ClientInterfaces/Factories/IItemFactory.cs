using ClientInterfaces;
using ClientInterfaces.DTO;
using ClientInterfaces.Models;
using System;

namespace ClientInterfaces.Factories
{
    public interface IItemFactory
    {
        IResult<IItem> CreateItem();
        IResult<IItem> CreateItem(long id);
        IResult<IItem> CreateItem(IItemDTO dto);
    }
}
