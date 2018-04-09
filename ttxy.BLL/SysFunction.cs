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

        public int add_localdata_gcj(LocalData ld)
        {
            DLocalDataGCJ dldgcj = new DLocalDataGCJ();
            return dldgcj.INSERT(ld);
        }

        public int edit_localdata_gcj(LocalData ld)
        {
            DLocalDataGCJ dldgcj = new DLocalDataGCJ();
            return dldgcj.UPDATE(ld);
        }

        public int add_localdata_wgs(LocalData ld)
        {
            DLocalDataWGS dldwgs = new DLocalDataWGS();
            return dldwgs.INSERT(ld);
        }

        public int edit_localdata_wgs(LocalData ld)
        {
            DLocalDataWGS dldwgs = new DLocalDataWGS();
            return dldwgs.UPDATE(ld);
        }

        public IList<BGroup> get_groups()
        {
            DGroup dg = new DGroup();
            return dg.SELECT_ALL();
        }
    }
}
