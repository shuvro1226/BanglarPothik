<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Requests.aspx.cs" Inherits="Requests" MasterPageFile="~/Site.master" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.label
{
    margin-left:40px; margin-top:20px; font-size:14px;
}
.buttonreq
{
    padding:0.3em 0.6em; 
    background-image: -webkit-gradient(linear, 50% 0%, 50% 100%, color-stop(50%, #00611C), color-stop(50%, #009900));
    background-image: -webkit-linear-gradient(#00611C 20%, #009900 90%);
    background-image: -moz-linear-gradient(#00611C 20%, #009900 90%);
    background-image: -o-linear-gradient(#00611C 20%, #009900 90%);
    background-image: linear-gradient(#00611C 20%, #009900 90%); line-height:1em; cursor:pointer;	border-radius:4px; 
    color:#fff; font-weight:bold; font-size:inherit; border:solid 1px #ccc; box-shadow:2px 2px 5px rgba(0,0,0,0.2); 
    background-position: center bottom; position:relative;
}
.buttonignore
{
    padding:0.3em 0.6em; 
    background-image: -webkit-gradient(linear, 50% 0%, 50% 100%, color-stop(50%, #dd5c2f), color-stop(50%, #d14f22));
    background-image: -webkit-linear-gradient(#dd5c2f 20%, #d14f22 90%);
    background-image: -moz-linear-gradient(#dd5c2f 20%, #d14f22 90%);
    background-image: -o-linear-gradient(#dd5c2f 20%, #d14f22 90%);
    background-image: linear-gradient(#dd5c2f 20%, #d14f22 90%); line-height:1em; cursor:pointer;	border-radius:4px; 
    color:#fff; font-weight:bold; font-size:inherit; border:solid 1px #ccc; box-shadow:2px 2px 5px rgba(0,0,0,0.2); 
    background-position: center bottom; position:relative;
}
</style>
</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="inner-info" style="width:980px; min-height:500px; height:auto; background-color:#dbdbdb; font-size:14px; border-radius:5px; margin-bottom:10px;">
<h1 style="text-align:center;">Notifications</h1>
<table cellpadding="20" cellspacing="20">    
    <b style="margin-left:30px;">Friend Requests</b>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="ItemCommand" OnItemDataBound="Repeater1_Databound">
    <ItemTemplate>
    <tr>
    <th align="right">
        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ProPic", "~/images/ProPic/{0}") %>' Height="20px" Width="20px" />
    </th>
    <th align="left">
        <a href='Profile.aspx?Userid=<%#Eval("Userid") %>'><%#Eval("Name") %> </a><asp:Label ID="Label1" runat="server" Text='<%#Eval("Req_type") %>'></asp:Label>
        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Req_by") %>' Visible="false"></asp:Label>
        <div style="float:right;">
            <asp:Button ID="Button1" runat="server" CssClass="buttonreq" Text="Accept" CommandName="Accept" CommandArgument='<%#Eval("Requestid") %>' />
            <asp:Button ID="Button2" runat="server" CssClass="buttonignore" Text="Reject" CommandName="Reject" CommandArgument='<%#Eval("Requestid") %>' />
        </div>
    </th>
    </tr>
    <tr>
    <th align="center" colspan="2"><img src="images/Divider.png" width="900px" alt="" /></th>
    </tr>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Label ID="lblErrorMsg1" runat="server" CssClass="label" Text="You have no new friend requests." Visible="false">
        </asp:Label>
    </FooterTemplate>
    </asp:Repeater>
</table>
<table cellpadding="20" cellspacing="20">    
    <b style="margin-left:30px;">Friend Suggestions</b>
    <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="ItemCommand4" OnItemDataBound="Repeater4_Databound">
    <ItemTemplate>
    <tr>
    <th align="right">
        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ProPic", "~/images/ProPic/{0}") %>' Height="20px" Width="20px" />
    </th>
    <th align="left">
        <a href='Profile.aspx?Userid=<%#Eval("Userid") %>'><%#Eval("Name") %> </a><asp:Label ID="Label1" runat="server" Text='<%#Eval("Req_type") %>'></asp:Label>
        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Req_friend") %>' Visible="false"></asp:Label>
        <div style="float:right;">
            <asp:Button ID="Button1" runat="server" CssClass="buttonreq" Text="View Profile" CommandName="Accept" CommandArgument='<%#Eval("Requestid") %>' />
            <asp:Button ID="Button2" runat="server" CssClass="buttonignore" Text="Ignore" CommandName="Reject" CommandArgument='<%#Eval("Requestid") %>' />
        </div>
    </th>
    </tr>
    <tr>
    <th align="center" colspan="2"><img src="images/Divider.png" width="900px" alt="" /></th>
    </tr>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Label ID="lblErrorMsg1" runat="server" CssClass="label" Text="You have no new friend suggestions." Visible="false">
        </asp:Label>
    </FooterTemplate>
    </asp:Repeater>
</table>
<table cellpadding="20" cellspacing="20">
    <b style="margin-left:30px;">Place Recommendations</b>
    <asp:Label ID="Label5" runat="server" CssClass="labels"></asp:Label>
    <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="ItemCommand2" OnItemDataBound="Repeater2_Databound">
    <ItemTemplate>
    <tr>
    <th align="right">
        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ProPic", "~/images/ProPic/{0}") %>' Height="20px" Width="20px" />
    </th>
    <th align="left">
        <a href='Profile.aspx?Userid=<%#Eval("Userid") %>'><%#Eval("Name") %> </a><asp:Label ID="Label1" runat="server" Text='<%#Eval("Req_type") %>'></asp:Label><%#Eval("Place_name") %>
        
        <asp:Label ID="Label4" runat="server" Text='<%#Eval("Place_id") %>' Visible="false"></asp:Label>
        <div style="float:right;">
            <asp:Button ID="Button3" runat="server" CssClass="buttonreq" Text="Check Out" CommandName="Check" CommandArgument='<%#Eval("Requestid") %>' />
            <asp:Button ID="Button4" runat="server" CssClass="buttonignore" Text="Ignore" CommandName="Ignore" CommandArgument='<%#Eval("Requestid") %>' />
        </div>
    </th>
    </tr>
    <tr>
    <th align="center" colspan="2"><img src="images/Divider.png" width="900px" alt="" /></th>
    </tr>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Label ID="lblErrorMsg" runat="server" CssClass="label" Text="You have no new place recommendations." Visible="false">
        </asp:Label>
    </FooterTemplate>
    </asp:Repeater>
</table>
<table cellpadding="20" cellspacing="20">
    <b style="margin-left:30px;">Trip Recommendations</b>
    <asp:Label ID="Label2" runat="server" CssClass="labels"></asp:Label>
    <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="ItemCommand3" OnItemDataBound="Repeater3_Databound">
    <ItemTemplate>
    <tr>
    <th align="right">
        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ProPic", "~/images/ProPic/{0}") %>' Height="20px" Width="20px" />
    </th>
    <th align="left">
        <a href='Profile.aspx?Userid=<%#Eval("Userid") %>'><%#Eval("Name") %> </a><asp:Label ID="Label1" runat="server" Text='<%#Eval("Req_type") %>'></asp:Label><%#Eval("Tripname")%>
        
        <asp:Label ID="Label5" runat="server" Text='<%#Eval("Tripid") %>' Visible="false"></asp:Label>
        <div style="float:right;">
            <asp:Button ID="Button5" runat="server" CssClass="buttonreq" Text="Check Out" CommandName="Check2" CommandArgument='<%#Eval("Requestid") %>' />
            <asp:Button ID="Button6" runat="server" CssClass="buttonignore" Text="Ignore" CommandName="Ignore2" CommandArgument='<%#Eval("Requestid") %>' />
        </div>
    </th>
    </tr>
    <tr>
    <th align="center" colspan="2"><img src="images/Divider.png" width="900px" alt="" /></th>
    </tr>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Label ID="lblErrorMsg2" runat="server" CssClass="label" Text="You have no new trip recommendations." Visible="false">
        </asp:Label>
    </FooterTemplate>
    </asp:Repeater>
</table>
</div>

</asp:Content>