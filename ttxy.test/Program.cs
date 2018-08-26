using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            checkidqueue();
            //synFromWGS_BaseonAddr08222018();
            //changeData08222018();
            //trimAddr();
            //transLBS();
            //showconver();
            //showhtml();
            //showpoints();
            //readhtml();
            //showconvert(116.40093, 39.90313);
        }


        static void checkidqueue()
        {
            DLocalDataWGS wgs = new DLocalDataWGS();
            IList<LocalData> ldwgs = wgs.SELECT_ALL();

            for(int i = 0; i < ldwgs.Count - 1; i++)
            {
                if (ldwgs[i].ID + 1 != ldwgs[i+1].ID)
                {
                    Console.WriteLine(ldwgs[i].ID);
                }
            }
        }

        static void synFromWGS_BaseonAddr08222018()
        {
            DLocalData dld = new DLocalData();
            DLocalDataGCJ gcj = new DLocalDataGCJ();
            DLocalDataWGS wgs = new DLocalDataWGS();
            IList<LocalData> ldwgs = wgs.SELECT_ALL();

            int countName = 0;
            int countTele = 0;
            foreach(LocalData ele in ldwgs)
            {
                LocalData edd = dld.SELECT_BY_ADDR(ele.Address);
                LocalData edg = gcj.SELECT_BY_ADDR(ele.Address);
                if (ele.Name != edd.Name)
                {
                    edd.Name = ele.Name;
                    edg.Name = ele.Name;
                    dld.UPDATE(edd);
                    gcj.UPDATE(edg);
                    countName++;
                }
                if (ele.Tele != edd.Tele)
                {
                    edd.Tele = ele.Tele;
                    edg.Tele = ele.Tele;
                    dld.UPDATE(edd);
                    gcj.UPDATE(edg);
                    countTele++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Name changes: " + countName);
            Console.WriteLine("Telenum changes: " + countTele);
        }

        static void changeData08222018()
        {
            StreamReader sr = new StreamReader("C://ttxy/download/script.txt", Encoding.UTF8);
            String line = sr.ReadToEnd();
            IList<LocalData> upd = new List<LocalData>();
            if (line != null)
            {
                String[] list = line.Split(';');
                foreach (String element in list)
                {
                    String[] s = element.Split('#');
                    if (s[0] == "")
                    {
                        Console.WriteLine(element);
                    }
                    else
                    {
                        LocalData tmp = new LocalData();
                        tmp.ID = int.Parse(s[0]);
                        tmp.Name = s[1];
                        tmp.Address = s[2];
                        tmp.Tele = s[8];
                        upd.Add(tmp);
                    }
                }
                Console.WriteLine(upd.Count);

                DLocalDataWGS dldw = new DLocalDataWGS();
                int countName = 0;
                int countTele = 0;
                foreach(LocalData eld in upd)
                {
                    if (eld.ID != 0)
                    {
                        LocalData stmp = dldw.SELECT_BY_ID(eld.ID);
                        if (eld.Name != stmp.Name)
                        {
                            stmp.Name = eld.Name;
                            dldw.UPDATE(stmp);
                            countName++;
                        }
                        if (eld.Tele != stmp.Tele)
                        {
                            stmp.Tele = eld.Tele;
                            dldw.UPDATE(stmp);
                            countTele++;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Name Change: " + countName);
                Console.WriteLine("Telenum Change: " + countTele);

                //Console.WriteLine(line.ToString());
                //Console.WriteLine(list[0]);
                //Console.WriteLine(list[1]);
                //Console.WriteLine(list.Length);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static void trimAddr()
        {
            //DLocalDataGCJ dldgcj = new DLocalDataGCJ();
            //LocalData tp = dldgcj.SELECT_BY_ID(266);
            //if (tp.Address.Contains("\r\n"))
            //{
            //    Console.WriteLine("true");
            //}
            //if (tp.Address.Contains("\""))
            //{
            //    Console.WriteLine("true//////");
            //}
            //Console.WriteLine(tp.Address.Replace("\r\n", "").Replace("\"", ""));

            DLocalData dld = new DLocalData();
            IList<LocalData> ld = dld.SELECT_ALL();
            for (int i = 0; i < ld.Count; i++)
            {
                if (ld[i].Address.Contains("\r\n"))
                {
                    Console.Write("localdata: " + ld[i].ID + ";");
                    ld[i].Address = ld[i].Address.Replace("\r\n", "").Replace("\"", "");
                    dld.UPDATE(ld[i]);
                }
            }
            Console.WriteLine();

            DLocalDataGCJ dldgcj = new DLocalDataGCJ();
            IList<LocalData> ldgcj = dldgcj.SELECT_ALL();
            for (int i = 0; i < ldgcj.Count; i++)
            {
                if (ldgcj[i].Address.Contains("\r\n"))
                {
                    Console.Write("localdata_gcj: " + ldgcj[i].ID + ";");
                    ldgcj[i].Address = ldgcj[i].Address.Replace("\r\n", "").Replace("\"", "");
                    dldgcj.UPDATE(ldgcj[i]);
                }
            }
            Console.WriteLine();

            DLocalDataWGS dldwgs = new DLocalDataWGS();
            IList<LocalData> ldwgs = dldwgs.SELECT_ALL();
            for (int i = 0; i < ldwgs.Count; i++)
            {
                if (ldwgs[i].Address.Contains("\r\n"))
                {
                    Console.Write("localdata_wgs: " + ldwgs[i].ID + ";");
                    ldwgs[i].Address = ldwgs[i].Address.Replace("\r\n", "").Replace("\"", "");
                    dldwgs.UPDATE(ldwgs[i]);
                }
            }
            Console.WriteLine();
        }

        static void showconver()
        {
            double lng = 116.403945;
            double lat = 39.915122;
            double[] tdt = LbsTrans.BD09toGCJ02(lng, lat);
            Console.WriteLine(tdt[0] + ", " + tdt[1]);
        }

        static void showhtml()
        {
            UseFunction uf = new UseFunction();
            IList<LocalData> ls = uf.get_local("司法行政机关");
            string html = LbsMaker.MakeMapTDT("106.720537, 26.615896", "12", LbsMaker.MakeMapPointsTDT(ls));
            File.WriteAllText("C:/ttxy/desktop/lbs/mapTDT.html", html);
            Console.WriteLine(html);
        }

        static void showpoints()
        {
            DLocalDataGCJ dd = new DLocalDataGCJ();
            IList<LocalData> tt = dd.SELECT_ALL();
            string ss = LbsMaker.MakeMapPointsTDT(tt);
            //string ss = LbsMaker.MakeMapPoints(tt);
            File.WriteAllText("C:/ttxy/desktop/lbs/points.txt", ss);
            Console.WriteLine(ss);
        }

        static void showconvert(double lng, double lat)
        {
            double[] ct = LbsTrans.BD09toGCJ02(106.720537, 26.615896);
            Console.WriteLine(ct[0] + "   " + ct[1]);
        }

        static void readhtml()
        {
            String html = File.ReadAllText("C:/ttxy/desktop/lbs/new.html");
            Console.WriteLine(html);
        }

        static void testcontent()
        {
            double[] ct = LbsTrans.BD09toGCJ02(106.720537, 26.615896);
            UseFunction uf = new UseFunction();
            IList<LocalData> ls = uf.get_local("司法行政机关");
            string tmp = LbsMaker.MakeMap(ct[0] + ", " + ct[1], "12", LbsMaker.MakeMapPoints(ls));
            File.WriteAllText("C:/ttxy/desktop/lbs/test.txt", tmp);
            Console.WriteLine(tmp);
        }

        /// <summary>
        /// 调用转换坐标
        /// </summary>
        static void transLBS()
        {
            LbsTrans lt = new LbsTrans();
            lt.copydata_bd2gcj();
            Console.WriteLine("BD09 -> GCJ02   completed");
            lt.copydata_bd2wgs();
            Console.WriteLine("BD09 -> WGS84   completed");
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
