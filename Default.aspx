<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="~/Site.master" Inherits="_Default" EnableViewStateMac="false" EnableEventValidation="false" %>

<asp:Content ID="defhead" ContentPlaceHolderID="head" runat="server">
        
        <style type="text/css">
            ul.subscribe { margin:0 10px; overflow-y:scroll; height:170px; }
            ul.agency { margin:0 10px; overflow-y:scroll; height:180px; }
            li { list-style-type:none; font-size:12px; }
            ::-webkit-scrollbar { width: 15px; }
            ::-webkit-scrollbar-track { background-color: #d14f22; } 
            ::-webkit-scrollbar-thumb { background-color: rgba(0, 0, 0, 0.2); }
            ::-webkit-scrollbar-button { background-color: #8f3617; } 
            ::-webkit-scrollbar-corner { background-color: black; }
            
            
            .viewport {
    border: 3px solid #eee;
    float: left;
    height: 268px;
    margin: 0 9px 9px 0;
    overflow: hidden;
    position: relative;
    width: 234px;
}

/* This is so that the 2nd thumbnail in each row fits snugly. You will want to add a similar
   class to the last thumbnail in each row to get rid of the margin-right. */
.no-margin {
    margin-right: 0;
}

/* --- Link configuration that contains the image and label ----------------------------- */
.viewport a {
    display: block;
    position: relative;
}

.viewport a img {
    height: 300px;
    left: -20px;
    position: relative;
    top: -20px;
    width: 260px;
}

/* --- Label configuration -------------------------------------------------------------- */
.viewport a span {
    display: none;
    font-size: 1.2em;
    font-weight: bold;
    height: 100%;
    padding-top: 60px;
    position: absolute;
    text-align: center;
    text-decoration: none;
    width: 100%;
    z-index: 100;
}
    .viewport a span em {
        display: block;
        font-size: 0.6em;
        font-weight: normal;
    }

/* --- Dark hover background ------------------------------------------------------------ */
.dark-background {
    background-color: rgba(15, 15, 15, 0.6);
    color: #fff;
    text-shadow: #000 0px 0px 20px;
}
    .dark-background em {
        color: #ccc;
    }

            
            
            #content {
				margin: 20px;
						}

			h1 {
				font-size: 2em;
				margin-bottom: 30px;
				}

			#content a:link, #content a:visited, #content a:hover, #content a:active {
				color: #ff5c43;
				}

			em {
				font-style: italic;
				}
			
			#container {
				width: 940px;
				position: relative;
				margin: 0 auto;
			}
			
			#carousel {
				width: 780px;
				margin: 0 auto;
			}
			
			#ui-carousel-next, #ui-carousel-prev {
				width: 60px;
				height: 240px;
				background: url(images/arrow-left.png) #fff center center no-repeat;
				display: block;
				position: absolute;
				top: 0;
				z-index: 100;
			}

			#ui-carousel-next {
				right: 0;
				background-image: url(images/arrow-right.png);
			}

			#ui-carousel-prev {
				left: 0;
			}
			
			#ui-carousel-next > span, #ui-carousel-prev > span {
				display: none;
			}
			
			.slide {
				margin: 0;
				position: relative;
			}
			
			.slide  h1 {
				font: 72px/1 Anton, sans-serif;
				color: #ff5c43;
				margin: 0;
				padding: 0;
			}
			
			.slide  p {
				font: 32px/1 Ubuntu, sans-serif;	
				color: #4d4d4d;
				margin: 0;
				padding: 0;
			}
			
			#slide01 > img {
				position: absolute;
				bottom: 25px;
				left: 50px;
			}
			
			#slide01 > .text {
				position: absolute;
				left: 380px;
				bottom: 35px;
			}
			
			#slide02 > img {
				position: absolute;
				bottom: 10px;
				left: 30px;
			}
			
			#slide02 > .text {
				position: absolute;
				left: 350px;
				bottom: 25px;
			}
			
			#slide03 > img {
				position: absolute;
				bottom: 25px;
				left: 30px;
			}
			
			#slide03 > .text {
				position: absolute;
				left: 270px;
				bottom: 25px;
			}
			
			#slide04 > img {
				position: absolute;
				bottom: 0px;
				left: 20px;
			}
			
			#slide04 > .text {
				position: absolute;
				left: 290px;
				bottom: 25px;
			}
			
			#slide05 > img {
				position: absolute;
				bottom: 20px;
				left: 30px;
			}
			
			#slide05 > .text {
				position: absolute;
				left: 350px;
				bottom: 35px;
			}
			
			#slide06 > img {
				position: absolute;
				bottom: 10px;
				left: 20px;
			}
			
			#slide06 > .text {
				position: absolute;
				left: 290px;
				bottom: 35px;
			}
			
			#pages {
				width: 150px;
				margin: 0 auto;
			}
			
			.bullet {
				background: url(images/page-off.png) center center no-repeat;
				display: block;
				width: 18px;
				height: 18px;
				margin: 0;
				margin-right: 5px;
				float: left;				
			}
        </style>

        <link href='http://fonts.googleapis.com/css?family=Anton|Ubuntu' rel='stylesheet' type='text/css'/>
		<link rel="stylesheet" type="text/css" href="css/style.css" />
        <link rel="stylesheet" type="text/css" href="css/rcarousel.css" />
        <link rel="stylesheet" type="text/css" href="css/StyleSheet.css" />
        <link rel="stylesheet" type="text/css" href="css/fallback.css" />
	    <link rel="stylesheet" type="text/css" href="css/component.css" />
        
		<!--[if lt IE 9]>
			<link rel="stylesheet" type="text/css" href="css/fallback.css" />
		<![endif]-->
		
		<script src="js/modernizr.custom.js"></script>
        <script type="text/javascript" src="js/modernizr.custom.26633.js"></script>
        <script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
		<script type="text/javascript">		    var jQuery171 = jQuery.noConflict(); </script>
		<script type="text/javascript" src="js/jquery.ui.core.js"></script>
		<script type="text/javascript" src="js/jquery.ui.widget.js"></script>
		<script type="text/javascript" src="js/jquery.ui.rcarousel.js"></script>
		<script type="text/javascript">
		    jQuery171(function ($) {
		        function generatePages() {
		            var _total, i, _link;

		            _total = $("#carousel").rcarousel("getTotalPages");

		            for (i = 0; i < _total; i++) {
		                _link = $("<a href='#'></a>");

		                $(_link)
							.bind("click", { page: i },
								function (event) {
								    $("#carousel").rcarousel("goToPage", event.data.page);
								    event.preventDefault();
								}
							)
							.addClass("bullet off")
							.appendTo("#pages");
		            }

		            // mark first page as active
		            $("a:eq(0)", "#pages")
						.removeClass("off")
						.addClass("on")
						.css("background-image", "url(images/page-on.png)");

		        }

		        function pageLoaded(event, data) {
		            $("a.on", "#pages")
						.removeClass("on")
						.css("background-image", "url(images/page-off.png)");

		            $("a", "#pages")
						.eq(data.page)
						.addClass("on")
						.css("background-image", "url(images/page-on.png)");
		        }

		        $("#carousel").rcarousel(
					{
					    visible: 1,
					    step: 1,
					    speed: 700,
					    auto: {
					        enabled: true
					    },
					    width: 780,
					    height: 240,
					    start: generatePages,
					    pageLoaded: pageLoaded
					}
				);

		        $("#ui-carousel-next")
					.add("#ui-carousel-prev")
					.add(".bullet")
					.hover(
						function () {
						    $(this).css("opacity", 0.7);
						},
						function () {
						    $(this).css("opacity", 1.0);
						}
					);
		    });
		</script>
        <script type="text/ecmascript">
            jQuery171(document).ready(function ($) {
                $('.viewport').mouseenter(function (e) {
                    $(this).children('a').children('img').animate({ height: '268', left: '0', top: '0', width: '234' }, 100);
                    $(this).children('a').children('span').fadeIn(200);
                }).mouseleave(function (e) {
                    $(this).children('a').children('img').animate({ height: '300', left: '-20', top: '-20', width: '260' }, 100);
                    $(this).children('a').children('span').fadeOut(200);
                });
            });
        </script>

