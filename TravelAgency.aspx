<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelAgency.aspx.cs" MasterPageFile="~/Site.master" Inherits="TravelAgency" %>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="inner-info" style="width:980px; min-height:500px; height:auto; background-color:#dbdbdb; border-radius:5px; margin-bottom:10px;">
<h1>List of Available Travel Agencies</h1>
<table cellpadding="20" cellspacing="20">
    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
    <tr>
    <th align="center">
        <h2><a href='AgencyDetail.aspx?Agencyid=<%#Eval("Agencyid") %>'><%#Eval("Agencyname") %></a></h2><br />
        Contact: <asp:Label ID="Label1" CssClass="asplabel" runat="server" Text='<%#Eval("Contact") %>'></asp:Label><br />
        Email: <asp:Label ID="Label2" CssClass="asplabel" runat="server" Text='<%#Eval("Email") %>'></asp:Label><br />
        Website: <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#Eval("Url") %>' runat="server">Visit their website</asp:HyperLink><br />
    </th>
    </tr>
    <tr>
    <th align="center"><img src="images/Divider.png" width="900px" alt="" /></th>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
</table>
</div>
</asp:Content>