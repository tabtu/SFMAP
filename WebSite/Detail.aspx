<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detail.aspx.cs" Inherits="Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Detail</title>
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/MapMain.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/MapMain.css" />
    <link  rel="stylesheet"type="text/css" href="Styles/bootstrap.min.css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="menu" id="menu">
	    <div></div>
	</div>
        <div id="map">
            <asp:Label ID="Label_title" runat="server" Visible="False"></asp:Label>
        </div>
        
        <div>
            <asp:Label ID="Label_name" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label_tel" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label_addr" runat="server"></asp:Label>
            <br />
        </div>
        <div>
            <asp:Literal ID="Literal_map" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
