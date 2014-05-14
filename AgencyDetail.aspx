<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgencyDetail.aspx.cs" Inherits="AgencyDetail" MasterPageFile="~/Site.master" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    ul { margin:10px; }
    li { list-style-type:none; }
</style>
</asp:Content>

<asp:Content ID="agency" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="inner-info" style="width:940px; min-height:500px; height:auto; background-color:#dbdbdb; border-radius:5px; padding:20px;">
<h1><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h1>

    <div style="margin:20px;">
    <b>Contact: </b>
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="margin:20px;">
    <b>Address: </b>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="margin:20px;">
    <b>Email: </b>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="margin:20px;">
    <b>Website: </b>
        <asp:HyperLink ID="HyperLink1" runat="server">Visit their website</asp:HyperLink>
    </div>
    <div class="labeldesc" style="width:910px; float:left; margin-left:20px;">
    <b>About Their Agency</b>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </div>
    
    <h3>Available Trips</h3>
    <ul>
        <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
        <li><a href='Trips.aspx?Tripid=<%#Eval("Tripid") %>'><%#Eval("Tripname") %></a></li>
        </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
</asp:Content>