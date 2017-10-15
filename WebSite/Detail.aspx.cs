using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;

public partial class NodeDetail : System.Web.UI.Page
{
    private double s_lng;
    private double s_lat;
    private double e_lng;
    private double e_lat;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string url = HttpContext.Current.Request.Url.Query;
            int id = int.Parse(url.Substring(1));

            UseFunction uf = new UseFunction();
            LocalData ld = uf.get_local_wgs(id);
            e_lng = ld.Lng;
            e_lat = ld.Lat;
            this.label_title.Text = ld.Name;
            this.label_addr.Text = ld.Address;
            this.Literal_tel.Text = "<a href=\"tel:" + ld.Tele + "\">" + ld.Tele + "<i class=\"glyphicon glyphicon-phone-alt\"></i></a>";

        }
    }

    public string Get_s_Lng()
    {
        return s_lng.ToString();
    }

    public string Get_s_Lat()
    {
        return s_lat.ToString();
    }

    public string Get_e_Lng()
    {
        return e_lng.ToString();
    }

    public string Get_e_Lat()
    {
        return e_lat.ToString();
    }
}