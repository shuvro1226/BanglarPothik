<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sitemap.aspx.cs" Inherits="Sitemap" MasterPageFile="~/Site.master" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" media="screen" href="css/iPicture.css"/>
<script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
<!-- <script type="text/javascript" src="js/zepto.min-1.0.js"></script> -->
<script type="text/javascript" src="js/jquery.ipicture.js"></script>
<!-- <script type="text/javascript" src="js/zepto.ipicture.min.js"></script> -->
<style type="text/css">
#iPicture{overflow-x: hidden;
    overflow-y: visible;}
.ip_tooltip p
{
    margin:0; padding:0;
}
.titolo {
	font-family: verdana;
    width: 750px;
    font-size: 10em;
    margin: 0 auto;
    text-align: center;
    color: #fff;
    text-shadow: 0px 1px 1px #adadad,
                 0px 2px 1px #c1c1c1,
                 0px 3px 1px #bbb,
                 0px 4px 1px #b5b5b5,
                 0px 5px 1px #b1b1b1,
                 0px 6px 1px #aaa,
                 0px 7px 1px #555,
                 0px 8px 3px rgba(100, 100, 100, 0.4),
                 0px 9px 5px rgba(100, 100, 100, 0.1),
                 0px 10px 7px rgba(100, 100, 100, 0.15),
                 0px 11px 9px rgba(100, 100, 100, 0.2),
                 0px 12px 11px rgba(100, 100, 100, 0.25),
                 0px 13px 15px rgba(100, 100, 100, 0.3);
}
</style>

<script type="text/javascript">
    window.onload = function () {
        $("#iPicture").iPicture();
    };

</script>
</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div id="iPicture" data-interaction="hover">
                <asp:Panel ID="Panel1" runat="server">
                <div class="ip_slide">
					<img class="tooltipImg" id="picture1" src="images/bangladesh-political-map.jpg" alt="" width="980px" height="1339px" />
					<div class="ip_tooltip ip_img32" style="top: 480px; left: 260px;" data-animationtype="btt-slide" data-round="roundBgB" data-button="moreblack" data-tooltipbg="bgblack">
						<p><a href="Division.aspx?Division=3&Name=Rajshahi">Rajshahi Division</a></p>
						<img alt="Rajshahi" src="images/Divisions/rajshahidivision.jpg" width="300" height="395" />
					</div>
					<div class="ip_tooltip ip_img32" style="top: 440px; left: 740px;" data-animationtype="rtl-slide" data-round="roundBgB" data-button="moregold" data-tooltipbg="bgblack">
						<p><a href="Division.aspx?Division=6&Name=Sylhet">Sylhet Division</a></p>
						<img alt="Sylhet" src="images/Divisions/sylhet.gif" width="300" height="292" />
					</div>
					<div class="ip_tooltip ip_img32" style="top: 570px; left: 480px;" data-animationtype="ltr-slide" data-round="roundBgB" data-button="moregold" data-tooltipbg="bgblack">
						<p><a href="Division.aspx?Division=1&Name=Dhaka">Dhaka Division</a></p>
						<img alt="Dhaka" src="images/Divisions/dhaka_division.gif" width="300" height="380" />
					</div>
                    <div class="ip_tooltip ip_img32" style="top: 220px; left: 280px;" data-animationtype="ttb-slide" data-round="roundBgB" data-button="moreblack" data-tooltipbg="bgblack">
						<p><a href="Division.aspx?Division=8&Name=Rangpur">Rangpur Division</a></p>
						<img alt="Rangpur" src="images/Divisions/rangpurdivision.jpg" width="300" height="395" />
					</div>
					<div class="ip_tooltip ip_img32" style="top: 900px; left: 760px;" data-animationtype="rtl-slide" data-round="roundBgB" data-button="moregold" data-tooltipbg="bgblack">
						<p><a href="Division.aspx?Division=2&Name=Chittagong">Chittagong Division</a></p>
						<img alt="Chittagong" src="images/Divisions/chittagong_division.gif" width="300" height="378" />
					</div>
					<div class="ip_tooltip ip_img32" style="top: 890px; left: 490px;" data-animationtype="ttb-slide" data-round="roundBgB" data-button="moregold" data-tooltipbg="bgblack">
						<p><a href="Division.aspx?Division=5&Name=Barisal">Barisal Division</a></p>
						<img alt="Barisal" src="images/Divisions/barisal_division.gif" width="300" height="380" />
					</div>
					<div class="ip_tooltip ip_img32" style="top: 830px; left: 300px;" data-animationtype="rtl-slide" data-round="roundBgB" data-button="moregold" data-tooltipbg="bgblack">
						<p><a href="Division.aspx?Division=4&Name=Khulna">Khulna Division</a></p>
						<img alt="Khulna" src="images/Divisions/khulna_division.gif" width="300" height="383" />
					</div>
				</div>
                </asp:Panel>
			</div>
    
</asp:Content>