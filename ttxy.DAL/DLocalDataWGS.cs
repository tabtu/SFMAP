using System.Collections.Generic;
using System.Data;

using ttxy.Model;

namespace ttxy.DAL
{
    public class DLocalDataWGS
    {
        public int INSERT(LocalData ld)
        {
            string sqlstr = "INSERT INTO yxg_localdata_wgs (b_name, addr, lng, lat, key_w, b_group, b_type, tele, pic, des, isused, OCW)VALUES('" +
                ld.Name + "', '" +
                ld.Address + "', " +
                ld.Lng + ", " +
                ld.Lat + ", '" +
                ld.Key_W + "', '" +
                ld.Group + "', '" +
                ld.Type + "', '" +
                ld.Tele + "', '" +
                ld.Pic + "', '" +
                ld.Des + "', " +
                ld.Isused + ", '" +
                ld.OCW + "'); ";
            int result = MySqlHelper.ExecuteNonQuery(sqlstr);
            return result;
        }

        public int UPDATE(LocalData ld)
        {
            string sqlstr = "UPDATE yxg_localdata_wgs SET b_name='" + ld.Name +
                "', addr='" + ld.Address +
                "', lng=" + ld.Lng +
                ", lat=" + ld.Lat +
                ", key_w='" + ld.Key_W +
                "', b_group='" + ld.Group +
                "', b_type='" + ld.Type +
                "', tele='" + ld.Tele +
                "', pic='" + ld.Pic +
                "', des='" + ld.Des +
                "', isused=" + ld.Isused +
                ", OCW='" + ld.OCW +
                "' WHERE id=" + ld.ID;

            int result = MySqlHelper.ExecuteNonQuery(sqlstr);
            return result;
        }

        public LocalData SELECT_BY_ID(int id)
        {
            string sqlstr = "SELECT id, b_name, addr, lng, lat, key_w, b_group, b_type, tele, pic, des, isused, OCW FROM yxg_localdata_wgs WHERE id=";

            DataSet ds = MySqlHelper.ExecuteQuery(sqlstr + id);
            DataTable dt = ds.Tables[0];

            LocalData temp = new LocalData();

            temp.ID = int.Parse(dt.Rows[0][0].ToString());
            temp.Name = dt.Rows[0][1].ToString();
            temp.Address = dt.Rows[0][2].ToString();
            temp.Lng = double.Parse(dt.Rows[0][3].ToString());
            temp.Lat = double.Parse(dt.Rows[0][4].ToString());
            temp.Key_W = dt.Rows[0][5].ToString();
            temp.Group = dt.Rows[0][6].ToString();
            temp.Type = dt.Rows[0][7].ToString();
            temp.Tele = dt.Rows[0][8].ToString();
            temp.Pic = dt.Rows[0][9].ToString();
            temp.Des = dt.Rows[0][10].ToString();
            temp.Isused = short.Parse(dt.Rows[0][11].ToString());
            temp.OCW = dt.Rows[0][12].ToString();

            return temp;
        }

        public LocalData SELECT_BY_ADDR(string addr)
        {
            string sqlstr = "SELECT id, b_name, addr, lng, lat, key_w, b_group, b_type, tele, pic, des, isused, OCW FROM yxg_localdata_wgs WHERE addr='";

            DataSet ds = MySqlHelper.ExecuteQuery(sqlstr + addr + "'");
            DataTable dt = ds.Tables[0];

            LocalData temp = new LocalData();

            temp.ID = int.Parse(dt.Rows[0][0].ToString());
            temp.Name = dt.Rows[0][1].ToString();
            temp.Address = dt.Rows[0][2].ToString();
            temp.Lng = double.Parse(dt.Rows[0][3].ToString());
            temp.Lat = double.Parse(dt.Rows[0][4].ToString());
            temp.Key_W = dt.Rows[0][5].ToString();
            temp.Group = dt.Rows[0][6].ToString();
            temp.Type = dt.Rows[0][7].ToString();
            temp.Tele = dt.Rows[0][8].ToString();
            temp.Pic = dt.Rows[0][9].ToString();
            temp.Des = dt.Rows[0][10].ToString();
            temp.Isused = short.Parse(dt.Rows[0][11].ToString());
            temp.OCW = dt.Rows[0][12].ToString();

            return temp;
        }

        public IList<LocalData> SELECT_ALL()
        {
            string sqlstr = "select id, b_name, addr, lng, lat, key_w, b_group, b_type, tele, pic, des, isused, OCW FROM yxg_localdata_wgs;";

            DataSet ds = MySqlHelper.ExecuteQuery(sqlstr);
            DataTable dt = ds.Tables[0];

            IList<LocalData> result = new List<LocalData>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LocalData temp = new LocalData();

                temp.ID = int.Parse(dt.Rows[i][0].ToString());
                temp.Name = dt.Rows[i][1].ToString();
                temp.Address = dt.Rows[i][2].ToString();
                temp.Lng = double.Parse(dt.Rows[i][3].ToString());
                temp.Lat = double.Parse(dt.Rows[i][4].ToString());
                temp.Key_W = dt.Rows[i][5].ToString();
                temp.Group = dt.Rows[i][6].ToString();
                temp.Type = dt.Rows[i][7].ToString();
                temp.Tele = dt.Rows[i][8].ToString();
                temp.Pic = dt.Rows[i][9].ToString();
                temp.Des = dt.Rows[i][10].ToString();
                temp.Isused = short.Parse(dt.Rows[i][11].ToString());
                temp.OCW = dt.Rows[i][12].ToString();

                result.Add(temp);
            }
            return result;
        }

