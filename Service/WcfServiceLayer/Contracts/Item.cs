using ServiceInterfaces;
using System.Runtime.Serialization;

namespace WcfServiceLayer.Contracts
{
    [DataContract]
    public class Item
    {
        #region PROPERTIES

        [DataMember]
        public long ID
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public double ParameterA
        {
            get;
            set;
        }

        [DataMember]
        public double ParameterB
        {
            get;
            set;
        }

        [DataMember]
        public double Product
        {
            get;
            set;
        }

        #endregion

        public Item()
        {
            this.ID = 0;
            this.Name = "";
            this.ParameterA = 0;
            this.ParameterB = 0;
            this.Product = 0;
        }

        public Item(IItemBO bo)
        {
            this.ID = bo.ID;
            this.Name = bo.Name;
            this.ParameterA = bo.ParameterA;
            this.ParameterB = bo.ParameterB;
            this.Product = bo.GetProduct();
        }
    }
}
