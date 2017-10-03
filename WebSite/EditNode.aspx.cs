using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;

public partial class EditNode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.U_local1.Visible = false;
            UseFunction uf = new UseFunction();
            bindlist(uf.get_local());
        }
    }


    private void bindlist(IList<LocalData> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.Repeater_nodelist.DataSource = pds;
            this.Repeater_nodelist.DataBind();
        }
    }

    protected void show_nodedata(object sender, CommandEventArgs e)
    {
        this.U_local1.Visible = true;
        UseFunction uf = new UseFunction();
        this.U_local1.localdata = uf.get_local(int.Parse(e.CommandName.ToString()));
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        SysFunction sf = new SysFunction();
        int result = sf.edit_localdata(this.U_local1.localdata);
        if (result != 0)
        {
            Response.Write("<script language='javascript'>alert('修改成功'); location.href='EditNode.aspx'</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('修改失败');");
        }
    }
}