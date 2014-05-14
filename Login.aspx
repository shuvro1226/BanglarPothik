<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" MasterPageFile="~/Site.master" Inherits="Login" EnableViewStateMac="false" EnableEventValidation="false" %>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="inner-info" style="width:460px; height:500px; margin-left:250px; background-color:#dbdbdb; border-radius:5px; padding:20px;">
<div style="margin:20px;">
<h1>Insert Login Details</h1>
<asp:Label ID="lblMessage" runat="server" CssClass="labels"></asp:Label><br />
<div class="column">               
                    <b>UserName</b><br />
        <asp:TextBox ID="txtUname" runat="server" CssClass="textbox"></asp:TextBox><br /><br />
                    <b>Password</b><br />
        <asp:TextBox ID="txtPass" TextMode="Password" runat="server" CssClass="textbox"></asp:TextBox><br /><br />
        <asp:Button ID="btnLogin" runat="server" CssClass="button" Width="160px" OnClick="btnLogin_Click" Text="Login" /><br />
</div>
</div>
</div>
</asp:Content>