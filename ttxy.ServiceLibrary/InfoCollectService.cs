using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using ttxy.Model;
using ttxy.BLL;

namespace ttxy.Host
{
    public class ttxyService : IttxyServiceJson, IttxyServiceXml
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public string echo (string Message)
        {
            return Message + Message;
        }
    }
}
