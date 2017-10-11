using System.Collections.Generic;
using ttxy.Model;
using ttxy.DAL;

namespace ttxy.BLL
{
    public class SysFunction
    {
        public int add_localdata(LocalData ld)
        {
            DLocalData dld = new DLocalData();
            return dld.INSERT(ld);
        }

        public int edit_localdata(LocalData ld)
        {
            DLocalData dld = new DLocalData();
            return dld.UPDATE(ld);
        }

        public IList<BGroup> get_groups()
        {
            DGroup dg = new DGroup();
            return dg.SELECT_ALL();
        }
    }
}
