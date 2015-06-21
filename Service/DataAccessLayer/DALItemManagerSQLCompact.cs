using System.Linq;
using ServiceInterfaces;
using System.Collections.Generic;
using System;

namespace DataAccessLayer
{
    public class DALItemManagerSQLCompact : IDALItemManager
    {
        public long Add(IItemDAO dao)
        {
            long id = 0;

            DataModel.tblItem item = new DataModel.tblItem();
            item.Name = dao.Name;
            item.ParameterA = dao.ParameterA;
            item.ParameterB = dao.ParameterB;

            try
            {
                using (DataModel.DatabaseEntities db = new DataModel.DatabaseEntities())
                {
                    db.tblItems.Add(item);
                    int i = db.SaveChanges();
                    id = item.ID;
                }
            }
            catch
            {
                id = 0;
            }

            return id;
        }

        public bool Delete(long id)
        {
            bool res = false;

            try
            {
                using (DataModel.DatabaseEntities db = new DataModel.DatabaseEntities())
                {
                    DataModel.tblItem item = db.tblItems.Where(x => x.ID == id).FirstOrDefault();
                    if (item != null)
                    {
                        db.tblItems.Remove(item);
                        db.SaveChanges();
                    }
                }

                res = true;
            }
            catch
            {
                res = false;
            }

            return res;
        }

        public IItemDAO Get(long id)
        {
            IItemDAO res = null;

            try
            {
                using (DataModel.DatabaseEntities db = new DataModel.DatabaseEntities())
                {
                    res = db.tblItems.Where(x => x.ID == id).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                res = null;
            }

            return res;
        }

        public List<IItemDAO> GetAll()
        {
            List<IItemDAO> res = null;

            try
            {
                using (DataModel.DatabaseEntities db = new DataModel.DatabaseEntities())
                {
                    res = db.tblItems.ToList<IItemDAO>();
                }
            }
            catch
            {
                res = null;
            }

            if (res == null)
                res = new List<IItemDAO>();

            return res;
        }

        public bool Update(IItemDAO dao)
        {
            bool res = false;

            try
            {
                using (DataModel.DatabaseEntities db = new DataModel.DatabaseEntities())
                {
                    DataModel.tblItem item = db.tblItems.Where(x => x.ID == dao.ID).FirstOrDefault();
                    if (item != null)
                    {
                        item.Name = dao.Name;
                        item.ParameterA = dao.ParameterA;
                        item.ParameterB = dao.ParameterB;

                        int i = db.SaveChanges();
                        res = true;
                    }
                }
            }
            catch
            {
                res = false;
            }

            return res;
        }

        public bool IsExist(long id)
        {
            bool res = false;

            try
            {
                using (DataModel.DatabaseEntities db = new DataModel.DatabaseEntities())
                {
                    IItemDAO item = db.tblItems.Where(x => x.ID == id).FirstOrDefault();
                    if (item != null)
                        res = true;
                }
            }
            catch
            {
                res = false;
            }

            return res;
        }
    }
}
