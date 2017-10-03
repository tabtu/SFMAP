using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DGroup
    {

        public IList<BGroup> SELECT_ALL()
        {
            string sqlstr = "SELECT id, g_name FROM yxg_group";

            DataSet ds = MySqlHelper.ExecuteQuery(sqlstr);
            DataTable dt = ds.Tables[0];

            IList<BGroup> result = new List<BGroup>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BGroup temp = new BGroup();

                temp.ID = short.Parse(dt.Rows[i][0].ToString());
                temp.Name = dt.Rows[i][1].ToString();

                result.Add(temp);
            }
            return result;

        }
    }
}
