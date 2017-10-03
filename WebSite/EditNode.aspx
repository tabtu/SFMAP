<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditNode.aspx.cs" Inherits="EditNode" %>

<%@ Register src="Control/U_local.ascx" tagname="U_local" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="Styles/Mastermanu1.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table  class="contenttable2">
        <tr class="listtitle3"><td colspan="2">律师信息编辑界面
        </td>
       </tr>
          <tr>
            <td class="listtitle44" >
                <asp:Repeater ID="Repeater_nodelist" runat="server">
                                    <HeaderTemplate>
                                        <table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="listcontent">
                                            <td>
                                                <asp:LinkButton ID="show_localdataid" CommandName='<%#Eval("Id")%>' OnCommand="show_nodedata" runat="server" style="white-space: nowrap; text-decoration:none; " Width="100%" ForeColor="#1ea0b9"><%#Eval("Name") %></asp:LinkButton></td>
                                  </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
            </td>
            <td class="listtitle45">

                <uc1:U_local ID="U_local1" runat="server" />
                 <asp:Button ID="Button_submit" runat="server" Text="提交" OnClick="Button_submit_Click" />
              </td>
      </tr>
       
    </table>
        
    </div>
    </form>
</body>
</html>
