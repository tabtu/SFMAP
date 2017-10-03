using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;


public partial class Control_U_local : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SysFunction sf = new SysFunction();
            //bindcate(sf.get_groups());
        }
    }

    //public void bindcate(IList<BGroup> tmp)
    //{
    //    PagedDataSource pds = new PagedDataSource();
    //    if (tmp != null)
    //    {
    //        pds.DataSource = tmp;
    //        this.DropDownList_group.DataSource = pds;
    //        this.DropDownList_group.DataTextField = "Name";
    //        this.DropDownList_group.DataValueField = "Id";
    //        this.DropDownList_group.DataBind();
    //    }
    //}

    public LocalData localdata
    {
        get
        {
            LocalData info = new LocalData();
            if (this.Label_id.Text != "")
            {
                info.ID = int.Parse(this.Label_id.Text);
            }
            info.Name = this.TextBox_name.Text;
            info.Address = this.TextBox_address.Text;
            info.Lng = this.S_LocalSelect1.Lng;
            info.Lat = this.S_LocalSelect1.Lat;
            info.Group = this.TextBox_group.Text;
            info.Type = this.TextBox_type.Text;
            info.Key_W = this.TextBox_keyw.Text;
            info.Tele = this.TextBox_tele.Text;
            info.Des = this.TextBox_des.Text;
            info.Pic = "";
            info.OCW = this.TextBox_exinfo.Text;
            if (this.CheckBox_isused.Checked == true) { info.Isused = 1; } else { info.Isused = 0; }

            return info;
        }
        set
        {
            this.Label_id.Text = value.ID.ToString();
            this.TextBox_name.Text = value.Name;
            this.TextBox_address.Text = value.Address;

            if (value.Lng == 0 || value.Lat == 0)
            {
                this.S_LocalSelect1.SetCenter(106.720537, 26.615896, 9);
                this.S_LocalSelect1.SetPoint(106.720537, 26.615896);
            }
            else
            {
                this.S_LocalSelect1.SetCenter(value.Lng, value.Lat, 12);
                this.S_LocalSelect1.SetPoint(value.Lng, value.Lat);
            }

            this.TextBox_group.Text = value.Group;
            this.TextBox_type.Text = value.Type;
            this.TextBox_keyw.Text = value.Key_W;
            this.TextBox_tele.Text = value.Tele;
            this.TextBox_des.Text = value.Des;

            this.TextBox_exinfo.Text = value.OCW;

            if (value.Isused == 1) { this.CheckBox_isused.Checked = true; } else { this.CheckBox_isused.Checked = false; }
        }
    }

    //private string[] cutgps(string gpspoint)
    //{
    //    try
    //    {
    //        return gpspoint.Split(',');
    //    }
    //    catch
    //    {
    //        return null;
    //    }
    //}

    //检查是否为合法GPS
    //private int isrealgps(string lng, string lat)
    //{
    //    //string s = "106.70601,26.560574";
    //    try
    //    {
    //        //string[] s1 = s.Split(',');
    //        double x = double.Parse(lng);
    //        double y = double.Parse(lat);
    //        if (x > 105 && x < 108 && y > 25 && y < 28)
    //        {
    //            return 1; //gps信息正常
    //        }
    //        else
    //        {
    //            return -1;//gps信息不在贵阳范围
    //        }
    //    }
    //    catch
    //    {
    //        return -2; //GPS信息输入格式不合法
    //    }
    //}

    // 替换分隔符（提供GPS数据坐标采取）
    //private string gpsreplace(string s)
    //{
    //    s = s.Replace(",", "|");
    //    return s;
    //}
}