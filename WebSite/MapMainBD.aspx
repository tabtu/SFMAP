<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapMainBD.aspx.cs" Inherits="MapMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>贵阳法治地图</title>
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/MapMain.js"></script>
    <%--<script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>--%>
    <link rel="stylesheet" type="text/css" href="Styles/MapMain.css" />
    <link  rel="stylesheet"type="text/css" href="Styles/bootstrap.min.css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="menu" id="menu">
	    <div class="item">服务机构</div>
	    <div class="spilt_line"></div>
	    <div class="item" onclick="sfxzjg()">司法行政机关<asp:ImageButton ID="btn_cate2" runat="server" ImageUrl="~/Pic/epn.png" OnClick="btn_cate2_Click" /></div>
	    <div class="spilt_line"></div>
	    <div class="item" onclick="flfws()">法律服务所<asp:ImageButton ID="btn_cate1" runat="server" ImageUrl="~/Pic/epn.png" OnClick="btn_cate1_Click" /></div>
	    <div class="spilt_line"></div>
	</div>
	<div id="sub_menu">
		<div onclick="flyz();">法律援助<asp:ImageButton ID="btn_cate3" runat="server" ImageUrl="~/Pic/epn.png" OnClick="btn_cate3_Click" /></div>
        <%--<asp:ImageButton ID="btn_cate1" runat="server" ImageUrl="Pic/search.jpg" OnClick="btn_cate1_Click" />--%>
		<div onclick="sfjd();">司法鉴定<asp:ImageButton ID="btn_cate4" runat="server" ImageUrl="~/Pic/epn.png" OnClick="btn_cate4_Click" /></div>
		<div onclick="lssws();">律师事务所<asp:ImageButton ID="btn_cate5" runat="server" ImageUrl="~/Pic/epn.png" OnClick="btn_cate5_Click" /></div>
		<div onclick="gzjg();">公证机构<asp:ImageButton ID="btn_cate6" runat="server" ImageUrl="~/Pic/epn.png" OnClick="btn_cate6_Click" /></div>
	</div>
        <div id="map">
            <asp:Label ID="Label_title" runat="server" Visible="False"></asp:Label>
            <asp:Literal ID="Literal_map" runat="server"></asp:Literal>
        </div>
        <div id="bottom_tool">
            <div class="search"><asp:TextBox runat="server" class="form-control input-sm" ID="keyword" type="text" placeholder="输入关键字搜索" onfocus="if (value ==''){value =''}  else {
                value ='';
            }"  /></div>
            <div class="btn_ico" style="text-align: center" onclick="searchByKw();">
                <img src="Pic/search.jpg" height="43"/>
                <asp:ImageButton ID="btn_epn" runat="server" ImageUrl="~/Pic/epn.png" OnClick="btn_epn_Click" />
            </div>
	    </div>
    </form>
</body>
</html>
