using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using ServiceInterfaces;

namespace DataAccessLayer
{
    public class DALItemManagerSQLite : IDALItemManager
    {
        private readonly string cs = @"Data Source=|DataDirectory|\Database.sqlite;Version=3;";
        private readonly string dbName = "Database.sqlite";

        public bool CreateDatabase()
        {
            bool res = false;

            try
            {
                SQLiteConnection.CreateFile(this.dbName);
            }
            catch
            {
                return false;
            }

            string sql =
                @"CREATE TABLE 'tblItems' (
                    'ID' INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    'Name' TEXT,
                    'ParameterA' REAL NOT NULL DEFAULT 0,
                    'ParameterB' REAL NOT NULL DEFAULT 0
                )";

            using (SQLiteConnection con = new SQLiteConnection(this.cs))
            {
                SQLiteCommand command = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    res = true;
                }
                catch
                {
                    //res = false;
                }
            }

            return res;
        }

        #region IDALItemManager implementation

        public long Add(IItemDAO dao)
        {
            object r = null;

            string sql = "INSERT INTO tblItems ([Name], [ParameterA], [ParameterB]) VALUES (@name, @parametera, @parameterb); SELECT last_insert_rowid();";

            using (SQLiteConnection con = new SQLiteConnection(this.cs))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                SQLiteParameter name = new SQLiteParameter("name", dao.Name);
                SQLiteParameter parametera = new SQLiteParameter("parametera", dao.ParameterA);
                SQLiteParameter parameterb = new SQLiteParameter("parameterb", dao.ParameterB);
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(parametera);
                cmd.Parameters.Add(parameterb);
                try
                {
                    con.Open();
                    r = cmd.ExecuteScalar();
                    con.Close();
                }
                catch
                {
                    con.Close();
                }
            }

            if (r != null)
                return (long)r;

            return 0;
        }

        public bool Delete(long id)
        {
            bool res = false;

            string sql = "DELETE FROM tblItems WHERE [ID]=@id";

            using (SQLiteConnection con = new SQLiteConnection(this.cs))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                SQLiteParameter p = new SQLiteParameter("id", id);
                cmd.Parameters.Add(p);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    res = true;
                }
                catch
                {
                    con.Close();
                }
            }

            return res;
        }

        public IItemDAO Get(long id)
        {
            IItemDAO res = null;

            string sql = "SELECT * FROM tblItems WHERE [ID]=@id";

            using (SQLiteConnection con = new SQLiteConnection(this.cs))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                SQLiteParameter p = new SQLiteParameter("id", id);
                cmd.Parameters.Add(p);
                try
                {
                    con.Open();
                    using (SQLiteDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            r.Read();
                            res = new ItemDAO();
                            res.ID = Convert.ToInt64(r["ID"]);
                            res.Name = Convert.ToString(r["Name"]);
                            res.ParameterA = Convert.ToDouble(r["ParameterA"]);
                            res.ParameterB = Convert.ToDouble(r["ParameterB"]);
                        }
                        r.Close();
                    }
                    con.Close();
                }
                catch
                {
                    con.Close();
                    res = null;
                }
            }

            return res;
        }

        public List<IItemDAO> GetAll()
        {
            List<IItemDAO> res = new List<IItemDAO>();

            string sql = "SELECT * FROM tblItems";

            using (SQLiteConnection con = new SQLiteConnection(this.cs))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    using (SQLiteDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                IItemDAO item = new ItemDAO();
                                item.ID = Convert.ToInt64(r["ID"]);
                                item.Name = Convert.ToString(r["Name"]);
                                item.ParameterA = Convert.ToDouble(r["ParameterA"]);
                                item.ParameterB = Convert.ToDouble(r["ParameterB"]);
                                res.Add(item);
                            }
                        }
                        r.Close();
                    }
                    con.Close();
                }
                catch
                {
                    con.Close();
                    res = null;
                }
            }

            return res;
        }

        public bool IsExist(long id)
        {
            bool res = false;

            string sql = "SELECT * FROM tblItems WHERE [ID]=@id";

            using (SQLiteConnection con = new SQLiteConnection(this.cs))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                SQLiteParameter p = new SQLiteParameter("id", id);
                cmd.Parameters.Add(p);
                try
                {
                    con.Open();
                    using (SQLiteDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            res = true;
                        }
                        r.Close();
                    }
                    con.Close();
                }
                catch
                {
                    con.Close();
                }
            }

            return res;
        }

        public bool Update(IItemDAO dao)
        {
            bool res = false;

            string sql = "UPDATE tblItems SET [Name]=@name, [ParameterA]=@parametera, [ParameterB]=@parameterb WHERE [ID]=@id";

            using (SQLiteConnection con = new SQLiteConnection(this.cs))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                SQLiteParameter id = new SQLiteParameter("id", dao.ID);
                SQLiteParameter name = new SQLiteParameter("name", dao.Name);
                SQLiteParameter parametera = new SQLiteParameter("parametera", dao.ParameterA);
                SQLiteParameter parameterb = new SQLiteParameter("parameterb", dao.ParameterB);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(parametera);
                cmd.Parameters.Add(parameterb);
                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                        res = true;
                    con.Close();
                }
                catch(Exception ex)
                {
                    con.Close();
                }
            }

            return res;
        }

        #endregion
    }
}