</asp:Content>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
		<script type="text/javascript">		    var jQuery183 = jQuery.noConflict(); </script>
        <script type="text/javascript" src="js/jquery.gridrotator.js"></script>
        <script type="text/javascript">
    jQuery183(function ($) {

        $('#ri-grid').gridrotator({
            w320: {
                rows: 3,
                columns: 4
            },
            w240: {
                rows: 3,
                columns: 3
            },
            nochange: [],
            preventClick: false
        });

    });
		</script>


<div id="content">
			<div id="container">
				<div id="carousel">
					<div id="slide01" class="slide">
						<img src="images/0217_WVinternet.jpg" alt="jQuery UI logo" />
						<div class="text">
							<h1>search<br />and find</h1>
							<p>places and trips</p>
						</div>
					</div>
					
					<div id="slide02" class="slide">
						<img src="images/url.jpg" alt="any content" />
						<div class="text">
							<h1>check in <br />places</h1>
							<p>you already visited</p>
						</div>
					</div>
					
					<div id="slide03" class="slide">
						<img src="images/addafriendlogo.jpg" alt="horizontal and vertical carousel" />
						<div class="text">
							<h1>add <br />friend and</h1>
							<p>recommend places to them</p>
						</div>
					</div>
					
					<div id="slide04" class="slide">
						<img src="images/Information.jpg" alt="multi carousels" />
						<div class="text">
							<h1>detailed<br />information on</h1>
							<p>divisions, districts and places</p>
						</div>
					</div>
					
					<div id="slide05" class="slide">
						<img src="images/url.png" alt="customization" />
						<div class="text">
							<h1>top travel<br />agencies</h1>
							<p>with available trips detail</p>
						</div>
					</div>
					
					<div id="slide06" class="slide">
						<img src="images/comments.png" alt="multi browser support" />
						<div class="text">
							<h1>comment<br />and rate</h1>
							<p>on places to share experience</p>
						</div>
					</div>					
				</div>
				<a href="#" id="ui-carousel-next"><span>next</span></a>
				<a href="#" id="ui-carousel-prev"><span>prev</span></a>
				<div id="pages"></div>
			</div>
		</div>

