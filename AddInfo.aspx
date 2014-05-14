<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddInfo.aspx.cs" MasterPageFile="~/Site.master" Inherits="AddInfo" ValidateRequest="false" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="inner-info" style="width:600px; min-height:500px; height:auto;">
<p class="innerinfo" style="width:580px;">Select an option to add a dirtrict or a place</p>
    <div style="width:200px; margin:0 auto;">
    <asp:DropDownList ID="DropDownList0" runat="server" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="List1_Changed">
    <asp:ListItem Value="-1">Select</asp:ListItem>
    <asp:ListItem Value="1">Add a division</asp:ListItem>
    <asp:ListItem Value="2">Add a district</asp:ListItem>
    <asp:ListItem Value="3">Add a new Place</asp:ListItem>
    <asp:ListItem Value="4">Add a new Travel Agency</asp:ListItem>
    <asp:ListItem Value="5">Add a new Trip Detail</asp:ListItem>
    </asp:DropDownList>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>  
    <asp:Table ID="Table1" runat="server" Visible="false" CssClass="tables">
    <asp:TableHeaderRow><asp:TableHeaderCell><h3>Enter District Details Below</h3></asp:TableHeaderCell></asp:TableHeaderRow>
    <asp:TableRow><asp:TableCell>
        <div style="text-align:center; padding-top:10px;">
        <asp:Label ID="Label1" runat="server" Visible="false" CssClass="labels"></asp:Label>
        </div>
        <div class="column">
        <b>Enter District Name</b>
            <asp:TextBox ID="District" CssClass="textbox" runat="server"></asp:TextBox>
        </div>
        <div class="column">
        <b>Select A Division</b>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="chzn-select"></asp:DropDownList>
        </div>
        <div class="column">
        <b>Area (In Square KMs)</b>
            <asp:TextBox ID="Area" CssClass="textbox" runat="server"></asp:TextBox>
        </div>
        <div class="column" style="margin-right:70px;">
        <b>Distance from capital</b>
            <asp:TextBox ID="Distance" CssClass="textbox" Width="200" runat="server"></asp:TextBox>
        </div>
        <div class="column">
        <b>Principal Rivers</b>
            <asp:TextBox ID="Rivers" CssClass="textbox" Width="280" runat="server"></asp:TextBox>
        </div>
        <div style="float:left; width:auto;">
        <b style="margin-right:80px; margin-left:20px;">District Map</b>
            <asp:FileUpload ID="MapUpload" CssClass="file" runat="server" />
        </div>
        <div style="float:left; width:auto; margin:20px;">
        <b>Description</b>
            <textarea runat="server" id="Details" style="width:520px; height:180px;" rows="10" cols="65"></textarea>
        </div>
        <div style="float:left; margin:20px; margin-top:-15px;">
        <asp:Button ID="Button1" runat="server" CssClass="button" Width="535px" Text="Add District" OnClick="Button1_Click" />
        </div>
    </asp:TableCell></asp:TableRow>
    </asp:Table>

    <asp:Table ID="Table2" runat="server" Visible="false" CssClass="tables">
    <asp:TableHeaderRow><asp:TableHeaderCell><h3>Enter Place Details Below</h3></asp:TableHeaderCell></asp:TableHeaderRow>
    <asp:TableRow><asp:TableCell>
        <div style="text-align:center; padding-top:10px;">
        <asp:Label ID="Label2" runat="server" Visible="false" CssClass="labels"></asp:Label>
        </div>
        <div class="column" style="width:350px;">
        <b>Name of the Place</b>
            <asp:TextBox ID="TextBox2" CssClass="textbox" Width="350" runat="server"></asp:TextBox>
        </div>
        <div class="column">
        <b>Co-ordinates</b>
            <asp:TextBox ID="TextBox1" CssClass="textbox" runat="server"></asp:TextBox>
        </div>
        <div class="column">
        <b>Select A Division</b>
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="PlaceIndex_Changed"></asp:DropDownList>
        </div>
        <div class="column">
        <b>Select A District</b>
            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="chzn-select">
            <asp:ListItem Value="-1">Select</asp:ListItem>
        </asp:DropDownList>
        </div>
        <div class="column">
        <b>Select A Category</b>
            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="chzn-select"></asp:DropDownList>
        </div>
        <div style="float:left; width:auto; margin-top:10px;">
        <b style="margin-right:30px; margin-left:20px;">Image</b>
            <asp:FileUpload ID="FileUpload2" CssClass="file" runat="server" />
        </div>
        <div style="float:left; width:auto; margin:20px;">
        <b>Description</b>
            <textarea runat="server" id="textarea2" style="width:520px; height:180px;" rows="10" cols="65"></textarea>
        </div>
        <div style="float:left; margin:20px; margin-top:-15px;">
        <asp:Button ID="Button2" runat="server" CssClass="button" Width="535px" Text="Add Place" OnClick="Button2_Click" />
        </div>
    </asp:TableCell></asp:TableRow>
    </asp:Table>

    <asp:Table ID="Table4" runat="server" Visible="false" CssClass="tables">
    <asp:TableHeaderRow><asp:TableHeaderCell><h3>Enter Agency Details Below</h3></asp:TableHeaderCell></asp:TableHeaderRow>
    <asp:TableRow><asp:TableCell>
        <div style="text-align:center; padding-top:10px;">
        <asp:Label ID="Label4" runat="server" Visible="false" CssClass="labels"></asp:Label>
        </div>
        <div class="column" style="width:200px;">
        <b>Name of the Agency</b>
            <asp:TextBox ID="TextBox4" CssClass="textbox" Width="200" runat="server"></asp:TextBox>
        </div>
        <div class="column" style="width:290px;">
        <b>Contact</b>
            <asp:TextBox ID="TextBox7" CssClass="textbox" Width="290" runat="server"></asp:TextBox>
        </div>
        <div class="column" style="width:350px;">
        <b>Address</b>
            <asp:TextBox ID="TextBox5" CssClass="textbox" Width="350" runat="server"></asp:TextBox>
        </div>
        <div class="column">
        <b>Email</b>
            <asp:TextBox ID="TextBox9" type="email" CssClass="textbox" runat="server"></asp:TextBox>
        </div>
        <div class="column">
        <b>URL</b>
            <asp:TextBox ID="TextBox8" CssClass="textbox" runat="server"></asp:TextBox>
        </div>
        <div style="float:left; width:auto; margin:20px;">
        <b>About the Agency</b>
            <textarea runat="server" id="textarea1" style="width:520px; height:180px;" rows="10" cols="65"></textarea>
        </div>
        <div style="float:left; margin:20px; margin-top:-15px;">
        <asp:Button ID="Button4" runat="server" CssClass="button" Width="535px" Text="Add Agency" OnClick="Button4_Click" />
        </div>
    </asp:TableCell></asp:TableRow>
    </asp:Table>

    <asp:Table ID="Table5" runat="server" Visible="false" CssClass="tables">
    <asp:TableHeaderRow><asp:TableHeaderCell><h3>Enter Trip Details Below</h3></asp:TableHeaderCell></asp:TableHeaderRow>
    <asp:TableRow><asp:TableCell>
        <div style="text-align:center; padding-top:10px;">
        <asp:Label ID="Label5" runat="server" Visible="false" CssClass="labels"></asp:Label>
        </div>
        <div class="column" style="width:350px;">
        <b>Trip Name</b>
            <asp:TextBox ID="TextBox6" CssClass="textbox" Width="350" runat="server"></asp:TextBox>
        </div>  
        <div class="column">
        <b>Duration</b>
            <asp:TextBox ID="TextBox10" CssClass="textbox" runat="server"></asp:TextBox>
        </div>
        <div class="column">
        <b>Cost</b>
            <asp:TextBox ID="TextBox11" CssClass="textbox" runat="server"></asp:TextBox>
        </div>
        <div class="column" style="width:350px;">
        <b>Select Districts</b>
            <asp:DropDownList ID="DropDownList16" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList17" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList18" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList19" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList20" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList21" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
        </div>
        <div class="column" style="width:540px;">
        <b>Select Places</b>
            <asp:DropDownList ID="DropDownList7" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList8" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList9" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList10" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList11" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList12" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList13" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList14" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList15" runat="server" CssClass="chzn-select">
            </asp:DropDownList>
        </div>
        <div class="column" style="width:220px;">
        <b>Trip Type</b>
            <asp:DropDownList ID="DropDownList6" CssClass="chzn-select" runat="server">
            </asp:DropDownList>
        </div>       
        <div class="column" style="width:275px;">
        <b>Travel Agency</b>
            <asp:DropDownList ID="DropDownList2" CssClass="chzn-select" runat="server"></asp:DropDownList>
        </div>
        <div style="float:left; width:auto; margin:20px;">
        <b>Trip Detail</b>
            <textarea runat="server" id="textarea3" style="width:520px; height:180px;" rows="10" cols="65"></textarea>
        </div>
        <div style="float:left; margin:20px; margin-top:-15px;">
        <asp:Button ID="Button5" runat="server" CssClass="button" Width="535px" Text="Add Trip Detail" OnClick="Button5_Click" />
        </div>
    </asp:TableCell></asp:TableRow>
    </asp:Table>

    <asp:Table ID="Table3" runat="server" Visible="false" CssClass="tables">
    <asp:TableHeaderRow><asp:TableHeaderCell>Enter the new Division name</asp:TableHeaderCell></asp:TableHeaderRow>
    <asp:TableRow><asp:TableCell>
        <div style="text-align:center; padding-top:10px;">
        <asp:Label ID="Label3" runat="server" Visible="false" CssClass="labels"></asp:Label>
        </div>
        <div class="column">
        <b>Name of the Division</b>
            <asp:TextBox ID="TextBox3" CssClass="textbox" runat="server"></asp:TextBox>
        </div>
        <div style="float:right; margin:25px;">
        <asp:Button ID="Button3" runat="server" CssClass="button" Text="Add Division" OnClick="Button3_Click" />
        </div>
    </asp:TableCell></asp:TableRow>
    </asp:Table>
</div>

</asp:Content>