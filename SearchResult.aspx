<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" MasterPageFile="~/Site.master" Inherits="SearchResult" %>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="inner-info" style="width:980px; min-height:500px; height:auto; background-color:#dbdbdb; border-radius:5px; margin-bottom:10px;">
<h3 style="text-align:center;"><asp:Label ID="Label2" runat="server" CssClass="labels"></asp:Label></h3>
<table cellpadding="20" cellspacing="20">    
    <asp:Repeater ID="Repeater1" runat="server" Visible="false">
    <ItemTemplate>
    <tr>
    <th align="right">
        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image", "~/images/Place/{0}") %>' Height="50px" Width="40px" />
    </th>
    <th align="left" style="font-weight:normal; font-size:14px;">
        <h3><a href='Place.aspx?Place=<%#Eval("Place_id") %>'><%#Eval("Place_name") %></a></h3>
        <b>Division:</b> <%#Eval("Div_name") %>, &nbsp;<b>District:</b> <%#Eval("Dis_name") %>, &nbsp;<b>Category:</b> <%#Eval("Cat_name") %>
    </th>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
    
    <asp:Repeater ID="Repeater2" runat="server" Visible="false">
    <ItemTemplate>
    <tr>
    <th align="left">
        <h3><a href='Trips.aspx?Tripid=<%#Eval("Tripid") %>'><%#Eval("Tripname") %></a>&nbsp; by &nbsp;<a href='AgencyDetail.aspx?Agencyid=<%#Eval("Agencyid") %>'><%#Eval("Agencyname") %></a></h3>
    </th>
    </tr>
    <tr>
    <th align="center" colspan="2"><img src="images/Divider.png" width="900px" alt="" /></th>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
</table>
</div>
</asp:Content>