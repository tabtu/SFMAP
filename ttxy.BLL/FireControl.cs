using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ttxy.Model;
using ttxy.DAL;

namespace ttxy.BLL
{
    /// <summary>
    /// Powered by Tab Tu
    /// 火警设备监控类库
    /// </summary>
    public class FireControl
    {
        /// <summary>
        /// 获取监控数据表
        /// </summary>
        /// <returns></returns>
        public IList<EquipState> GetEquipCurrent()
        {
            try
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取当前设备状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EquipState GetEquipCurrent(long id)
        {
            try
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取当前设备状态
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public IList<EquipData> GetEquipCurrent(IList<EquipData> info)
        {
            try
            {
                for (int i = 0; i < info.Count; i++)
                {
                    info[i].Status = GetEquipCurrent(info[i].Id).State;
                }
                return info;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据火警告警设备获取告警建筑
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public IList<LanData> GetFireTarget(IList<EquipData> info)
        {
            UseFunc uf = new UseFunc();
            IList<EquipData> tmp = new List<EquipData>();
            for (int i = 0; i < info.Count; i++)
            {
                tmp.Add(uf.GetEquipdata(info[i].Id));
            }

            IList<LanData> result = new List<LanData>();
            for (int j = 0; j < tmp.Count; j++)
            {
                LanData lt = uf.GetLandata(uf.GetNodedata(tmp[j].Nid).Lid);
                bool isexist = false;
                for (int k = 0; k < result.Count; k++)
                {
                    if (result[k].ID == lt.ID)
                    {
                        isexist = true;
                        break;
                    }
                }
                if (isexist == false)
                {
                    result.Add(lt);
                }
            }
            return result;
        }
    }
}