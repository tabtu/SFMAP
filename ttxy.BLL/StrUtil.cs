namespace ttxy.BLL
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
        //public const string upload = @"C:\users\ttxy\desktop\lanmap\website\upload\map\";
        //public const string mainurl = "http://localhost:11281/";

        // 发布点
        public const string upload = @"C:\published\map\upload\map\";
        //public const string mainurl = "http://sfmap.gzyxgkj.com:10001/";
        public const string mainurl = "http://sfmap.otoforu.com:10001/";

        public const string key_TDT = "d4cb392c74129e0daf11d3f84d812f14";
        public const string key_BD = "7jX0fH8U0LAyWrd6Lp4HQXYalxfXvZvk";
    }
}
