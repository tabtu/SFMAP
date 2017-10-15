using System;
using System.Collections.Generic;
using ttxy.Model;
using ttxy.DAL;

namespace ttxy.BLL
{
    public class LbsTrans
    {
        private const double x_pi = 3.14159265358979324 * 3000.0 / 180.0;
        // π
        private const double pi = 3.1415926535897932384626;
        // 长半轴
        private const double a = 6378245.0;
        // 扁率
        private const double ee = 0.00669342162296594323;

        /// <summary>
        /// 转换坐标BD09到GCJ02
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <returns>[0]Lng; [1]Lat</returns>
        public static double[] BD09toGCJ02(double lng, double lat)
        {
            double x = lng - 0.0065;
            double y = lat - 0.006;
            double z = Math.Sqrt(x * x + y * y) - 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) - 0.000003 * Math.Cos(x * x_pi);
            double[] result = new double[2];
            double gg_lng = z * Math.Cos(theta);
            double gg_lat = z * Math.Sin(theta);
            return new double[] { gg_lng, gg_lat };
        }

        public static double[] GCJ02toWGS84(double lng, double lat)
        {
            var dlat = transformlat(lng - 105.0, lat - 35.0);
            var dlng = transformlng(lng - 105.0, lat - 35.0);
            var radlat = lat / 180.0 * pi;
            var magic = Math.Sin(radlat);
            magic = 1 - ee * magic * magic;
            var sqrtmagic = Math.Sqrt(magic);
            dlat = (dlat * 180.0) / ((a * (1 - ee)) / (magic * sqrtmagic) * pi);
            dlng = (dlng * 180.0) / (a / sqrtmagic * Math.Cos(radlat) * pi);
            var mglat = lat + dlat;
            var mglng = lng + dlng;
            return new double[] { lng * 2 - mglng, lat * 2 - mglat };
        }

        private static double transformlat(double lng, double lat)
        {
            var ret = -100.0 + 2.0 * lng + 3.0 * lat + 0.2 * lat * lat + 0.1 * lng * lat + 0.2 * Math.Sqrt(Math.Abs(lng));
            ret += (20.0 * Math.Sin(6.0 * lng * pi) + 20.0 * Math.Sin(2.0 * lng * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(lat * pi) + 40.0 * Math.Sin(lat / 3.0 * pi)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(lat / 12.0 * pi) + 320 * Math.Sin(lat * pi / 30.0)) * 2.0 / 3.0;
            return ret;
        }

        private static double transformlng(double lng, double lat)
        {
            var ret = 300.0 + lng + 2.0 * lat + 0.1 * lng * lng + 0.1 * lng * lat + 0.1 * Math.Sqrt(Math.Abs(lng));
            ret += (20.0 * Math.Sin(6.0 * lng * pi) + 20.0 * Math.Sin(2.0 * lng * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(lng * pi) + 40.0 * Math.Sin(lng / 3.0 * pi)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(lng / 12.0 * pi) + 300.0 * Math.Sin(lng / 30.0 * pi)) * 2.0 / 3.0;
            return ret;
        }

        /// <summary>
        /// 拷贝数据库表格并转换坐标
        /// BD09转向WGS84
        /// localdata -> localdatawgs
        /// </summary>
        public void copydata_bd2wgs()
        {
            DLocalData dld = new DLocalData();
            DLocalDataWGS dldwgs = new DLocalDataWGS();
            IList<LocalData> bd = dld.SELECT_ALL();
            Console.WriteLine("开始转换......");
            int count = 0;
            foreach (LocalData tmp in bd)
            {
                double[] gcj = BD09toGCJ02(tmp.Lng, tmp.Lat);
                double[] wgs = GCJ02toWGS84(gcj[0], gcj[1]);
                tmp.Lng = wgs[0];
                tmp.Lat = wgs[1];
                int t = dldwgs.INSERT(tmp);
                if (t > 0) { count++; }
            }
            Console.WriteLine("成功执行了：{0}行。", count);
        }

        /// <summary>
        /// 拷贝数据库表格并转换坐标
        /// BD09转向GCJ02
        /// localdata -> localdatagcj
        /// </summary>
        public void copydata_bd2gcj()
        {
            DLocalData dld = new DLocalData();
            DLocalDataGCJ dldgcj = new DLocalDataGCJ();
            IList<LocalData> bd = dld.SELECT_ALL();
            Console.WriteLine("开始转换......");
            int count = 0;
            foreach(LocalData tmp in bd)
            {
                double[] gcj = BD09toGCJ02(tmp.Lng, tmp.Lat);
                tmp.Lng = gcj[0];
                tmp.Lat = gcj[1];
                int t = dldgcj.INSERT(tmp);
                if (t > 0) { count++; }
            }
            Console.WriteLine("成功执行了：{0}行。", count);
        }
    }
}