        public IList<LocalData> SELECT_BY_ISUSED(short isused)
        {
            string sqlstr = "select id, b_name, addr, lng, lat, key_w, b_group, b_type, tele, pic, des, isused, OCW FROM yxg_localdata_wgs WHERE isused=";
            string sqlend = ";";

            DataSet ds = MySqlHelper.ExecuteQuery(sqlstr + isused + sqlend);
            DataTable dt = ds.Tables[0];

            IList<LocalData> result = new List<LocalData>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LocalData temp = new LocalData();

                temp.ID = int.Parse(dt.Rows[i][0].ToString());
                temp.Name = dt.Rows[i][1].ToString();
                temp.Address = dt.Rows[i][2].ToString();
                temp.Lng = double.Parse(dt.Rows[i][3].ToString());
                temp.Lat = double.Parse(dt.Rows[i][4].ToString());
                temp.Key_W = dt.Rows[i][5].ToString();
                temp.Group = dt.Rows[i][6].ToString();
                temp.Type = dt.Rows[i][7].ToString();
                temp.Tele = dt.Rows[i][8].ToString();
                temp.Pic = dt.Rows[i][9].ToString();
                temp.Des = dt.Rows[i][10].ToString();
                temp.Isused = short.Parse(dt.Rows[i][11].ToString());
                temp.OCW = dt.Rows[i][12].ToString();

                result.Add(temp);
            }
            return result;
        }

        public IList<LocalData> SELECT_BY_GROUP(string group)
        {
            string sqlstr = "select id, b_name, addr, lng, lat, key_w, b_group, b_type, tele, pic, des, isused, OCW FROM yxg_localdata_wgs WHERE b_group='";
            string sqlend = "';";

            DataSet ds = MySqlHelper.ExecuteQuery(sqlstr + group + sqlend);
            DataTable dt = ds.Tables[0];

            IList<LocalData> result = new List<LocalData>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LocalData temp = new LocalData();

                temp.ID = int.Parse(dt.Rows[i][0].ToString());
                temp.Name = dt.Rows[i][1].ToString();
                temp.Address = dt.Rows[i][2].ToString();
                temp.Lng = double.Parse(dt.Rows[i][3].ToString());
                temp.Lat = double.Parse(dt.Rows[i][4].ToString());
                temp.Key_W = dt.Rows[i][5].ToString();
                temp.Group = dt.Rows[i][6].ToString();
                temp.Type = dt.Rows[i][7].ToString();
                temp.Tele = dt.Rows[i][8].ToString();
                temp.Pic = dt.Rows[i][9].ToString();
                temp.Des = dt.Rows[i][10].ToString();
                temp.Isused = short.Parse(dt.Rows[i][11].ToString());
                temp.OCW = dt.Rows[i][12].ToString();

                result.Add(temp);
            }
            return result;
        }

        public IList<LocalData> SELECT_BY_KW_GROUP(string keyword, string group)
        {
            string sqlstr = "select id, b_name, addr, lng, lat, key_w, b_group, b_type, tele, pic, des, isused, OCW FROM yxg_localdata_wgs WHERE b_name like '%";
            string sqlend = "%' and b_group='" + group + "';";

            DataSet ds = MySqlHelper.ExecuteQuery(sqlstr + keyword + sqlend);
            DataTable dt = ds.Tables[0];

            IList<LocalData> result = new List<LocalData>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LocalData temp = new LocalData();

                temp.ID = int.Parse(dt.Rows[i][0].ToString());
                temp.Name = dt.Rows[i][1].ToString();
                temp.Address = dt.Rows[i][2].ToString();
                temp.Lng = double.Parse(dt.Rows[i][3].ToString());
                temp.Lat = double.Parse(dt.Rows[i][4].ToString());
                temp.Key_W = dt.Rows[i][5].ToString();
                temp.Group = dt.Rows[i][6].ToString();
                temp.Type = dt.Rows[i][7].ToString();
                temp.Tele = dt.Rows[i][8].ToString();
                temp.Pic = dt.Rows[i][9].ToString();
                temp.Des = dt.Rows[i][10].ToString();
                temp.Isused = short.Parse(dt.Rows[i][11].ToString());
                temp.OCW = dt.Rows[i][12].ToString();

                result.Add(temp);
            }
            return result;
        }

        public IList<LocalData> SELECT_BY_KW(string keyword)
        {
            string sqlstr = "select id, b_name, addr, lng, lat, key_w, b_group, b_type, tele, pic, des, isused, OCW FROM yxg_localdata_wgs WHERE b_name like '%";
            string sqlend = "%';";

            DataSet ds = MySqlHelper.ExecuteQuery(sqlstr + keyword + sqlend);
            DataTable dt = ds.Tables[0];

            IList<LocalData> result = new List<LocalData>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LocalData temp = new LocalData();

                temp.ID = int.Parse(dt.Rows[i][0].ToString());
                temp.Name = dt.Rows[i][1].ToString();
                temp.Address = dt.Rows[i][2].ToString();
                temp.Lng = double.Parse(dt.Rows[i][3].ToString());
                temp.Lat = double.Parse(dt.Rows[i][4].ToString());
                temp.Key_W = dt.Rows[i][5].ToString();
                temp.Group = dt.Rows[i][6].ToString();
                temp.Type = dt.Rows[i][7].ToString();
                temp.Tele = dt.Rows[i][8].ToString();
                temp.Pic = dt.Rows[i][9].ToString();
                temp.Des = dt.Rows[i][10].ToString();
                temp.Isused = short.Parse(dt.Rows[i][11].ToString());
                temp.OCW = dt.Rows[i][12].ToString();

                result.Add(temp);
            }
            return result;
        }
    }
}
