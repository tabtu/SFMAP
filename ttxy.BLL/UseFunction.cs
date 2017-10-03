using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ttxy.Model;
using ttxy.DAL;

namespace ttxy.BLL
{
    public class UseFunction
    {
        public IList<LocalData> get_local()
        {
            DLocalData dld = new DLocalData();
            return dld.SELECT_ALL();
        }

        public IList<LocalData> get_local(string group)
        {
            DLocalData dld = new DLocalData();
            return dld.SELECT_BY_GROUP(group);
        }

        public IList<LocalData> get_local(bool isused)
        {
            DLocalData dld = new DLocalData();
            return dld.SELECT_BY_ISUSED(1);
        }

        public IList<LocalData> search_local(string kw)
        {
            DLocalData dld = new DLocalData();
            return dld.SELECT_BY_KW(kw);
        }

        public IList<LocalData> search_local(string kw, string group)
        {
            DLocalData dld = new DLocalData();
            return dld.SELECT_BY_KW_GROUP(kw, group);
        }

        public LocalData get_local(int id)
        {
            DLocalData dld = new DLocalData();
            return dld.SELECT_BY_ID(id);
        }

        public string Search(string name)
        {
            var json = "fortest";//获取数据
            return json;
        }
    }
}
