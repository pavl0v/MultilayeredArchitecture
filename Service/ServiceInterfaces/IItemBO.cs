using System;

namespace ServiceInterfaces
{
    public interface IItemBO
    {
        /// <summary>
        /// Calculate product of parameters A and B
        /// </summary>
        /// <returns></returns>
        double GetProduct();

        /// <summary>
        /// Item ID
        /// </summary>
        long ID { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Item parameter A
        /// </summary>
        double ParameterA { get; set; }

        /// <summary>
        /// Item parameter B
        /// </summary>
        double ParameterB { get; set; }

        /// <summary>
        /// Save item property changes
        /// </summary>
        /// <returns></returns>
        bool Save();
    }
}
