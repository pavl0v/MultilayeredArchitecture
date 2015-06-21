using ClientInterfaces;
using ClientInterfaces.DTO;
using ClientInterfaces.Models;
using ClientInterfaces.ServicesProxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Models.Models
{
    public class Item : IItem, INotifyPropertyChanged
    {
        private IServiceProxyFactory serviceProxyFactory = null;

        private long id = 0;
        private string name = "";
        private double parameterA = 0;
        private double parameterB = 0;
        private double product = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        #region PROPERTIES
        
        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public double ParameterA
        {
            get { return parameterA; }
            set
            {
                //parameterA = value;
                if (parameterA != value)
                {
                    parameterA = value;
                    OnPropertyChanged("ParameterA");
                }
            }
        }

        public double ParameterB
        {
            get { return parameterB; }
            set
            {
                //parameterB = value;
                if (parameterB != value)
                {
                    parameterB = value;
                    OnPropertyChanged("ParameterB");
                }
            }
        }

        public double Product
        {
            get { return product; }
            set
            {
                //product = value;
                if (product != value)
                {
                    product = value;
                    OnPropertyChanged("Product");
                }
            }
        }

        #endregion

        public Item(IServiceProxyFactory serviceProxyFactory)
        {
            this.serviceProxyFactory = serviceProxyFactory;
        }

        public Item(IServiceProxyFactory serviceProxyFactory, IItemDTO dto)
        {
            this.serviceProxyFactory = serviceProxyFactory;
            this.ID = dto.ID;
            this.Name = dto.Name;
            this.ParameterA = dto.ParameterA;
            this.ParameterB = dto.ParameterB;
            this.Product = dto.Product;
        }

        public bool Save()
        {
            IItemServiceProxy s = this.serviceProxyFactory.CreateItemServiceProxy();
            IResult<long> save = s.UpdateItem(this);
            if (save.Result != 0)
                return true;

            return false;
        }

        public IItem Clone()
        {
            IItem res = new Item(this.serviceProxyFactory);
            res.Name = this.Name;
            res.ParameterA = this.ParameterA;
            res.ParameterB = this.ParameterB;

            return res;
        }

        public double GetSum()
        {
            return this.parameterA + this.parameterB;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
