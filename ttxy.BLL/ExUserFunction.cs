using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ttxy.DAL;
using ttxy.Model;

namespace ttxy.BLL
{
    public class ExUserFunction
    {
        private DMembers dm = new DMembers();
        private DOrgan dorg = new DOrgan();
        private DLog dl = new DLog();
        private DArea da = new DArea();
        private DLanData dld = new DLanData();
        private DLanDataHistory dldh = new DLanDataHistory();

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public Members userLogin(Members member)
        {
            try
            {
                Members result = dm.SELECT_BY_ACCOUNT_ISUSED(member.Account,true);
                if (result.Password == member.Password)
                {
                    result.Password = result.Account;
                    return result;
                }
                else
                {
                    member.Password = null;
                    return member;
                } 
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Members getUser(int id)
        {
            try
            {
                Members result = dm.SELECT_BY_ID(id);
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 模糊搜索用户
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IList<Members> getMemberList(string name)
        {
            try
            {
                IList<Members> result = new List<Members>();
                if (name == "")
                {
                   result = dm.SELECT_ALL();
                }
                else
                {
                    result = dm.LIKE_BY_NAME(name);
                }
                
                return result;
            }
            catch
            {
                return null;
            }
        }

        ///// <summary>
        ///// 根据机构编码查询人员
        ///// </summary>
        ///// <param name="organ"></param>
        ///// <returns></returns>
        //public IList<Members> getOrganMemberList (short organ)
        //{
        //    try
        //    {
        //        IList<Members> result = dm.SELECT_ORGAN(organ);
        //        return result;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// 增加角色资料函数
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        public int addMember(Members tmp, string usid)
        {
            try
            {
                int result = dm.INSERT(tmp);

                if (usid != "0")
                {
                    Log log = new Log();
                    log.Tablename = "Members";
                    log.Tableid = result;
                    log.Mid = Members.newMembers(int.Parse(usid));
                    log.Datetime = DateTime.Now;
                    log.Discription = "增加角色资料";
                    dl.INSERT(log);
                }

                return result;
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 更新角色资料函数(慎用)
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        public int updateMember(Members tmp, string usid)
        {
            try
            {
                int result = dm.UPDATE(tmp);

                Log log = new Log();
                log.Tablename = "Members";
                log.Tableid = result;
                log.Mid = Members.newMembers(int.Parse(usid));
                log.Datetime = DateTime.Now;
                log.Discription = "更新角色资料";
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 物理删除角色资料函数
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        public int deleteMember(Members tmp)
        {
            try
            {
                int result = dm.Xqx_DELETE(tmp);
                return result;
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 修改角色密码函数
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        public bool changePassword(Members member)
        {

            try
            {
                Members tmp = dm.SELECT_BY_ID(member.Id);
                if (tmp.Password == member.Name)
                {
                    tmp.Password = member.Password;
                    dm.UPDATE(tmp);

                    Log log = new Log();
                    log.Tablename = "Members";
                    log.Tableid = member.Id;
                    log.Mid = member;
                    log.Datetime = DateTime.Now;
                    log.Discription = "修改角色密码";
                    dl.INSERT(log);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 初始化角色密码函数
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        public int InitePassword(int id)
        {
            try
            {
                Members tmp = dm.SELECT_BY_ID(id);
                tmp.Password = "123";
                int result = dm.UPDATE(tmp);

                Log log = new Log();
                log.Tablename = "Members";
                log.Tableid = id;
                log.Mid = Members.newMembers(id);
                log.Datetime = DateTime.Now;
                log.Discription = "修改角色密码(初始化)";
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return -2;
            }
        }

        /// <summary>
        /// 根据使用这USID获取可维护机构列表
        /// </summary>
        /// <param name="usid">USID</param>
        /// <returns></returns>
        public IList<Organ> getOrganlist_usid(string usid)
        {
            try
            {
                Members orap = dm.SELECT_BY_ID(int.Parse(usid));
                IList<Organ> result = new List<Organ>();
                if (orap.Limit == 1)
                {
                    result = dorg.SELECT_ALL();
                }
                else
                {
                    Organ temp = dorg.SELECT_BY_ID(0);
                    result.Add(temp);
                    temp = dorg.SELECT_BY_ID(orap.Oid.Id);
                    result.Add(temp);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <returns>机构类型list</returns>
        public IList<Organ> getOrganlist()
        {
            try
            {
                IList<Organ> result = dorg.SELECT_ALL();
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据部门ID获取部门
        /// </summary>
        /// <returns>部门</returns>
        public Organ getOrgan_by_id(short id)
        {
            try
            {
                Organ result = dorg.SELECT_BY_ID(id);
                return result;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 获取区域构列表
        /// </summary>
        /// <returns>区域类型list</returns>
        public IList<Area> getArealist()
        {
            try
            {
                IList<Area> result = da.SELECT_ISUSED(true);
                return result;
            }
            catch
            {
                return null;
            }
        }

                /// <summary>
        /// 获取分区域构列表
        /// </summary>
        /// <returns>区域类型list</returns>
        public IList<Area> getExtArealist()
        {
            try
            {
                IList<Area> result = da.SELECT_ISUSED_EXT(true);
                return result;
            }
            catch
            {
                return null;
            }
        }
        

        /// <summary>
        /// 根据ID获取区域
        /// </summary>
        /// <returns>区域</returns>
        public Area getArea_by_id(short id)
        {
            try
            {
                Area result = da.SELECT_BY_ID(id);
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据区域ID获取坐标点list
        /// </summary>
        /// <returns>坐标点list</returns>
        public IList<LanData> getLandatalist_by_areaid(short id)
        {
            try
            {
                IList<LanData> result = dld.SELECT_BY_AREAID(id,true);
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指标列表
        /// </summary>
        /// <param name="name">模糊小区名称</param>
        /// <returns>指标类型list</returns>
        public IList<LanData> getLandatalist(string name)
        {
            try
            {
                IList<LanData> result = new List<LanData>();
                //if (name == "")
                //{
                //    result = dld.SELECT_ALL();
                //}
                result = dld.SELECT_LIKE_NAME(name);
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 插入landata数据
        /// </summary>
        /// <param name="temp">表单内容</param>
        /// <returns>物理主码id</returns>
        public long insert_landata(LanData temp, int userid)
        {
            try
            {
                int result = dld.INSERT(temp);

                LanDataHistory tmp = new LanDataHistory();
                tmp.LanDataID = result;
                tmp.ZhuHuLiang = temp.ZhuHuLiang;
                tmp.RuZhuLv = temp.RuZhuLv;
                tmp.JX_DianXin = temp.JX_DianXin;
                tmp.JX_LianTong = temp.JX_LianTong;
                tmp.JX_YiDong = temp.JX_YiDong;
                tmp.DuanKouShu = temp.DuanKouShu;
                tmp.ShiZhuangShu = temp.ShiZhuangShu;
                tmp.JingZhengPingJi = temp.JingZhengPingJi;

                tmp.Datetime = DateTime.Now;
                dldh.INSERT(tmp);

                Log log = new Log();
                log.Tablename = "LanData";
                log.Tableid = result;
                log.Mid = Members.newMembers(userid);
                log.Datetime = DateTime.Now;
                log.Discription = "添加节点数据(LanData)";
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新landata数据
        /// </summary>
        /// <param name="temp">表单内容</param>
        /// <returns>物理主码id</returns>
        public int update_landata(LanData temp, int userid)
        {
            try
            {
                int result = dld.UPDATE(temp);

                LanDataHistory tmp = new LanDataHistory();
                tmp.LanDataID = result;
                tmp.ZhuHuLiang = temp.ZhuHuLiang;
                tmp.RuZhuLv = temp.RuZhuLv;
                tmp.JX_DianXin = temp.JX_DianXin;
                tmp.JX_LianTong = temp.JX_LianTong;
                tmp.JX_YiDong = temp.JX_YiDong;
                tmp.DuanKouShu = temp.DuanKouShu;
                tmp.ShiZhuangShu = temp.ShiZhuangShu;
                tmp.JingZhengPingJi = temp.JingZhengPingJi;
                tmp.Datetime = DateTime.Now;
                dldh.INSERT(tmp);

                Log log = new Log();
                log.Tablename = "LanData";
                log.Tableid = result;
                log.Mid = Members.newMembers(userid);
                log.Datetime = DateTime.Now;
                log.Discription = "更新节点数据(LanData)";
                dl.INSERT(log);

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 主码id获取目标行
        /// </summary>
        /// <param name="id">主码id</param>
        /// <returns>目标行数据</returns>
        public LanData getLandata_by_id(int id)
        {
            try
            {
                LanData result = dld.SELECT_BY_ID(id);
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据关键字和区域获取指标数据链
        /// </summary>
        /// <param name="id">关键字key</param>
        /// <param name="id">区域id</param>
        /// <returns>目标行数据</returns>
        public IList<LanData> getLandata_by_key_areaid(string name, short aid)
        {
            try
            {
                IList<LanData> keyresult = dld.SELECT_LIKE_NAME(name);
                IList<LanData> areaidresult = dld.SELECT_BY_AREAID(aid);
                IList<LanData> result = dld.INTERSECTION(keyresult, areaidresult);
                return result;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取全部区域内容
        /// </summary>
        /// <param name="tf"></param>
        /// <returns></returns>
        public IList<Area> getArea_All(bool tf)
        {
            try
            {
                return da.SELECT_ISUSED_EXT(tf);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取全部区域Landata数据
        /// </summary>
        /// <param name="tf"></param>
        /// <returns></returns>
        public IList<LanData> getLandata_All(bool tf)
        {
            try
            {
                return dld.SELECT_ALL();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据小区名获取landata数据，避免重复数据
        /// </summary>
        /// <param name="tf">小区名称</param>
        /// <returns></returns>
        public LanData getLandata_by_name(string name)
        {
            try
            {
                LanData result = dld.SELECT_BY_NAME(name);
                return result;
            }
            catch
            {
                return null;
            }
        }

    }
}
