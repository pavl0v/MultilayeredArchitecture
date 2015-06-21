using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientInterfaces;

namespace Models
{
    public class Result<T> : IResult<T>
    {
        T IResult<T>.Result
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public string Method
        {
            get;
            set;
        }

        public bool IsSuccessful
        {
            get;
            set;
        }

        public Result()
        {

        }
    }
}
