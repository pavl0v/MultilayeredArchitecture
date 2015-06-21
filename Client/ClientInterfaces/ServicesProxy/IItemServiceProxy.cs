using ClientInterfaces;
using ClientInterfaces.DTO;
using ClientInterfaces.Models;
using System;
using System.Collections.Generic;

namespace ClientInterfaces.ServicesProxy
{
    public interface IItemServiceProxy
    {
        IResult<IItemDTO> GetItem(long id);
        IResult<List<IItemDTO>> GetItems();
        IResult<bool> DeleteItem(long id);
        IResult<long> UpdateItem(IItem bo);
    }
}
