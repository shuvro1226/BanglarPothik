<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContentPage.aspx.cs" MasterPageFile="~/Site.master" Inherits="ContentPage" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
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
            zoom: 8,
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
            content: 'District Name: <%=dis_name%><br/>LatLng: <%=distance%>'
        });
        google.maps.event.addListener(marker, 'click', function () {
            // Calling the open method of the infoWindow 
            infowindow.open(map, marker);
        });
    }

    function calcRoute() {
            
        if (navigator.geolocation) { //Checks if browser supports geolocation
            navigator.geolocation.watchPosition(function (position) {                                                              //This gets the
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
<h1><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> Zilla</h1>

    <div style="float:left; width:150px; margin:20px;">
    <b>Division: </b>
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="float:left; width:250px; margin:20px;">
    <b>Area(In Square KMs): </b>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="float:left; width:400px; margin:20px;">
    <b>Principal Rivers: </b>
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    </div>
    <div class="labeldesc" style="width:910px; float:left; margin-left:20px;">
    <div style="float:right; margin-left:20px; margin-bottom:20px;">
    <asp:Image ID="Image1" CssClass="image" runat="server" /></div>
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <h3>Recommended Places</h3>
    <ul>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <li><a href='Place.aspx?Place=<%#Eval("Place_id") %>'><%#Eval("Place_name") %></a></li>
        </ItemTemplate>
        </asp:Repeater>
    </ul>
    <h3>Available Trips</h3>
    <ul>
        <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
        <li><a href='Trips.aspx?Tripid=<%#Eval("Tripid") %>'><%#Eval("Tripname") %></a> by 
        <a href='AgencyDetail.aspx?Agencyid=<%#Eval("Agencyid") %>'><%#Eval("Agencyname") %></a></li>
        </ItemTemplate>
        </asp:Repeater>
    </ul>
    
    <table id ="control">
    <tr>
    <th><input id="Button1" class="button" type="button" value="Get Directions" onclick="return Button1_onclick()" /></th>
    </tr>
    <tr>
    <td valign="top"><div id ="directionpanel"  style="height: 390px; width:400px; overflow: auto;" ></div></td>
    <td valign="top"><div id ="map" style="height: 390px; width: 489px; margin:20px;"></div></td>
    </tr>
    </table>
    </div>
</div>
</asp:Content>