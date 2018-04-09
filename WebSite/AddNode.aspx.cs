using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;

public partial class InsertNode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.U_localdata1.localdata = new ttxy.Model.LocalData();
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        SysFunction sf = new SysFunction();
        LocalData tmp = this.U_localdata1.localdata;
        int result = sf.add_localdata(tmp);
        double[] gcj = LbsTrans.BD09toGCJ02(tmp.Lng, tmp.Lat);
        tmp.Lng = gcj[0];
        tmp.Lat = gcj[1];
        result += sf.add_localdata_gcj(tmp);
        double[] wgs = LbsTrans.GCJ02toWGS84(tmp.Lng, tmp.Lat);
        tmp.Lng = wgs[0];
        tmp.Lat = wgs[1];
        result += sf.add_localdata_wgs(tmp);
        if (result == 3)
        {
            Response.Write("<script language='javascript'>alert('添加成功'); location.href='AddNode.aspx'</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('添加失败: 成功" + result + "条记录');");
        }
    }
}