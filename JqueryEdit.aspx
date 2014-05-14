<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JqueryEdit.aspx.cs" Inherits="JqueryEdit" MasterPageFile="~/Site.master" %>

<asp:Content runat="server" ID="body" ContentPlaceHolderID="ContentPlaceHolder1">
<div id="inner-info" style="width:600px; min-height:500px; height:auto;">
        <div style="text-align:center; padding-top:10px;">
        <asp:Label ID="Label3" runat="server" Visible="false" CssClass="labels"></asp:Label>
        </div>
        <div class="column">
        <b>Select Place</b>
            <asp:DropDownList ID="DropDownList1" CssClass="chzn-select" runat="server"></asp:DropDownList>
        </div>
        <div class="column">
        <b>Place Image</b>
            <asp:FileUpload ID="FileUpload1" CssClass="file" Width="200px" runat="server" />
        </div>
        <div style="float:right; margin:25px;">
        <asp:Button ID="Button3" runat="server" CssClass="button" Text="Add Content" OnClick="Button3_Click" />
        </div>
</div>
</asp:Content>