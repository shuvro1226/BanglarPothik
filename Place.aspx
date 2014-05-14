<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Place.aspx.cs" Inherits="Place" MasterPageFile="~/Site.master" %>

<asp:Content ID="headcontent" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.companel
{
    margin-top:20px;
}
.comment
{
     background:White; border-radius:5px; padding:20px; font-family:Trebuchet MS;
}
ul { margin:20px; }
li { list-style-type:none; }
</style>
</asp:Content>


<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
<script language="javascript" type="text/javascript">
    var directionsDisplay;
    var directionsService = new google.maps.DirectionsService();

    function InitializeMap() {
        directionsDisplay = new google.maps.DirectionsRenderer();
        var latlng = new google.maps.LatLng(<%=distance%>);
        var myOptions =
        {
            zoom: 15,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("map"), myOptions);

        directionsDisplay.setMap(map);
        directionsDisplay.setPanel(document.getElementById('directionpanel'));

        var control = document.getElementById('control');
        control.style.display = 'block';
        
        var marker = new google.maps.Marker
        (
            {
                position: new google.maps.LatLng(<%=distance%>),
                map: map,
                title: 'Click me'
            }
        );
        var infowindow = new google.maps.InfoWindow({
            content: 'District Name: <%=dis_name%>'
        });
        google.maps.event.addListener(marker, 'click', function () {
            // Calling the open method of the infoWindow 
            infowindow.open(map, marker);
        });
    }

    function calcRoute() {
        if (navigator.geolocation) { //Checks if browser supports geolocation
            navigator.geolocation.getCurrentPosition(function (position) {                                                              //This gets the
            var latitude = position.coords.latitude;                    //users current
            var longitude = position.coords.longitude;   //location
            var coords = new google.maps.LatLng(latitude, longitude); 
            var request = {
                origin: coords,
                destination: '<%=distance%>',
                travelMode: google.maps.DirectionsTravelMode.DRIVING
                };

            directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
                }
            });
        });
    }
}



    function Button1_onclick() {
        calcRoute();
    }

    window.onload = InitializeMap;
</script>
<div id="inner-info" style="width:940px; min-height:500px; height:auto; background-color:#dbdbdb; border-radius:5px; padding:20px;">
    <h3><asp:Label ID="Label14" runat="server"></asp:Label></h3>
