<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataEdit.aspx.cs" Inherits="DataEdit" MasterPageFile="~/Site.master" ValidateRequest="false" EnableViewStateMac="false" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.body { min-height:435px; }
.panels { float:right;}
</style>
</asp:Content>

<asp:Content ID="DataEdit" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="body">
    <asp:DropDownList ID="DropDownList2" CssClass="chzn-select" Width="200px" OnSelectedIndexChanged="drpdwn2chng" AutoPostBack="true" runat="server">
    <asp:ListItem Value="-1">Choose an option to edit</asp:ListItem>
    <asp:ListItem Value="1">Edit District Info</asp:ListItem>
    <asp:ListItem Value="2">Edit Place Info</asp:ListItem>
    <asp:ListItem Value="3">Edit Agency Info</asp:ListItem>
    <asp:ListItem Value="4">Edit Trip Info</asp:ListItem>
    </asp:DropDownList>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConString %>" SelectCommand="SELECT * FROM [District]"
 DeleteCommand="DELETE FROM [District] WHERE [Dis_id]=@ID">
      <DeleteParameters>
        <asp:Parameter Type="Int32" Name="ID" />
      </DeleteParameters>
    </asp:SqlDataSource>
    <asp:Panel ID="Panel3" Visible="false" runat="server">
    <div style="float:left; margin:20px;">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" PageSize="12" DataSourceID="SqlDataSource1" 
    DataKeyNames="Dis_id" AllowPaging="true" OnRowCommand="Row">
    <Columns>
    <asp:BoundField DataField="Dis_name" HeaderText="District Name" SortExpression="Dis_name" />

    <asp:TemplateField>
        <ItemTemplate>
        <asp:ImageButton ID="imgbtnEdit" CommandName="Select" runat="server" CommandArgument='<%# Eval("Dis_id") %>' ToolTip="Select" Height="20px" Width="20px" ImageUrl="~/images/Custom-Icon-Design-Pretty-Office-9-Edit-validated.ico" />
        <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" CommandArgument='<%# Eval("Dis_id") %>' runat="server" ToolTip="Delete" Height="20px" Width="20px" ImageUrl="~/images/DeleteRed.png" />
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    </div>
    </asp:Panel>
    <div style="float:left;">
    <asp:Panel ID="Panel2" Width="200px" Visible="false" runat="server">
    <div id="inner-info">
        <div style="margin:20px;">
        <p><asp:Label ID="Label3" runat="server" CssClass="labels" Text="Are You Sure?"></asp:Label></p>
        <asp:Button ID="Button2" runat="server" CssClass="button" Text="Yes" OnClick="Yes" />
        <asp:Button ID="Button3" runat="server" CssClass="button" Text="No" OnClick="No" />
        </div>
    </div>
    </asp:Panel>
    </div>
    <div style="float:right;">
    <asp:Panel ID="Panel1" Width="600px" CssClass="panels" Visible="false" runat="server">
        <asp:Label ID="Label2" CssClass="labels" runat="server"></asp:Label>
        <div style="text-align:center; padding-top:10px;">
        <asp:Label ID="Label1" runat="server" Visible="false" CssClass="labels"></asp:Label>
        </div>
        <div class="column">
        <b>Enter District Name</b>
            <asp:TextBox ID="dis" CssClass="textbox" runat="server"></asp:TextBox>
        </div>
        <div class="column">
        <b>Select A Division</b>
            <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true" CssClass="chzn-select"></asp:DropDownList>
        </div>
        <div class="column">
        <b>Area (In Square KMs)</b>
            <asp:TextBox ID="Area" CssClass="textbox" runat="server"></asp:TextBox>
        </div>
        <div class="column" style="margin-right:70px;">
        <b>Latitude & Longitude</b>
            <asp:TextBox ID="Distance" CssClass="textbox" Width="200" runat="server"></asp:TextBox>
        </div>
        <div class="column">
        <b>Principal Rivers</b>
            <asp:TextBox ID="Rivers" CssClass="textbox" Width="280" runat="server"></asp:TextBox>
        </div>
        <div style="float:left; width:auto; margin:20px;">
        <b>Description</b><br />
            <textarea runat="server" id="Details" style="width:520px; height:180px;"></textarea>
        </div>
        <div style="float:left; margin-top:-25px; margin:20px;">
        <asp:Button ID="Button1" runat="server" Width="530px" CssClass="button" Text="Update District" OnClick="Button1_Click" />
        </div>
    </asp:Panel>
    </div>

