using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

using ttxy.BLL;
using ttxy.Model;
using ttxy.DAL;
using ttxy.Security;

namespace ttxy.test
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void test4()
        {

            Hashtable ht = new Hashtable(); //创建一个Hashtable实例
            ht.Add("北京", "帝都"); //添加keyvalue键值对
            ht.Add("上海", "魔都");
            ht.Add("广州", "省会");
            ht.Add("深圳", "特区");

            string capital = (string)ht["北京"];
            Console.WriteLine(capital);
            Console.WriteLine(ht.Contains("上海")); //判断哈希表是否包含特定键,其返回值为true或false
            ht.Remove("深圳"); //移除一个keyvalue键值对
            ht.Clear(); //移除所有元素

        }

        static void test2()
        {
            string a1 = "000000";
            Console.WriteLine(md5.Md5Encode(a1));
        }

        //static void test1()
        //{
        //    DLanData dd = new DLanData();
        //    IList<LanData> tmp = dd.SELECT_ALL();
        //    for (int i = 0; i < tmp.Count; i++)
        //    {
        //        string[] gpstmp = tmp[i].GpsPoint.Split('|');
        //        tmp[i].Lng = gpstmp[0];
        //        tmp[i].Lat = gpstmp[1];

        //        dd.UPDATE(tmp[i]);
        //    }
        //    Console.WriteLine(tmp.Count);
        //    return;
        //}

        static void test0()
        {
            StreamReader sr = new StreamReader("D://1.txt");
            string content = sr.ReadToEnd();
            string[] str = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine("第 {0} 行: {1}", i + 1, str[i]);
            }
        }

        static void test()
        {
            string tt = "106.647805,26.67679";

            tt = tt.Replace(",", "|");
            Console.WriteLine(tt);
        }
    }
}
