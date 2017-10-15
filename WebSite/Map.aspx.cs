using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;

public partial class MapMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UseFunction uf = new UseFunction();
            IList<LocalData> ls = uf.get_local_wgs("司法行政机关");
            Literal_map.Text = LbsMaker.MakeMapTDT("106.720537, 26.615896", "12", LbsMaker.MakeMapPointsTDT(ls));
            keyword.Text = "类别：司法行政机关，可按关键字查询";

        }
    }

    protected void btn_epn_Click(object sender, ImageClickEventArgs e)
    {
        UseFunction uf = new UseFunction();
        IList<LocalData> ls = new List<LocalData>();
        if (this.Label_title.Text != "" || this.Label_title.Text != null)
        {

            ls = uf.search_local_wgs(this.keyword.Text, this.Label_title.Text);
        }
        else
        {
            ls = uf.search_local_wgs(this.keyword.Text);
        }

        if (ls == null || ls.Count == 0)
        {
            Response.Write("<script language='javascript'>alert('未检索到数据');</script>");
        }
        else
        {
            this.Literal_map.Text = LbsMaker.MakeMapTDT(ls[0].Lng + ", " + ls[0].Lat, "16", LbsMaker.MakeMapPointsTDT(ls));
        }
    }

    protected void btn_cate1_Click(object sender, ImageClickEventArgs e)
    {
        this.Label_title.Text = "基层法律服务所";
        UseFunction uf = new UseFunction();
        IList<LocalData> ls = uf.get_local_wgs("基层法律服务所");
        if (ls == null || ls.Count == 0)
        {
            Response.Write("<script language='javascript'>alert('未检索到数据');</script>");
        }
        else
        {
            this.Literal_map.Text = LbsMaker.MakeMapTDT(ls[0].Lng + ", " + ls[0].Lat, "14", LbsMaker.MakeMapPointsTDT(ls));
 keyword.Text = "类别：基层法律服务所，可按关键字查询";
        }
    }

    protected void btn_cate2_Click(object sender, ImageClickEventArgs e)
    {
        this.Label_title.Text = "司法行政机关";
        UseFunction uf = new UseFunction();
        IList<LocalData> ls = uf.get_local_wgs("司法行政机关");
        if (ls == null || ls.Count == 0)
        {
            Response.Write("<script language='javascript'>alert('未检索到数据');</script>");
        }
        else
        {
            this.Literal_map.Text = LbsMaker.MakeMapTDT(ls[0].Lng + ", " + ls[0].Lat, "14", LbsMaker.MakeMapPointsTDT(ls));
       keyword.Text = "类别：司法行政机关，可按关键字查询";

        }
    }

    protected void btn_cate3_Click(object sender, ImageClickEventArgs e)
    {
        this.Label_title.Text = "法律援助中心";
        UseFunction uf = new UseFunction();
        IList<LocalData> ls = uf.get_local_wgs("法律援助中心");
        if (ls == null || ls.Count == 0)
        {
            Response.Write("<script language='javascript'>alert('未检索到数据');</script>");
        }
        else
        {
            this.Literal_map.Text = LbsMaker.MakeMapTDT(ls[0].Lng + ", " + ls[0].Lat, "14", LbsMaker.MakeMapPointsTDT(ls));
keyword.Text = "类别：法律援助中心，可按关键字查询";
        }
    }

    protected void btn_cate4_Click(object sender, ImageClickEventArgs e)
    {
        this.Label_title.Text = "司法鉴定机构";
        UseFunction uf = new UseFunction();
        IList<LocalData> ls = uf.get_local_wgs("司法鉴定机构");
        if (ls == null || ls.Count == 0)
        {
            Response.Write("<script language='javascript'>alert('未检索到数据');</script>");
        }
        else
        {
            this.Literal_map.Text = LbsMaker.MakeMapTDT(ls[0].Lng + ", " + ls[0].Lat, "14", LbsMaker.MakeMapPointsTDT(ls));
keyword.Text = "类别：司法鉴定机构，可按关键字查询";
        }
    }

    protected void btn_cate5_Click(object sender, ImageClickEventArgs e)
    {
        this.Label_title.Text = "律师事务所";
        UseFunction uf = new UseFunction();
        IList<LocalData> ls = uf.get_local_wgs("律师事务所");
        if (ls == null || ls.Count == 0)
        {
            Response.Write("<script language='javascript'>alert('未检索到数据');</script>");
        }
        else
        {
            this.Literal_map.Text = LbsMaker.MakeMapTDT(ls[0].Lng + ", " + ls[0].Lat, "14", LbsMaker.MakeMapPointsTDT(ls));
keyword.Text = "类别：律师事务所，可按关键字查询";
        }
    }

    protected void btn_cate6_Click(object sender, ImageClickEventArgs e)
    {
        this.Label_title.Text = "公证处";
        UseFunction uf = new UseFunction();
        IList<LocalData> ls = uf.get_local_wgs("公证处");
        if (ls == null || ls.Count == 0)
        {
            Response.Write("<script language='javascript'>alert('未检索到数据');</script>");
        }
        else
        {
            this.Literal_map.Text = LbsMaker.MakeMapTDT(ls[0].Lng + ", " + ls[0].Lat, "14", LbsMaker.MakeMapPointsTDT(ls));
keyword.Text = "类别：公证机构，可按关键字查询";
        }
    }
}