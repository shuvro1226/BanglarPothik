<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Division.aspx.cs" Inherits="Division" MasterPageFile="~/Site.master" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    ul { margin:20px; }
    ul.places { overflow-y:scroll; max-height:400px; }
    li { list-style-type:none; }
</style>
</asp:Content>

<asp:Content ID="division" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="inner-info" style="width:980px; min-height:500px; height:auto; background-color:#dbdbdb; border-radius:5px; margin-bottom:10px;">
<h1><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h1>
<table cellspacing="20" style="float:left;">
    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
    <tr>
    <th align="right">
        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Map", "~/images/Districts/{0}") %>' Height="100px" Width="75px" />
    </th>
    <th align="left">
        <h2><a href='ContentPage.aspx?District=<%#Eval("Dis_id") %>'><%#Eval("Dis_name") %> District</a></h2><br />
        <asp:Label ID="Label1" runat="server" Width="350px" Text='<%#Eval("Details").ToString().Substring(0,100) %>' ></asp:Label>
    </th>
    </tr>
    <tr>
    <th align="center" colspan="2"><img src="images/Divider.png" alt="" width="400px" /></th>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
</table>
<div style="float:left;">
    <h3>Recommended Places</h3>
    <ul class="places">
        <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
        <li><a href='Place.aspx?Place=<%#Eval("Place_id") %>'><%#Eval("Place_name") %></a></li>
        </ItemTemplate>
        </asp:Repeater>
    </ul>
    <asp:Image ID="Image2" runat="server"></asp:Image>
</div>
</div>
</asp:Content>