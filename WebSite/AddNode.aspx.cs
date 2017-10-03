using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;

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
        int result = sf.add_localdata(this.U_localdata1.localdata);
        if (result != 0)
        {
            Response.Write("<script language='javascript'>alert('添加成功'); location.href='AddNode.aspx'</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('添加失败');");
        }
    }
}