<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConString %>" SelectCommand="SELECT * FROM [Place]"
 DeleteCommand="DELETE FROM [Place] WHERE [Place_id]=@ID">
      <DeleteParameters>
        <asp:Parameter Type="Int32" Name="ID" />
      </DeleteParameters>
    </asp:SqlDataSource>
    <asp:Panel ID="Panel4" Visible="false" runat="server">
    <div style="float:left; margin:20px;">
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" PageSize="12" DataSourceID="SqlDataSource2" 
    DataKeyNames="Place_id" AllowPaging="true" OnRowCommand="Row2">
    <Columns>
    <asp:BoundField DataField="Place_name" HeaderText="Place Name" SortExpression="Place_name" />

    <asp:TemplateField>
        <ItemTemplate>
        <asp:ImageButton ID="imgbtnEdit" CommandName="Select" runat="server" CommandArgument='<%# Eval("Place_id") %>' ToolTip="Select" Height="20px" Width="20px" ImageUrl="~/images/Custom-Icon-Design-Pretty-Office-9-Edit-validated.ico" />
        <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" CommandArgument='<%# Eval("Place_id") %>' runat="server" ToolTip="Delete" Height="20px" Width="20px" ImageUrl="~/images/DeleteRed.png" />
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    </div>
    </asp:Panel>
    <div style="float:left;">
    <asp:Panel ID="Panel5" Width="200px" Visible="false" runat="server">
    <div id="Div1">
        <div style="margin:20px;">
        <p><asp:Label ID="Label4" runat="server" CssClass="labels" Text="Are You Sure?"></asp:Label></p>
        <asp:Button ID="Button4" runat="server" CssClass="button" Text="Yes" OnClick="Yes1" />
        <asp:Button ID="Button5" runat="server" CssClass="button" Text="No" OnClick="No" />
        </div>
    </div>
    </asp:Panel>
    </div>
    <div style="float:right;">
    <asp:Panel ID="Panel6" Width="600px" CssClass="panels" Visible="false" runat="server">
        <asp:Label ID="Label5" CssClass="labels" runat="server"></asp:Label>
        <div style="text-align:center; padding-top:10px;">
        <asp:Label ID="Label6" runat="server" Visible="false" CssClass="labels"></asp:Label>
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
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="Division_Changed"></asp:DropDownList>
        </div>
        <div class="column">
        <b>Select A District</b>
            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="chzn-select"></asp:DropDownList>
        </div>
        <div class="column">
        <b>Select A Category</b>
            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="chzn-select"></asp:DropDownList>
        </div>
        <div style="float:left; width:auto; margin:20px;">
        <b>Description</b>
            <textarea runat="server" id="textarea2" style="width:520px; height:180px;" rows="10" cols="65"></textarea>
        </div>
        <div style="float:left; margin:20px; margin-top:-15px;">
        <asp:Button ID="Button6" runat="server" Width="530px" CssClass="button" Text="Update Place" OnClick="Button2_Click" />
        </div>
    </asp:Panel>
    </div>

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConString %>" SelectCommand="SELECT * FROM [TravelAgency]"
 DeleteCommand="DELETE FROM [TravelAgency] WHERE [Agencyid]=@ID">
      <DeleteParameters>
        <asp:Parameter Type="Int32" Name="ID" />
      </DeleteParameters>
    </asp:SqlDataSource>
    <asp:Panel ID="Panel7" Visible="false" runat="server">
    <div style="float:left; margin:20px;">
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" PageSize="12" DataSourceID="SqlDataSource3" 
    DataKeyNames="Agencyid" AllowPaging="true" OnRowCommand="Row3">
    <Columns>
    <asp:BoundField DataField="Agencyname" HeaderText="Agency Name" SortExpression="Agencyname" />

    <asp:TemplateField>
        <ItemTemplate>
        <asp:ImageButton ID="imgbtnEdit" CommandName="Select" runat="server" CommandArgument='<%# Eval("Agencyid") %>' ToolTip="Select" Height="20px" Width="20px" ImageUrl="~/images/Custom-Icon-Design-Pretty-Office-9-Edit-validated.ico" />
        <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" CommandArgument='<%# Eval("Agencyid") %>' runat="server" ToolTip="Delete" Height="20px" Width="20px" ImageUrl="~/images/DeleteRed.png" />
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    </div>
    </asp:Panel>
    <div style="float:left;">
    <asp:Panel ID="Panel8" Width="200px" Visible="false" runat="server">
    <div id="Div2">
        <div style="margin:20px;">
        <p><asp:Label ID="Label7" runat="server" CssClass="labels" Text="Are You Sure?"></asp:Label></p>
        <asp:Button ID="Button7" runat="server" CssClass="button" Text="Yes" OnClick="Yes3" />
        <asp:Button ID="Button8" runat="server" CssClass="button" Text="No" OnClick="No" />
        </div>
    </div>
    </asp:Panel>
    </div>
    <div style="float:right;">
    <asp:Panel ID="Panel9" Width="600px" CssClass="panels" Visible="false" runat="server">
        <asp:Label ID="Label8" CssClass="labels" runat="server"></asp:Label>
        <div style="text-align:center; padding-top:10px;">
        <asp:Label ID="Label9" runat="server" Visible="false" CssClass="labels"></asp:Label>
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
        <div style="float:left; margin:20px; margin-top:-25px;">
        <asp:Button ID="Button9" runat="server" Width="530px" CssClass="button" Text="Update Agency" OnClick="Button9_Click" />
        </div>
    </asp:Panel>
    </div>

    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConString %>" SelectCommand="SELECT * FROM [TripDetail]"
 DeleteCommand="DELETE FROM [TripDetail] WHERE [Tripid]=@ID">
      <DeleteParameters>
        <asp:Parameter Type="Int32" Name="ID" />
      </DeleteParameters>
    </asp:SqlDataSource>
    <asp:Panel ID="Panel10" Visible="false" runat="server">
    <div style="float:left; margin:20px;">
    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" PageSize="12" DataSourceID="SqlDataSource4" 
    DataKeyNames="Tripid" AllowPaging="true" OnRowCommand="Row4">
    <Columns>
    <asp:BoundField DataField="Tripname" HeaderText="Trip Name" SortExpression="Tripname" />

    <asp:TemplateField>
        <ItemTemplate>
        <asp:ImageButton ID="imgbtnEdit" CommandName="Select" runat="server" CommandArgument='<%# Eval("Tripid") %>' ToolTip="Select" Height="20px" Width="20px" ImageUrl="~/images/Custom-Icon-Design-Pretty-Office-9-Edit-validated.ico" />
        <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" CommandArgument='<%# Eval("Tripid") %>' runat="server" ToolTip="Delete" Height="20px" Width="20px" ImageUrl="~/images/DeleteRed.png" />
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    </div>
    </asp:Panel>
    <div style="float:left;">
    <asp:Panel ID="Panel11" Width="200px" Visible="false" runat="server">
    <div id="Div3">
        <div style="margin:20px;">
        <p><asp:Label ID="Label10" runat="server" CssClass="labels" Text="Are You Sure?"></asp:Label></p>
        <asp:Button ID="Button10" runat="server" CssClass="button" Text="Yes" OnClick="Yes4" />
        <asp:Button ID="Button11" runat="server" CssClass="button" Text="No" OnClick="No" />
        </div>
    </div>
    </asp:Panel>
    </div>
    <div style="float:right;">
    <asp:Panel ID="Panel12" Width="600px" CssClass="panels" Visible="false" runat="server">
        <div style="text-align:center; padding-top:10px;">
        <asp:Label ID="Label11" runat="server" Visible="false" CssClass="labels"></asp:Label>
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
            <asp:DropDownList ID="DropDownList22" CssClass="chzn-select" runat="server"></asp:DropDownList>
        </div>
        <div style="float:left; width:auto; margin:20px;">
        <b>Trip Detail</b>
            <textarea runat="server" id="textarea3" style="width:520px; height:180px;" rows="10" cols="65"></textarea>
        </div>
        <div style="float:left; margin:20px; margin-top:-15px;">
        <asp:Button ID="Button12" runat="server" CssClass="button" Width="530px" Text="Update Trip Detail" OnClick="Button12_Click" />
        </div>
    </asp:Panel>
    </div>

</div>
</asp:Content>