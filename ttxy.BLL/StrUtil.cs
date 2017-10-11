﻿namespace ttxy.BLL
{
    /// <summary>
    /// Powered by Tab Tu
    /// 系统数据连接字符串
    /// </summary>
    public class StrUtil
    {
        /// <summary>
        /// MySql数据库连接字符串
        /// </summary>
        public const string sqlcon = DAL.MyDataContext.connectionString;

        // 测试点
        public const string upload = @"C:\users\ttxy\desktop\lanmap\website\upload\map\";
        public const string mainurl = "http://localhost:11281/website/";

        // 发布点
        //public const string upload = @"e:\Publish\map\upload\map\";
        //public const string mainurl = "http://www.otoforu.com/";

        // 发布点
        //public const string upload = @"E:\published\map\upload\map\";
        //public const string mainurl = "http://fmap.gzyxgkj.com/";
    }
}
