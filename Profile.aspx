<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profile.aspx.cs" MasterPageFile="~/Site.master" Inherits="ProfileUser" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.panel 
{
    width:430px; float:left; margin-right:30px; margin-top:50px; margin-bottom:50px;
}
.ui-autocomplete-category {
    font-weight: bold;
    padding: .2em .4em;
    margin: .8em 0 .2em;
    line-height: 1.5;
  }
ul.visited { margin:0 10px; overflow-y:scroll; max-height:400px; }
ul.friends { margin:0 10px; overflow-y:scroll; max-height:400px; }
ul.updates { margin:0 10px; overflow-y:scroll; max-height:1200px; }
ul.updates li { padding:5px; }
</style>
 <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
  <script>
      $.widget("custom.catcomplete", $.ui.autocomplete, {
          _renderMenu: function (ul, items) {
              var that = this,
        currentCategory = "";
              $.each(items, function (index, item) {
                  if (item.category != currentCategory) {
                      ul.append("<li class='ui-autocomplete-category'>" + item.category + "</li>");
                      currentCategory = item.category;
                  }
                  that._renderItemData(ul, item);
              });
          }
      });
  </script>
  <script>
      $(function () {
          var data = [ <%= SuggestionList %> ];

          $("#<%= TextBox11.ClientID %>").catcomplete({
              delay: 0,
              source: data
          });
      });
  </script>
</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="inner-info" style="width:940px; min-height:500px; height:auto; border-radius:5px; padding:20px;">
    <h3><asp:Label ID="Label15" runat="server"></asp:Label></h3>
    <asp:Panel ID="Panel6" runat="server">
    <div style="margin-top:-20px; clear:both;">
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Reload"><h1 style="text-align:left;"><asp:Label ID="Label1" runat="server"></asp:Label></h1></asp:LinkButton>
    <div style="float:right; margin-top:-60px;">
        <asp:TextBox ID="TextBox11" runat="server" CssClass="textbox txtbox" ToolTip="Search for a user" Text="Search for a user" Height="25px"></asp:TextBox>
        <asp:Button ID="Button10" runat="server" Text="Search User" CssClass="button" OnClick="Search_User" />
    </div>
        <asp:Panel ID="Panel8" runat="server">
        <asp:Button ID="Button8" CssClass="button" runat="server" Text="Add Friend" OnClick="Add_friend" />
        <asp:Button ID="Button9" runat="server" CssClass="button" OnClick="Delete_friend" Text="Remove Friend" Visible="false" />
    <asp:Button ID="Button1" runat="server" CssClass="button" Text="Update Info" OnClick="Update" Visible="false" />
    <asp:Button ID="Button5" runat="server" CssClass="button" Text="Profile" OnClick="Go_Profile" Visible="false" />
        <asp:Button ID="Button6" runat="server" Text="Suggest friends" OnClick="Recom_Friend" CssClass="button" Visible="false" />
        <asp:Label ID="Label14" runat="server" CssClass="labels"></asp:Label>
        </asp:Panel>
    <asp:Panel ID="Panel5" runat="server" Visible="false">
        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="chzn-select" Width="200px"></asp:DropDownList>
        <asp:Button ID="Button7" runat="server" CssClass="button" Text="Suggest" OnClick="Recommend" />
    </asp:Panel>
    <asp:Label ID="Label9" runat="server"></asp:Label>
    </div>
<asp:Panel runat="server" ID="Panel1">
<div style="height:auto; background-color:#dbdbdb; border-radius:5px; margin-top:20px;">
<div style="margin-left:20px; margin-top:10px; float:left;">
<asp:Image ID="Image1" CssClass="image" runat="server" />
<div style="margin-top:20px;">
<h3 style="text-align:center;">Friends (<asp:Label ID="Label13" runat="server"></asp:Label>)</h3>

</div>
<ul class="friends" style="list-style-type:none; text-align:left; margin-left:10px;">
        <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
        <li><a href='Profile.aspx?Userid=<%#Eval("Friendid") %>'><%#Eval("Name") %></a></li>
        </ItemTemplate>
        </asp:Repeater>
