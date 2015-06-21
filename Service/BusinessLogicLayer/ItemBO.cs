using ServiceInterfaces;

namespace BusinessLogicLayer
{
    public class ItemBO : IItemBO
    {
        private IDALItemManager itemManager = null;

        #region PROPERTIES

        private long id = 0;
        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double parameterA = 0;
        public double ParameterA
        {
            get { return parameterA; }
            set { parameterA = value; }
        }

        private double parameterB = 0;
        public double ParameterB
        {
            get { return parameterB; }
            set { parameterB = value; }
        }

        #endregion

        public ItemBO(IDALItemManager itemManager)
        {
            this.itemManager = itemManager;

            this.id = 0;
            this.name = "";
            this.parameterA = 0;
            this.parameterB = 0;
        }

        public ItemBO(IDALItemManager itemManager, IItemDAO dao)
        {
            this.itemManager = itemManager;

            this.id = dao.ID;
            this.name = dao.Name;
            this.parameterA = dao.ParameterA;
            this.parameterB = dao.ParameterB;
        }

        public double GetProduct()
        {
            return this.parameterA * this.parameterB;
        }

        public bool Save()
        {
            bool res = false;

            IItemDAO dao = new ItemDAO(this);
            bool exist = this.itemManager.IsExist(this.id);

            if (exist)
            {
                res = this.itemManager.Update(dao);
            }
            else
            {
                long id = this.itemManager.Add(dao);
                this.ID = id;
                if (id != 0)
                    res = true;
            }

            return res;
        }
    }
}
