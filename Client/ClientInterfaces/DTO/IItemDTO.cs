using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientInterfaces.DTO
{
    public interface IItemDTO
    {
        long ID { get; set; }
        string Name { get; set; }
        double ParameterA { get; set; }
        double ParameterB { get; set; }
        double Product { get; set; }
    }
}