<div style="width:1000px; padding:50px;">
                <div id="nl-form" class="nl-form" style="float:left; width:600px;">
					I am looking for
                    <asp:DropDownList ID="DropDownList5" runat="server" CssClass="drpdown" AppendDataBoundItems="true"></asp:DropDownList>
					<br />in 
					<asp:DropDownList ID="DropDownList2" runat="server" CssClass="drpdown" AppendDataBoundItems="true">
                    </asp:DropDownList> District(s)
					<br />and in 
					<asp:DropDownList ID="DropDownList1" runat="server" CssClass="drpdown" AppendDataBoundItems="true">
                    </asp:DropDownList> Division(s).
					<div class="nl-overlay"></div>
                    <p>(*) Select at least 1 filter</p>
				</div>
                <div style="float:left; width:400px;">
                <img src="images/find.png" alt="" height="200px" width="200px" />
                </div>
                <asp:Button ID="Button1" runat="server" Text="Find Place" Width="200px" CssClass="button" OnClick="Button1_Click" />
</div>

<div style="width:240px; float:left; clear:both; margin-right:10px;">
<div id="inner-info" style="width:240px; height:600px; float:left; margin-right:10px;">
<div style="text-align:center;">
    <asp:Label ID="Label1" runat="server" CssClass="labels" Visible="false" Text="Select one or more filters"></asp:Label>
