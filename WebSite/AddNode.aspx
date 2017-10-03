<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNode.aspx.cs" Inherits="InsertNode" %>

<%@ Register src="Control/U_local.ascx" tagname="U_local" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:U_local ID="U_localdata1" runat="server" />
        <asp:Button ID="Button_submit" runat="server" Text="提交" OnClick="Button_submit_Click" />
    </div>
    </form>

    
</body>
</html>
