namespace ttxy.DAL
{
    public class DSCfunction
    {
        /*
        /// <summary>
        /// 添加主机状态信息
        /// </summary>
        /// <param name="sch"></param>
        /// <returns></returns>
        public int INSERT_HOST(SC_HOST sch)
        {
            try
            {
                string str = "insert into HOST (HOST_ID , HOST_CODE , PASSWD , ACTIVE , COMM_DATE , COMM_VARS, STATE, STATE_DATE) values(" +
                    sch.HOST_ID + ", '" +
                    sch.HOST_CODE + "', '" +
                    sch.PASSWD + "', '" +
                    sch.ACTIVE + "', '" +
                    sch.COMM_DATE + "', '" +
                    sch.COMM_VARS + "', '" +
                    sch.STATE + "', '" +
                    sch.STATE_DATE + "');";
                return SqlHelper.ExecuteNonQuery(str);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 更新主机状态信息
        /// </summary>
        /// <param name="sch"></param>
        /// <returns></returns>
        public int UPDATE_HOST(SC_HOST sch)
        {
            try
            {
                string str = "update HOST set HOST_CODE='" +
                    sch.HOST_CODE + "', PASSWD='" +
                    sch.PASSWD + "', ACTIVE='" +
                    sch.ACTIVE + "', COMM_DATE='" +
                    sch.COMM_DATE + "', COMM_VARS='" +
                    sch.COMM_VARS + "', STATE='" +
                    sch.STATE + "', STATE_DATE='" +
                    sch.STATE_DATE + "' where HOST_ID=" +
                    sch.HOST_ID;
                return SqlHelper.ExecuteNonQuery(str);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 更新设备状态信息
        /// </summary>
        /// <param name="scn"></param>
        /// <returns></returns>
        public int UPDATE_NODE(SC_NODE scn)
        {
            try
            {
                string str = "update NODE set STATE='" +
                    scn.STATE + "" +
                    scn.STATE + "', STATE_DATE='" +
                    scn.STATE_DATE + "' where HOST_ID=" +
                    scn.HOST_ID + "and ADDR_ID='" +
                    scn.ADDR_ID + "'";
                return SqlHelper.ExecuteNonQuery(str);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 按状态(非)获取主机信息列表
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public IList<SC_HOST> SELECT_HOST_STATE_O(char state)
        {
            try
            {
                string str = "select HOST_ID , HOST_CODE , PASSWD , ACTIVE , COMM_DATE , COMM_VARS, STATE, STATE_DATE from HOST where state<>'" + state + "'";
                DataTable dt = SqlHelper.ExecuteReader(str).Tables[0];
                IList<SC_HOST> result = new List<SC_HOST>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SC_HOST info = new SC_HOST();

                    info.HOST_ID = int.Parse(dt.Rows[i][0].ToString());
                    info.HOST_CODE = dt.Rows[i][1].ToString();
                    info.PASSWD = dt.Rows[i][2].ToString();
                    info.ACTIVE = dt.Rows[i][3].ToString()[0];
                    info.COMM_DATE = DateTime.Parse(dt.Rows[i][4].ToString());
                    info.COMM_VARS = dt.Rows[i][5].ToString();
                    info.STATE = dt.Rows[i][6].ToString()[0];
                    info.STATE_DATE = DateTime.Parse(dt.Rows[i][7].ToString());

                    result.Add(info);
                }
                return result;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 按状态获取主机信息列表
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public IList<SC_HOST> SELECT_HOST_STATE(char state)
        {
            try
            {
                string str = "select HOST_ID , HOST_CODE , PASSWD , ACTIVE , COMM_DATE , COMM_VARS, STATE, STATE_DATE from HOST where state='" + state + "'";
                DataTable dt = SqlHelper.ExecuteReader(str).Tables[0];
                IList<SC_HOST> result = new List<SC_HOST>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SC_HOST info = new SC_HOST();

                    info.HOST_ID = int.Parse(dt.Rows[i][0].ToString());
                    info.HOST_CODE = dt.Rows[i][1].ToString();
                    info.PASSWD = dt.Rows[i][2].ToString();
                    info.ACTIVE = dt.Rows[i][3].ToString()[0];
                    info.COMM_DATE = DateTime.Parse(dt.Rows[i][4].ToString());
                    info.COMM_VARS = dt.Rows[i][5].ToString();
                    info.STATE = dt.Rows[i][6].ToString()[0];
                    info.STATE_DATE = DateTime.Parse(dt.Rows[i][7].ToString());

                    result.Add(info);
                }
                return result;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据HOST_ID获取主机状态信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SC_HOST SELECT_HOST_ID(int id)
        {
            try
            {
                string str = "select HOST_ID , HOST_CODE , PASSWD , ACTIVE , COMM_DATE , COMM_VARS, STATE, STATE_DATE from HOST where HOST_ID=" + id;
                DataTable dt = SqlHelper.ExecuteReader(str).Tables[0];
                SC_HOST result = new SC_HOST();
                result.HOST_ID = int.Parse(dt.Rows[0][0].ToString());
                result.HOST_CODE = dt.Rows[0][1].ToString();
                result.PASSWD = dt.Rows[0][2].ToString();
                result.ACTIVE = dt.Rows[0][3].ToString()[0];
                result.COMM_DATE = DateTime.Parse(dt.Rows[0][4].ToString());
                result.COMM_VARS = dt.Rows[0][5].ToString();
                result.STATE = dt.Rows[0][6].ToString()[0];
                result.STATE_DATE = DateTime.Parse(dt.Rows[0][7].ToString());
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取HOST下所有设备列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<SC_NODE> SELECT_HOST_ID_NODELIST(int id)
        {
            try
            {
                string str = "SELECT HOST_ID, ADDR_ID, STATE, STATE_DATE from NODE where HOST_ID=" + id + " ORDER BY STATE"; ;
                DataTable dt = SqlHelper.ExecuteReader(str).Tables[0];
                IList<SC_NODE> result = new List<SC_NODE>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SC_NODE info = new SC_NODE();

                    info.HOST_ID = int.Parse(dt.Rows[i][0].ToString());
                    info.ADDR_ID = dt.Rows[i][1].ToString();
                    info.STATE = dt.Rows[i][2].ToString()[0];
                    info.STATE_DATE = DateTime.Parse(dt.Rows[i][3].ToString());

                    result.Add(info);
                }
                return result;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据HOST_ID及ADDR_ID获取设备状态信息
        /// </summary>
        /// <param name="hostid"></param>
        /// <param name="addrid"></param>
        /// <returns></returns>
        public SC_NODE SELECT_NODE_ID(int hostid, string addrid)
        {
            try
            {
                string str = "SELECT HOST_ID, ADDR_ID, STATE, STATE_DATE from NODE WHERE HOST_ID=" + hostid + "AND ADDR_ID='" + addrid + "'"; ;
                DataTable dt = SqlHelper.ExecuteReader(str).Tables[0];
                SC_NODE result = new SC_NODE();
                result.HOST_ID = int.Parse(dt.Rows[0][0].ToString());
                result.ADDR_ID = dt.Rows[0][1].ToString();
                result.STATE = dt.Rows[0][2].ToString()[0];
                result.STATE_DATE = DateTime.Parse(dt.Rows[0][3].ToString());
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
         */
    }
}