</div>
<p class="innerinfo">Find a suitable trip for you</p>
<div style="text-align:center;">
    <asp:Label ID="Label3" runat="server" CssClass="labels" Text="Select one or more filters as needed"></asp:Label>
</div>

<div class="column" style="width:180px;">
<p>District</p>
    <asp:DropDownList ID="DropDownList6" Width="200px" CssClass="chzn-select" runat="server">
    </asp:DropDownList>
</div>
<div class="column" style="width:180px;">
<p>Place</p>
    <asp:DropDownList ID="DropDownList7" Width="200px" CssClass="chzn-select" runat="server">
    </asp:DropDownList>
</div>
<div class="column" style="width:180px;">
<p>Maximum Cost (BDT)</p>
    <asp:DropDownList ID="DropDownList4" Width="200px" CssClass="chzn-select" runat="server" OnSelectedIndexChanged="Max_Changed" AutoPostBack="true">
    <asp:ListItem Value="0">Select</asp:ListItem>
    <asp:ListItem Value="1000">1000</asp:ListItem>
    <asp:ListItem Value="2000">2000</asp:ListItem>
    <asp:ListItem Value="4000">4000</asp:ListItem>
    <asp:ListItem Value="6000">6000</asp:ListItem>
    <asp:ListItem Value="8000">8000</asp:ListItem>
    <asp:ListItem Value="10000">10000</asp:ListItem>
    <asp:ListItem Value="12000">12000</asp:ListItem>
    <asp:ListItem Value="14000">14000</asp:ListItem>
    <asp:ListItem Value="16000">16000</asp:ListItem>
    <asp:ListItem Value="18000">18000</asp:ListItem>
    <asp:ListItem Value="20000">20000</asp:ListItem>
    </asp:DropDownList>
</div>
<div class="column" style="width:180px;">
<p>Minimum Cost (BDT)</p>
    <asp:DropDownList ID="DropDownList3" Width="200px" CssClass="chzn-select" runat="server">
    <asp:ListItem Value="0">Select</asp:ListItem>
    <asp:ListItem Value="1000">1000</asp:ListItem>
    <asp:ListItem Value="2000">2000</asp:ListItem>
    <asp:ListItem Value="4000">4000</asp:ListItem>
    <asp:ListItem Value="6000">6000</asp:ListItem>
    <asp:ListItem Value="8000">8000</asp:ListItem>
    <asp:ListItem Value="10000">10000</asp:ListItem>
    <asp:ListItem Value="12000">12000</asp:ListItem>
    <asp:ListItem Value="14000">14000</asp:ListItem>
    <asp:ListItem Value="16000">16000</asp:ListItem>
    </asp:DropDownList>
</div>
<div class="column" style="width:180px;">
<p>Trip Type</p>
    <asp:DropDownList ID="DropDownList8" Width="200px" CssClass="chzn-select" runat="server">
    </asp:DropDownList>
</div>
<div class="column" style="margin-right:20px; margin-top:20px;">
    <asp:Button ID="Button3" runat="server" Text="Find Trip" Width="200px" CssClass="button" OnClick="Button3_Click" />
</div>
</div>
</div>

<div style="width:728px; float:left;">
<div id="inner-info" style="width:726px; float:left; height:325px; margin-top:10px;">
<p class="innerinfo">Featured Trips</p>
<div style="float:left; width:234px; height:268px; margin-right:8px; margin-top:-20px;">
<div class="viewport">
    <a href="Trips.aspx?Tripid=12">
        <span class="dark-background">Bengal Archeology Tour <em>Powered By: Autarky Tours</em></span>
        <img src="images/Place/Mahasthan Garh.jpg" alt="Northern Saw-Whet Owl" />
    </a>
