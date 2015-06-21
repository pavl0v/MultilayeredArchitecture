using System;

namespace ClientInterfaces.Models
{
    public interface IItem
    {
        IItem Clone();
        double GetSum();
        long ID { get; set; }
        string Name { get; set; }
        double ParameterA { get; set; }
        double ParameterB { get; set; }
        double Product { get; set; }
        bool Save();
    }
}
