using System.Collections.Generic;
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
        public IList<LocalData> get_local_wgs()
        {
            DLocalDataWGS dld = new DLocalDataWGS();
            return dld.SELECT_ALL();
        }

        public IList<LocalData> get_local(string group)
        {
            DLocalData dld = new DLocalData();
            return dld.SELECT_BY_GROUP(group);
        }

        public IList<LocalData> get_local_wgs(string group)
        {
            DLocalDataWGS wgs = new DLocalDataWGS();
            return wgs.SELECT_BY_GROUP(group);
        }

        public IList<LocalData> get_local(bool isused)
        {
            DLocalData dld = new DLocalData();
            return dld.SELECT_BY_ISUSED(1);
        }

        public IList<LocalData> get_local_wgs(bool isused)
        {
            DLocalDataWGS dld = new DLocalDataWGS();
            return dld.SELECT_BY_ISUSED(1);
        }

        public IList<LocalData> search_local(string kw)
        {
            DLocalData dld = new DLocalData();
            return dld.SELECT_BY_KW(kw);
        }

        public IList<LocalData> search_local_wgs(string kw)
        {
            DLocalDataWGS dld = new DLocalDataWGS();
            return dld.SELECT_BY_KW(kw);
        }

        public IList<LocalData> search_local(string kw, string group)
        {
            DLocalData dld = new DLocalData();
            return dld.SELECT_BY_KW_GROUP(kw, group);
        }

        public IList<LocalData> search_local_wgs(string kw, string group)
        {
            DLocalDataWGS dld = new DLocalDataWGS();
            return dld.SELECT_BY_KW_GROUP(kw, group);
        }

        public LocalData get_local(int id)
        {
            DLocalData dld = new DLocalData();
            return dld.SELECT_BY_ID(id);
        }

        public LocalData get_local_wgs(int id)
        {
            DLocalDataWGS dld = new DLocalDataWGS();
            return dld.SELECT_BY_ID(id);
        }
    }
}
