using System;
using System.Collections.Generic;
using ttxy.Model;
using ttxy.DAL;

namespace ttxy.BLL
{
    public class LbsTrans
    {
        static double x_pi = 3.14159265358979324 * 3000.0 / 180.0;
        // π
        static double pi = 3.1415926535897932384626;
        // 长半轴
        static double a = 6378245.0;
        // 扁率
        static double ee = 0.00669342162296594323;

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

        /// <summary>
        /// 拷贝数据库表格并转换坐标
        /// BD09转向GCJ02
        /// localdata -> localdatagcj
        /// </summary>
        public static void copydata_bd2gcj()
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