<asp:Panel ID="Panel1" runat="server">
    <div id="topcontent">
    <div style="float:left;">
    <h1><asp:Label ID="Label1" runat="server"></asp:Label></h1>
    </div>
        <div runat="server" id="comrating" style="float:left;">
        <div style="margin-top:20px; margin-left:20px;"><asp:Label ID="Label7" runat="server"></asp:Label></div>
        </div>
        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="checkbutton" ImageUrl="~/images/checkin.png" Width="60px" Height="60px" OnClick="checkin" ToolTip="Check In" />
    <div style="float:left; margin-top:20px; margin-left:20px;">
    <h3><asp:Label ID="Label4" runat="server"></asp:Label></h3>
    </div>
    </div>
    <div style="float:left; width:800px; margin:20px; clear:both;">
        <asp:Button ID="Button5" runat="server" Text="Recommend to a friend" OnClick="Recom_Friend" CssClass="button" />
        <asp:Label ID="Label12" runat="server" CssClass="labels"></asp:Label>
    <asp:Panel ID="Panel5" runat="server" Visible="false">
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="chzn-select" Width="300px"></asp:DropDownList>
        <asp:Button ID="Button4" runat="server" CssClass="button" Text="Recommend" OnClick="Recommend" />
    </asp:Panel>
    </div>
    <div style="float:left; width:150px; margin:20px; clear:both;">
    <b>Division: </b>
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="float:left; width:180px; margin:20px;">
    <b>District: </b>
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="float:left; width:350px; margin:20px;">
    <b>Place Type: </b>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    <div class="labeldesc" style="width:910px; float:left; margin-left:20px;">
    <div style="float:right; margin-left:20px; margin-bottom:20px;">
    <asp:Image ID="Image1" CssClass="image" runat="server" />
    </div>
    <div style="clear:left;">
    <asp:Label ID="Label3" runat="server" Text="Label" CssClass="labeldesc"></asp:Label>
    <h3>Available Trips</h3>
    <ul>
        <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
        <li><a href='Trips.aspx?Tripid=<%#Eval("Tripid") %>'><%#Eval("Tripname") %></a> by 
        <a href='AgencyDetail.aspx?Agencyid=<%#Eval("Agencyid") %>'><%#Eval("Agencyname") %></a></li>
        </ItemTemplate>
        </asp:Repeater>
    </ul>
    </div>
    <table id="control" class="tables" style="margin-top:20px;">
    <tr>
    <th><input id="Button1" class="button" type="button" value="Get Directions" onclick="return Button1_onclick()" /></th>
    </tr>
    <tr>
    <td><div id ="directionpanel"  style="height: 390px; width:400px; overflow: auto;" ></div></td>
    <td><div id ="map" style="height: 390px; width: 489px; margin:20px;"></div></td>
    </tr>
    </table>
    <div class="comment" id="comment">
    <h3>Comments From Users</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_Command" OnItemDataBound="Repeater1_Bound">
        <ItemTemplate>
        <div style="width:auto; height:auto; margin-top:20px;">
        <div style="float:right;">
            <asp:Label ID="Label11" runat="server" Text='<%#Eval("Username") %>' Visible="false"></asp:Label>
            <asp:Label ID="Label10" runat="server" Text='<%#Eval("Commentid") %>' Visible="false"></asp:Label>
            <asp:Label ID="Label13" runat="server" Text='<%#Eval("datetime") %>'></asp:Label>
            <asp:ImageButton ID="ImageButton2" runat="server" CommandName="UpVote" CommandArgument='<%#Eval("Commentid") %>' ImageUrl="~/images/plus.png" Height="15px" Width="15px" ToolTip="Up Vote Comment" />
            <asp:Label ID="Label8" runat="server" Text='<%#Eval("UpVote") %>'></asp:Label>
            <asp:ImageButton ID="ImageButton3" runat="server" CommandName="DownVote" CommandArgument='<%#Eval("Commentid") %>' ImageUrl="~/images/Minus.png" Height="15px" Width="15px" ToolTip="Down Vote Comment" />
            <asp:Label ID="Label9" runat="server" Text='<%#Eval("DownVote") %>'></asp:Label>
        </div>
        <div style="float:left;">
        <asp:Image ID="Image2" ImageUrl='<%#Eval("ProPic", "~/images/ProPic/{0}") %>' Width="50px" Height="50px" runat="server" />
        </div>
        <div style="float:left; margin-left:20px;">
        <a href='Profile.aspx?Userid=<%#Eval("Userid") %>'><%#Eval("Name") %></a>
        </div><br />
        <div style="margin-left:70px; margin-right:20px; text-align:justify;"><%#Eval("Comment") %></div>
        <div style="float:right;">
        <asp:ImageButton ID="ImageButton4" runat="server" Visible="false" CommandName="Delete" CommandArgument='<%#Eval("Commentid") %>' ImageUrl="~/images/DeleteRed.png" Height="20px" Width="20px" ToolTip="Delete Comment" />
        </div>
        </div>
        <img src="images/Divider.png" width="850px" style="margin-top:10px;" alt="" />
        </ItemTemplate>
        </asp:Repeater>
    <p id="com" style="margin-top:20px;" runat="server">You must <a href="Login.aspx">Login</a> or <a href="Register.aspx">Register</a> to comment!</p>
    <asp:Panel ID="Comment" runat="server" CssClass="companel">
    <h3>Comment and Rate this Place</h3>
        <b>Rate:</b>
        <asp:RadioButtonList ID="RadioButtonList1" RepeatDirection="Horizontal" runat="server">
        <asp:ListItem Value="1">1</asp:ListItem>
        <asp:ListItem Value="2">2</asp:ListItem>
        <asp:ListItem Value="3" Selected="True">3</asp:ListItem>
        <asp:ListItem Value="4">4</asp:ListItem>
        <asp:ListItem Value="5">5</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox3" ValidationGroup="One" runat="server" ErrorMessage="Y U No Fill Up Comment Box??"></asp:RequiredFieldValidator><br />
        <asp:TextBox ID="TextBox3" TextMode="MultiLine" ValidationGroup="One" Height="150px" Width="600px" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button2" CssClass="button" Width="600px" ValidationGroup="One" runat="server" OnClick="Button2_click" Text="Post Your Comment" />
    </asp:Panel>
    </div>
    </div>
</asp:Panel>
</div>
</asp:Content>