</ul>
</div>
<div style="margin-left:20px; margin-top:10px; float:left; width:400px;">
<h3 style="text-align:center;">User Updates</h3>
<ul class="updates" style="list-style-type:none; text-align:left; margin-left:10px;">
        <asp:Repeater ID="Repeater3" runat="server">
        <ItemTemplate>
        <li>
        <a href='Profile.aspx?Userid=<%#Eval("Userid") %>'><%#Eval("Name") %></a> <%#Eval("status") %> <a href='Place.aspx?Place=<%#Eval("Place_id") %>'><%#Eval("Place_name") %></a>
        </li>
        </ItemTemplate>
        </asp:Repeater>
</ul>
</div>
<table id="profile" class="tables" style="float:right; width:250px; margin-left:50px;" runat="server">
<tr>
<th>
<h3 style="text-align:center;">Personal Information</h3>
</th>
</tr>
<tr style="text-align:left;">
<th>Sex: <asp:Label ID="Label2" CssClass="asplabel" runat="server"></asp:Label></th>
</tr>
<tr style="text-align:left;">
<th>Date of Birth: <asp:Label ID="Label3" CssClass="asplabel" runat="server"></asp:Label></th>
</tr>
<tr style="text-align:left;">
<th>Occupation: <asp:Label ID="Label4" CssClass="asplabel" runat="server"></asp:Label></th>
</tr>
<tr style="text-align:left;">
<th>District: <asp:Label ID="Label5" CssClass="asplabel" runat="server"></asp:Label></th>
</tr>
<tr style="text-align:left;">
<th>Contact: <asp:Label ID="Label7" CssClass="asplabel" runat="server"></asp:Label></th>
</tr>
<tr style="text-align:left;">
<th>Email: <asp:Label ID="Label8" CssClass="asplabel" runat="server"></asp:Label></th>
</tr>
<tr style="text-align:left;">
<th>About: <asp:Label ID="Label6" runat="server" CssClass="labeldesc"></asp:Label></th>
</tr>
<tr style="text-align:left;">
<th><h3 style="text-align:center;">Places Visited:</h3> </th>
</tr>
<tr>
<th>
    <ul class="visited" style="list-style-type:none; text-align:left; margin-left:10px;">
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <li><a href='Place.aspx?Place=<%#Eval("Place_id") %>'><%#Eval("Place_name") %></a></li>
        </ItemTemplate>
        </asp:Repeater>
    </ul>
</th>
</tr>
</table>
</div>
</asp:Panel>
<asp:Panel runat="server" ID="Panel2" Visible="false" CssClass="panel">
<h2>Update Basic Informations</h2>
<div style="margin:20px;">Name: <br />
    <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Width="350px"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" ControlToValidate="TextBox1" ValidationGroup="One" runat="server" ErrorMessage="Insert Name"></asp:RequiredFieldValidator>
</div>
<div style="margin:20px;">Sex: <br />
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="chzn-select" Width="350px">
    <asp:ListItem Value="Male">Male</asp:ListItem>
    <asp:ListItem Value="Female">Female</asp:ListItem>
    </asp:DropDownList>
</div>
<div style="margin:20px;">Birth:<br />
<div style="float:left; width:100px; padding:5px;">
    <asp:DropDownList ID="Year" CssClass="chzn-select" runat="server"></asp:DropDownList>
</div>
<div style="float:left; width:120px; padding:5px;">
    <asp:DropDownList ID="Month" CssClass="chzn-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Changed1">
    <asp:ListItem Value="January">January</asp:ListItem>
    <asp:ListItem Value="February">February</asp:ListItem>
    <asp:ListItem Value="March">March</asp:ListItem>
    <asp:ListItem Value="April">April</asp:ListItem>
    <asp:ListItem Value="May">May</asp:ListItem>
    <asp:ListItem Value="June">June</asp:ListItem>
    <asp:ListItem Value="July">July</asp:ListItem>
    <asp:ListItem Value="August">August</asp:ListItem>
    <asp:ListItem Value="September">September</asp:ListItem>
    <asp:ListItem Value="October">October</asp:ListItem>
    <asp:ListItem Value="November">November</asp:ListItem>
    <asp:ListItem Value="December">December</asp:ListItem>
    </asp:DropDownList>
    
</div>
<div style="float:left; width:110px; padding:5px;">
    <asp:DropDownList ID="Day" CssClass="chzn-select" runat="server"></asp:DropDownList>
