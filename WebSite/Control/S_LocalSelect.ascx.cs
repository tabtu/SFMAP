using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class S_Control_LocalSelect : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 经度
    /// </summary>
    public double Lng
    {
        get
        {
            return double.Parse(this.Request.Form["hidden_lng"].ToString());
        }
    }

    /// <summary>
    /// 纬度
    /// </summary>
    public double Lat
    {
        get
        {
            return double.Parse(this.Request.Form["hidden_lat"].ToString());
        }
    }

    /// <summary>
    /// 初始化小地图
    /// </summary>
    /// <param name="lng">经度</param>
    /// <param name="lat">纬度</param>
    /// <param name="zoom">放大级别9-14</param>
    public void SetCenter(double lng, double lat, int zoom)
    {
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "setup", "<script>setup('" + lng + "','" + lat + "','" + zoom +"')</script>");
    }

    /// <summary>
    /// 初始化点
    /// </summary>
    /// <param name="lng">经度</param>
    /// <param name="lat">纬度</param>
    public void SetPoint(double lng, double lat)
    {
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "addPoint", "<script>addPoint('" + lng + "','" + lat + "')</script>");
    }
}