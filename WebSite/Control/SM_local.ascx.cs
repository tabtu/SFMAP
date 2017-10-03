using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using ttxy.BLL;

public partial class Control_SM_area : System.Web.UI.UserControl
{
    private const string sqlcon = StrUtil.sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        SqlConnection conn = new SqlConnection(sqlcon);
        SqlDataAdapter adq = new SqlDataAdapter("select id, b_name, addr, lng, lat, key_w, b_group, b_type, tele, pic, des, isused, OCW FROM yxg_localdata", conn);
        DataSet dataset = new DataSet();
        adq.Fill(dataset, "yxg_localdata");
        GridView1.DataSource = dataset;
        GridView1.DataKeyNames = new String[] { "id" };
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Bind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection conn = new SqlConnection(sqlcon);
        SqlCommand comm = new SqlCommand("delete from yxg_localdata where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'", conn);
        conn.Open();
        try
        {
            int i = Convert.ToInt32(comm.ExecuteNonQuery());
            if (i > 0)
            {
                Response.Write("<script language=javascript>alert('删除成功！')</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('删除失败！')</script>");
            }
            Bind();
        }
        catch (Exception erro)
        {
            Response.Write("错误信息:" + erro.Message);
        }
        finally
        {
            conn.Close();
        }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text.ToString().Trim();
        string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Trim();
        string addr = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Trim();
        string lng = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Trim();
        string lat = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString().Trim();
        string key_w = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString().Trim();
        string group = ((TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text.ToString().Trim();
        string type = ((TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0]).Text.ToString().Trim();
        string tele = ((TextBox)GridView1.Rows[e.RowIndex].Cells[8].Controls[0]).Text.ToString().Trim();
        string pic = ((TextBox)GridView1.Rows[e.RowIndex].Cells[9].Controls[0]).Text.ToString().Trim();
        string des = ((TextBox)GridView1.Rows[e.RowIndex].Cells[10].Controls[0]).Text.ToString().Trim();
        string OCW = ((TextBox)GridView1.Rows[e.RowIndex].Cells[12].Controls[0]).Text.ToString().Trim();

        string isu = ((CheckBox)GridView1.Rows[e.RowIndex].Cells[11].Controls[0]).Checked.ToString().Trim();
        SqlConnection conn = new SqlConnection(sqlcon);

        SqlCommand comm = new SqlCommand("UPDATE yxg_localdata SET b_name='" + name +
                "', addr='" + addr +
                "', lng=" + lng +
                ", lat=" + lat +
                ", key_w='" + key_w +
                "', b_group='" + group +
                "', b_type='" + type +
                "', tele='" + tele +
                "', pic='" + pic +
                "', des='" + des +
                "', isused=" + isu +
                ", OCW='" + OCW +
                "' WHERE id=" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'", conn);
        conn.Open();
        try
        {
            int i = Convert.ToInt32(comm.ExecuteNonQuery());
            if (i > 0)
            {
                Response.Write("<script language=javascript>alert('保存成功！')</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('保存失败！')</script>");
            }
            GridView1.EditIndex = -1;
            Bind();
        }
        catch (Exception erro)
        {
            Response.Write("错误信息:" + erro.Message);
        }
        finally
        {
            conn.Close();
        }
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }

    protected void Button_add_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(sqlcon);
        SqlCommand comm = new SqlCommand("INSERT INTO yxg_localdata (b_name, addr, lng, lat, key_w, b_group, b_type, tele, pic, des, isused, OCW)VALUES('', '', 0, 0, '', '', '', '', '', '', 0, '')", conn);
        conn.Open();
        try
        {
            int i = Convert.ToInt32(comm.ExecuteNonQuery());
            Bind();
        }
        catch (Exception erro)
        {
            Response.Write("错误信息:" + erro.Message);
        }
        finally
        {
            conn.Close();
        }
    }
}