</div>
<div style="position:absolute; margin-left:3px; margin-top:200px;">
<img src="images/Tripcost.png" alt="" style="position:absolute;" />
</div>
<div style="position:absolute; margin-left:3px; margin-top:3px;">
<img src="images/Archeology.png" alt="" style="position:absolute;" />
</div>
</div>
<div style="float:left; width:234px; height:268px; margin-right:8px; margin-top:-20px;">
<div class="viewport">
    <a href="Trips.aspx?Tripid=4">
        <span class="dark-background">Dhaka-Chittagong-Bandarban <em>Powered By: Western Holidays</em></span>
        <img src="images/Place/Nilgiri.jpg" alt="Northern Saw-Whet Owl" />
    </a>
</div>
<div style="position:absolute; margin-left:3px; margin-top:200px;">
<img src="images/Tripcost.png" alt="" style="position:absolute;" />
</div>
<div style="position:absolute; margin-left:3px; margin-top:3px;">
<img src="images/Hills-and-Sea.png" alt="" style="position:absolute;" />
</div>
</div>
<div style="float:left; width:234px; height:268px; margin-top:-20px;">
<div class="viewport">
    <a href="Trips.aspx?Tripid=5">
        <span class="dark-background">Sundarbans Forest Trips <em>Powered By: Travel Bangladesh Limited</em></span>
        <img src="images/Place/sundarban (4).jpg" alt="Northern Saw-Whet Owl" />
    </a>
</div>
<div style="position:absolute; margin-left:3px; margin-top:200px;">
<img src="images/Tripcost.png" alt="" style="position:absolute;" />
</div>
<div style="position:absolute; margin-left:3px; margin-top:3px;">
<img src="images/Forest.png" alt="" />
</div>
</div>

</div>
<div id="inner-info" style="width:470px; height:264px; margin-right:10px; float:left; margin-top:0px;">
<p class="innerinfo">Friends Updates</p>
    <ul class="subscribe" style="margin-top:0px;">
    <div style="margin-left:20px; margin-right:20px;"><asp:Label ID="Label2" runat="server" CssClass="labels"></asp:Label></div>
    <asp:Repeater ID="Repeater2" runat="server">
    <ItemTemplate>
    <li>
        <a href='Profile.aspx?Userid=<%#Eval("Userid") %>'><%#Eval("Name") %></a> <%#Eval("status") %> <a href='Place.aspx?Place=<%#Eval("Place_id") %>'><%#Eval("Place_name") %></a>
        <img src="images/Divider.png" alt="" style="margin-left:-20px; width:470px;" />
    </li>
    </ItemTemplate>
    </asp:Repeater>
    </ul>
</div>
<div id="inner-info" style="width:244px; height:264px; float:left; margin-top:0px;">
<p class="innerinfo">Top Travel Agents</p>
<ul class="agency">
<div id="jp-container" class="jp-container">
    <asp:Repeater ID="Repeater3" runat="server">
    <ItemTemplate>
    <li>
        <a href='AgencyDetail.aspx?Agencyid=<%#Eval("Agencyid") %>'><%#Eval("Agencyname") %></a>
        <img src="images/Divider.png" alt="" width="200px" />
    </li>
    </ItemTemplate>
    </asp:Repeater>
</div>
</ul>
<div class="clr"></div>
</div>
</div>
<div id="ri-grid" style="width:978px; height:380px; float:left;" class="ri-grid ri-grid-size-1 ri-shadow">
					<ul>
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
						<li>
                            <a href='Place.aspx?Place=<%#Eval("Placeid") %>' title='<%#Eval("Place_name") %>'>
                            <asp:Image ID="Image1" ImageUrl='<%#Eval("Image", "~/images/ImageGrid/{0}") %>' ToolTip='<%#Eval("Place_name") %>' runat="server" /></a>
                        </li>
                        </ItemTemplate>
                        </asp:Repeater>
					</ul>
</div>

		<script src="js/nlform.js"></script>
		<script>
		    var nlform = new NLForm(document.getElementById('nl-form'));
		</script>

</asp:Content>