using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientInterfaces
{
    public interface IResult<T>
    {
        T Result { get;set; }
        string Message { get;set; }
        string Method { get;set; }
        bool IsSuccessful { get;set; }
    }
}
