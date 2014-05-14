<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Trips.aspx.cs" Inherits="Trips" MasterPageFile="~/Site.master" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    ul { margin:10px; }
    li { list-style-type:none; }
</style>
</asp:Content>

<asp:Content ID="bodycontent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="inner-info" style="width:940px; min-height:500px; height:auto; background-color:#dbdbdb; border-radius:5px; padding:20px;">
<h1><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h1>
    <div style="width:800px; margin:20px; clear:both;">
    <h3>Recommend to a friend</h3>
        <asp:Button ID="Button5" runat="server" Text="Recommend to a friend" OnClick="Recom_Friend" CssClass="button" />
        <asp:Label ID="Label12" runat="server" CssClass="labels"></asp:Label>
    <asp:Panel ID="Panel5" runat="server" Visible="false">
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="chzn-select" Width="300px"></asp:DropDownList>
        <asp:Button ID="Button4" runat="server" CssClass="button" Text="Recommend" OnClick="Recommend" />
    </asp:Panel>
    </div>
    <div style="margin:20px;">
    <b>Powered By: </b>
        <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
    </div>
    <div style="margin:20px;">
    <b>Trip Type: </b>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="margin:20px;">
    <b>Duration: </b>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="margin:20px;">
    <b>Total Cost: </b>
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="margin:20px;">
    <b>Districts Covered: </b>
    <ul>
    <li><asp:HyperLink ID="HyperLink2" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink3" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink4" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink5" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink6" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink7" runat="server"></asp:HyperLink></li>
    </ul>
    </div>
    <div style="margin:20px;">
    <b>Places Covered: </b>
    <ul>
    <li><asp:HyperLink ID="HyperLink8" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink9" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink10" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink11" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink12" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink13" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink14" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink15" runat="server"></asp:HyperLink></li>
    <li><asp:HyperLink ID="HyperLink16" runat="server"></asp:HyperLink></li>
    </ul>
    </div>
    <div class="labeldesc" style="width:910px; float:left; margin-left:20px;">
    <b>Trip Detail</b>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </div>
</div>
</asp:Content>