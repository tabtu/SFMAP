using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.DAL
{
    public class MyDataContext
    {
        // SqlServer Connection
        public const string db_resourse = "Data Source=localhost;Initial Catalog=yxg_landata;Persist Security Info=True;User ID=sa;Password=20202425";
        public const string db_monitor = "Data Source=localhost;Initial Catalog=yxg_firecon;Persist Security Info=True;User ID=sa;Password=20202425";

        // MySql Connection
        public const string connectionString = "server=localhost;user id=root; password=TH5112025; database=yxg_sf_map; pooling=false;charset=utf8";
        //public const string connectionString = "server=localhost;user id=yxgth; password=th*5112025; database=yxg_sf_map; pooling=false;charset=utf8";
        //public const string connectionString = "server=localhost;user id=root; password=TabTu*2425; database=yxg_sf_map; pooling=false;charset=utf8";
        //public const string connectionString = "server=my3226091.xincache1.cn;user id=my3226091; password=F5Z4f8X1; database=yxg_sf_map; pooling=false;charset=utf8";

        public static LinqDataContext GetConnection ()
        {
            return new LinqDataContext(db_resourse);//视图部分
        }
    }
}