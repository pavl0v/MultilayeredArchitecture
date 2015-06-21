using ServiceInterfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class BLLItemManager : IBLLItemManager
    {
        private IDALItemManager itemManager = null;

        public BLLItemManager(IDALItemManager itemManager)
        {
            this.itemManager = itemManager;
        }

        public List<IItemBO> GetItems()
        {
            List<IItemBO> res = new List<IItemBO>();

            List<IItemDAO> dao = this.itemManager.GetAll();
            foreach (IItemDAO d in dao)
            {
                IItemBO item = new ItemBO(this.itemManager, d);
                res.Add(item);
            }

            return res;
        }

        public IItemBO GetItem(long id)
        {
            IItemDAO dao = this.itemManager.Get(id);
            if (dao == null)
                return null;

            return new ItemBO(this.itemManager, dao);
        }

        public IItemBO CreateItem()
        {
            return new ItemBO(this.itemManager);
        }

        public bool DeleteItem(long id)
        {
            bool res = this.itemManager.Delete(id);

            return res;
        }
    }
}
