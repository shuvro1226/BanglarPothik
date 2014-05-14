<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" MasterPageFile="~/Site.master" Inherits="Register" %>
<%@ Register src="~/piczardUserControls/simpleImageUploadUserControl/SimpleImageUpload.ascx" tagname="SimpleImageUpload" tagprefix="ccPiczardUC" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .table { width:100%; border:none; }
    .table th { width:auto; height:40px; padding-left:20px; padding-right:20px; font-weight:normal; font-family:Trebuchet MS; }
    .valid { color:#a03b18; }
</style>
<link href="css/orange.css" rel="stylesheet"/>
</asp:Content>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
            //<![CDATA[
        function fvPicture1_Validate(sender, args) {
            // Validate the Picture1 (must contain a value)
            args.IsValid = CodeCarvings.Wcs.Piczard.Upload.SimpleImageUpload.get_hasImage("<% =CodeCarvings.Piczard.Web.Helpers.JSHelper.EncodeString(this.Upload.ClientID) %>"); ;
        }
        function btnSave_clientClick() {
            if (CodeCarvings.Wcs.Piczard.Upload.SimpleImageUpload.get_uploadInProgress()) {
                alert("Upload in progress, please wait...");
                return false;
            }

            return true;
        }
            //]]>
        </script>
<div id="inner-info" style="width:460px; height:auto; margin-left:250px; background-color:#dbdbdb; border-radius:5px; padding:20px;">
<h1>Register For Banglar Pothe</h1>
<div style="text-align:center;">
    <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
    <p>[ Enter your registration details below. Fields marked with * must be filled!! ]</p><br />
</div>
<asp:Panel ID="Panel1" runat="server">
<table class="table">
<tr>
<th colspan="2"><img src="images/1.png" alt="" />
<h3>Enter Registration Information</h3></th>
</tr>
<tr align="left" valign="bottom">
<th>Name *</th>
<th align="right">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="valid" SetFocusOnError="true" ControlToValidate="Textbox1" ValidationGroup="One" runat="server" ErrorMessage="Provide your full name"></asp:RequiredFieldValidator>
</th>
</tr>
<tr align="left">
<th colspan="2">
    <asp:TextBox ID="TextBox1" CssClass="textbox" Width="400px" runat="server"></asp:TextBox>
</th>
</tr>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<tr align="left" valign="bottom">
<th>Username *</th>
<th align="right">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="valid" SetFocusOnError="true" ControlToValidate="Textbox2" ValidationGroup="One" runat="server" ErrorMessage="Select your username"></asp:RequiredFieldValidator>
    <asp:Label ID="Label3" runat="server"></asp:Label>
</th>
</tr>
<tr align="left">
<th colspan="2">
    <asp:TextBox ID="TextBox2" CssClass="textbox" OnTextChanged="username_changed" AutoPostBack="true" Width="400px" runat="server"></asp:TextBox>
</th>
</tr>
</ContentTemplate>
</asp:UpdatePanel>
<tr align="left" valign="bottom">
<th>Sex *</th>
<th align="right"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="valid" InitialValue="-1" SetFocusOnError="true" ControlToValidate="DropDownList1" ValidationGroup="One" runat="server" ErrorMessage="Select your sex"></asp:RequiredFieldValidator></th>
</tr>
<tr align="left">
<th colspan="2">
<div style="float:left; width:180px; padding:5px;">
    <asp:DropDownList ID="DropDownList1" CssClass="chzn-select" Width="410px" runat="server">
    <asp:ListItem Value="-1">Select</asp:ListItem>
    <asp:ListItem Value="1">Male</asp:ListItem>
    <asp:ListItem Value="2">Female</asp:ListItem>
    </asp:DropDownList>
</div>
</th>
</tr>
<tr align="left" valign="bottom">
<th>District *</th>
<th align="right"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="valid" InitialValue="-1" SetFocusOnError="true" ControlToValidate="DropDownList2" ValidationGroup="One" runat="server" ErrorMessage="Select your district"></asp:RequiredFieldValidator></th>
</tr>
<tr align="left">
<th colspan="2">
<div style="float:left; width:180px; padding:5px;">
    <asp:DropDownList ID="DropDownList2" CssClass="chzn-select" Width="410px" runat="server">
    <asp:ListItem Value="-1">District</asp:ListItem>
    </asp:DropDownList>
</div>
</th>
</tr>
<tr align="left" valign="bottom">
<th colspan="2">Profile picture *</th>
</tr>
<tr align="left">
<th colspan="2">
    <ccPiczardUC:SimpleImageUpload ID="Upload" runat="server" />
</th>
</tr>
<tr align="left" valign="bottom">
<th colspan="2">
    <asp:CustomValidator runat="server" ID="fvPicture1" CssClass="valid" ClientValidationFunction="fvPicture1_Validate" OnServerValidate="fvPicture1_ServerValidate" SetFocusOnError="true" ValidationGroup="One" ErrorMessage="Select a profile picture"></asp:CustomValidator>
</th>
</tr>
<tr align="left" valign="bottom">
<th>Password *</th>
<th align="right">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="valid" runat="server" SetFocusOnError="true" ControlToValidate="Password" ValidationGroup="One" ErrorMessage="Provide a password"></asp:RequiredFieldValidator>
</th>
</tr>
<tr align="left">
<th colspan="2">
    <asp:TextBox ID="Password" TextMode="Password" CssClass="textbox" Width="400px" runat="server"></asp:TextBox>
</th>
</tr>
<tr align="left" valign="bottom">
<th>Confirm Password *</th>
<th align="right">
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="valid" runat="server" SetFocusOnError="true" ControlToValidate="Confirmation" ValidationGroup="One" ErrorMessage="Please confirm your password"></asp:RequiredFieldValidator>
</th>
</tr>
<tr align="left">
<th colspan="2">
    <asp:TextBox ID="Confirmation" TextMode="Password" CssClass="textbox" Width="400px" runat="server"></asp:TextBox>
</th>
</tr>
<tr align="right">
<th colspan="2">
<asp:CompareValidator ID="confirm" CssClass="valid" ControlToCompare="Password" ControlToValidate="Confirmation" ErrorMessage="Password didn't match!" runat="server"></asp:CompareValidator>
</th>
</tr>
<tr align="left" valign="bottom">
<th>Email *</th>
<th align="right">
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="valid" SetFocusOnError="true" ControlToValidate="Email" ValidationGroup="One" runat="server" ErrorMessage="Provide an email address"></asp:RequiredFieldValidator>
</th>
</tr>
<tr align="left">
<th colspan="2">
    <asp:TextBox ID="Email" type="email" CssClass="textbox" Width="400px" runat="server"></asp:TextBox>
</th>
</tr>
<tr>
<th align="left" colspan="2">
    <div style="margin-bottom:20px;">
    <asp:Button ID="Button2" runat="server" Width="410px" Text="Submit Information to Register" OnClick="Button2_Click" ValidationGroup="One" CssClass="button" />
    </div>
</th>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" Visible="false">
<table class="table">
<tr>
<th colspan="2">
<img src="images/2.png" alt="" /><h3>Enter Personal Information</h3></th>
</tr>
<tr align="left" valign="bottom">
<th>Date of Birth</th>
<th align="right"></th>
</tr>
<tr align="left">
<th colspan="2">
<div style="float:left; width:120px; padding:5px;">
    <asp:DropDownList ID="Year" CssClass="chzn-select" runat="server">
    <asp:ListItem Value="0">Year</asp:ListItem>
    </asp:DropDownList>
</div>
<div style="float:left; width:150px; padding:5px;">
    <asp:DropDownList ID="Month" CssClass="chzn-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Changed1">
    <asp:ListItem Value="0">Month</asp:ListItem>
    <asp:ListItem>January</asp:ListItem>
    <asp:ListItem>February</asp:ListItem>
    <asp:ListItem>March</asp:ListItem>
    <asp:ListItem>April</asp:ListItem>
    <asp:ListItem>May</asp:ListItem>
    <asp:ListItem>June</asp:ListItem>
    <asp:ListItem>July</asp:ListItem>
    <asp:ListItem>August</asp:ListItem>
    <asp:ListItem>September</asp:ListItem>
    <asp:ListItem>October</asp:ListItem>
    <asp:ListItem>November</asp:ListItem>
    <asp:ListItem>December</asp:ListItem>
    </asp:DropDownList>
    
</div>
<div style="float:left; width:115px; padding:5px;">
    <asp:DropDownList ID="Day" CssClass="chzn-select" runat="server">
    <asp:ListItem Value="0">Day</asp:ListItem>
    </asp:DropDownList>
</div>
</th>
</tr>
<tr align="left" valign="bottom">
<th colspan="2">Contact Number</th>
</tr>
<tr align="left">
<th colspan="2">
    <asp:TextBox ID="TextBox3" CssClass="textbox" Width="400px" runat="server"></asp:TextBox>
</th>
</tr>
<tr align="left" valign="bottom">
<th colspan="2">Occupation</th>
</tr>
<tr align="left">
<th colspan="2">
    <asp:TextBox ID="TextBox5" CssClass="textbox" Width="400px" runat="server"></asp:TextBox>
</th>
</tr>
<tr align="left" valign="bottom">
<th colspan="2">More About You</th>
</tr>
<tr align="left">
<th colspan="2">
    <asp:TextBox ID="TextBox6" TextMode="MultiLine" Height="200px" Rows="10" Columns="47" runat="server"></asp:TextBox>
</th>
</tr>
<tr>
<th align="left" colspan="2">
    <div style="margin-bottom:20px;">
    <asp:Button ID="Button1" runat="server" Width="410px" Text="Submit Additional Information" OnClick="Button1_Click" OnClientClick="if (!btnSave_clientClick()) return false;" CssClass="button" />
    </div>
</th>
</tr>
<tr>
<th align="left" colspan="2">
    <div style="margin-bottom:20px;">
    <asp:Button ID="Button3" runat="server" Width="410px" Text="Or Login Using Username & Password" OnClick="Button3_Click" CssClass="button" />
    </div>
</th>
</tr>
</table>
</asp:Panel>
</div>
</asp:Content>