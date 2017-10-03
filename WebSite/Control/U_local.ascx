<%@ Control Language="C#" AutoEventWireup="true" CodeFile="U_local.ascx.cs" Inherits="Control_U_local" %>

<%@ Register src="S_LocalSelect.ascx" tagname="S_LocalSelect" tagprefix="uc1" %>

<head>
    <title></title>
<style type="text/css">
    .tdtitle {
        width: 90px;
    }
    .submitbutton {}
    </style>
<link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />

</head>
<body>
            <table class="contenttable">
                <tr class="listcontent2">
                    <td>
                        <table class="contenttable">
                         <tr class="listcontent2">
                                <td class="tdtitle" colspan="3">
                                    地址信息添加</td>
                               
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    位置信息<br />
                                    （双击地图标记）</td>
                                <td colspan="2">
                                    <uc1:S_LocalSelect ID="S_LocalSelect1" runat="server" />
                                    </td>
                                     </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    名称</td>
                                <td>
                                    <asp:Label ID="Label_id" runat="server" Visible="False"></asp:Label>
                                    <asp:TextBox ID="TextBox_name" runat="server" MaxLength="100" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="名称不能为空！" ControlToValidate="TextBox_name"></asp:RequiredFieldValidator>
                                </td> 
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    详细地址</td>
                                <td>
                                    <asp:TextBox ID="TextBox_address" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                       <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ErrorMessage="地址不能为空" ControlToValidate="TextBox_address"></asp:RequiredFieldValidator>
                                   
                                </td> 
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    所属分类</td>
                                <td>
                                    <asp:TextBox ID="TextBox_group" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:TextBox>
                                </td>
                                 <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ErrorMessage="分类不能为空" ControlToValidate="TextBox_group"></asp:RequiredFieldValidator>
                                   
                                </td> 
                                
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    备注类型(预留字段)</td>
                                <td>
                                    <asp:TextBox ID="TextBox_type" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    关键词</td>
                                <td>
                                    <asp:TextBox ID="TextBox_keyw" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    联系电话</td>
                                <td>
                                    <asp:TextBox ID="TextBox_tele" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:TextBox>
                                </td>
                                    <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ErrorMessage="联系电话不能为空电话格式：8XXXXXXX或手机号" ControlToValidate="TextBox_group"></asp:RequiredFieldValidator>
                                   
                                </td> 
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    备注描述</td>
                                <td>
                                    <asp:TextBox ID="TextBox_des" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    图片上传(预留字段)</td>
                                <td>
                                    <asp:CheckBox ID="CheckBox_isused" runat="server" Text="是否为有效数据" />
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    额外信息(预留字段)</td>
                                <td>
                                    <asp:TextBox ID="TextBox_exinfo" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
</body>