</div>
</div><br />
<div style="margin:20px;">District:<br />
    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="chzn-select" Width="350px"></asp:DropDownList>
</div>
<div style="margin:20px;">Contact:<br />
    <asp:TextBox ID="TextBox4" runat="server" CssClass="textbox" Width="350px"></asp:TextBox>

</div>
<div style="margin:20px;">Email:<br />
    <asp:TextBox ID="TextBox6" runat="server" CssClass="textbox" Width="350px"></asp:TextBox>
</div>
<div style="margin:20px;">Occupation:<br />
    <asp:TextBox ID="TextBox8" runat="server" CssClass="textbox" Width="350px"></asp:TextBox>
</div>
<div style="margin:20px;">About<br />
    <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine" Columns="38" Height="100px" CssClass="textbox"></asp:TextBox>
</div>
    <asp:Button ID="Button2" runat="server" Text="Update basic info" CssClass="button" OnClick="Update_Info" ValidationGroup="One" Width="380px" />
</asp:Panel>
<asp:Panel runat="server" ID="Panel3" CssClass="panel" Visible="false">
<h2>Change Password</h2>
    <asp:Label ID="Label11" runat="server" CssClass="labels"></asp:Label>
<div style="margin:20px;">New Password:<br />
    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" CssClass="textbox" Width="350px"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="valid" runat="server" SetFocusOnError="true" ControlToValidate="TextBox3" ValidationGroup="Two" ErrorMessage="Please enter new password"></asp:RequiredFieldValidator>
</div>
<div style="margin:20px;">Re-Enter Password:<br />
    <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" CssClass="textbox" Width="350px"></asp:TextBox><br />
    <asp:CompareValidator ID="confirm" CssClass="valid" ControlToCompare="TextBox3" ControlToValidate="TextBox5" ErrorMessage="Password didn't match!" runat="server"></asp:CompareValidator>
</div>
<div style="margin:20px;">Old Password:<br />
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="textbox" Width="350px"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="valid" runat="server" SetFocusOnError="true" ControlToValidate="TextBox2" ValidationGroup="Two" ErrorMessage="Please enter old password"></asp:RequiredFieldValidator>
</div>
<asp:Button ID="Button3" runat="server" Text="Update Password" OnClick="Update_Password" CssClass="button" ValidationGroup="Two" Width="380px" />
</asp:Panel>
<asp:Panel runat="server" ID="Panel4" CssClass="panel" Visible="false">
<h2>Change Username</h2>
    <asp:Label ID="Label12" runat="server" CssClass="labels"></asp:Label>
<div style="margin:20px;">New Username:<br />
    <asp:TextBox ID="TextBox10" runat="server" CssClass="textbox" Width="350px" OnTextChanged="Username_Changed" AutoPostBack="true"></asp:TextBox><br />
    <asp:Label ID="Label10" runat="server"></asp:Label><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="valid" runat="server" SetFocusOnError="true" ControlToValidate="TextBox10" ValidationGroup="Three" ErrorMessage="Please enter new username"></asp:RequiredFieldValidator>
</div>
<div style="margin:20px;">Old Username:<br />
    <asp:TextBox ID="TextBox9" runat="server" CssClass="textbox" Width="350px"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="valid" runat="server" SetFocusOnError="true" ControlToValidate="TextBox9" ValidationGroup="Three" ErrorMessage="Please enter old username"></asp:RequiredFieldValidator>
</div>
<asp:Button ID="Button4" runat="server" Text="Update Username" OnClick="Update_Username" CssClass="button" ValidationGroup="Three" Width="380px" />
</asp:Panel>
<asp:Panel ID="Panel7" runat="server" Visible="false">
<table cellpadding="20" cellspacing="20">    
    <asp:Repeater ID="Repeater4" runat="server">
    <ItemTemplate>
    <tr>
    <th align="right">
        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ProPic", "~/images/ProPic/{0}") %>' Height="50px" Width="50px" />
    </th>
    <th align="left">
        <h3><a href='Profile.aspx?Userid=<%#Eval("Userid") %>'><%#Eval("Name") %></a></h3>
        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Occupation").ToString() %>' ></asp:Label>
    </th>
    </tr>
    </ItemTemplate>
    </asp:Repeater>
</table>
</asp:Panel>
</asp:Panel>
</div>
</asp:Content>