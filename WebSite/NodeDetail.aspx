<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NodeDetail.aspx.cs" Inherits="NodeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>贵阳法治地图</title>
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/NodeDetail.js"></script>
    <script src="Scripts/jquery.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=7jX0fH8U0LAyWrd6Lp4HQXYalxfXvZvk"></script>
    <link rel="stylesheet" type="text/css" href="Styles/NodeDetail.css" />
    <link  rel="stylesheet"type="text/css" href="Styles/bootstrap.min.css" media="all" />
</head>
<body>
    <div class="container" style="width:100%; height:inherit">
		<div class="org-title">
			<h3 id="org_title"><asp:label ID="label_title" runat="server" Font-Bold="True" Font-Size="Medium"></asp:label></h3>
		</div>

<div id="navigation_map" style="height:300px; width:100%"></div>
<div id="r-result"></div>

        <table class="table">
            <tr>
				<td id="org_addr">地址:<asp:Label ID="label_addr" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td id="org_tel">电话:<strong><asp:Literal ID="Literal_tel" runat="server"></asp:Literal></strong><small>(点击直接拔打)</small></td>
			</tr>
			 <%--<tr id="lawyerInfo_tr" style="display: table-row;">
				<td id="lawyerInfo"><dl><dt>顾问律师</dt><dd>姓名:XXX</dd><dd>手机:<a href="tel:12345678901">12345678901</a></dd><dd>所在律所:xxx</dd></dl></td>
			</tr>--%>
			<tr>
				<%--<td id="user_addr">正在定位您的位置</td>--%>
			</tr>
			
			<tr>
			<td>
				<div class="row">	<div class="col-xs-4">
						<div class="btn-group">
							<button class="btn btn-primary btn-outline  dropdown-toggle"
								data-toggle="dropdown"><i class="fa fa-subway"></i>
								公 交 <span class="caret"></span>
							</button>
							<ul class="dropdown-menu">
								<li><a href="#"  onclick="busRoute(0)">用时最少</a></li>
								<li><a href="#"  onclick="busRoute(1)">最少换乘</a></li>
								<li><a href="#"  onclick="busRoute(2)">最少步行</a></li>
								

							</ul>
						</div>
					</div>
					<div class="col-xs-4">
						<div class="btn-group">
							<button class="btn btn-success  btn-outline dropdown-toggle"
								data-toggle="dropdown"><i class="fa fa-car"></i>
								驾 车 <span class="caret"></span>
							</button>
							<ul class="dropdown-menu">
								<li><a href="#" onclick="drivingRoute(0)">最少时间</a></li>
								<li><a href="#" onclick="drivingRoute(1)">最短距离</a></li>
								<li><a href="#" onclick="drivingRoute(2)">避开高速</a></li>
							</ul>
						</div>
					</div>
					<div class="col-xs-4">
						<div class="btn-group">
							<button class="btn btn-default  btn-outline" onclick="walkingRoute()">
							    <i class="fa fa-male"></i>步 行
							</button>
						</div>
					</div>
				</div>
			</td>
			</tr>
        </table>
        <label id="Label_Lng"></label>
        <label id="Label_Lat"></label>
	</div>
    <script>
        var e_lng = "<%=Get_e_Lng()%>";
        var e_lat = "<%=Get_e_Lat()%>";
        var s_lng;
        var s_lat;
        
        var map = new BMap.Map("navigation_map");            // 创建Map实例
        map.clearOverlays(); 
        map.centerAndZoom(new BMap.Point(e_lng, e_lat), 12);

        var e_point = new BMap.Point(e_lng, e_lat);
        map.addOverlay(new BMap.Marker(e_point));

        getLocation();

        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition, showError);
            }
            else { alert("Geolocation is not supported by this browser."); }
        }

        function showPosition(position) {
            s_lng = position.coords.longitude;
            s_lat = position.coords.latitude;

            var ggpoint = new BMap.Point(s_lng, s_lat);
            var convertor = new BMap.Convertor();
            //alert(ggpoint.lng + ";" + ggpoint.lat + "::" + e_lng + ";" + e_lat);
var pointArr = [];
pointArr.push(ggpoint);
            convertor.translate(pointArr, 1, 5, translateCallback)

            // 未修正坐标
            //var s_point = new BMap.Point(s_lng, s_lat);
            //map.addOverlay(new BMap.Marker(s_point));
            
        }

        translateCallback = function (data) {
            if (data.status === 0) {
                s_lng = data.points[0].lng;
                s_lat = data.points[0].lat;

                var marker = new BMap.Marker(data.points[0]);
                map.addOverlay(marker);
                //var label = new BMap.Label("转换后的百度标注", { offset: new BMap.Size(20, -10) });
                //marker.setLabel(label); //添加百度label
                map.setCenter(data.points[1]);
              map.getLocation(s_lng, s_lat);
            }
        }

        function showError(error) {
            switch (error.code) {
                case error.PERMISSION_DENIED:
                    alert("User denied the request for Geolocation.");
                    break;
                case error.POSITION_UNAVAILABLE:
                    alert("Location information is unavailable.");
                    break;
                case error.TIMEOUT:
                    alert("The request to get user location timed out.");
                    break;
                case error.UNKNOWN_ERROR:
                    alert("An unknown error occurred.");
                    break;
            }
        }

        function walkingRoute() {
            var map = new BMap.Map("navigation_map");
            map.centerAndZoom(new BMap.Point(e_lng, e_lat), 11);
            //var s_lng = document.getElementById("Label_Lng").innerText;
            //var s_lat = document.getElementById("Label_Lat").innerText;
            var p1 = new BMap.Point(s_lng, s_lat);
            var p2 = new BMap.Point(e_lng, e_lat);
            var walking = new BMap.WalkingRoute(map, {
                renderOptions: { map: map, panel: "r-result", autoViewport: true }
            });
            walking.search(p1, p2);
            
        }

        function busRoute(i) {

            var map = new BMap.Map("navigation_map");            // 创建Map实例
            map.centerAndZoom(new BMap.Point(e_lng, e_lat), 12);
            //var s_lng = document.getElementById("Label_Lng").innerText;
            //var s_lat = document.getElementById("Label_Lat").innerText;
            var p1 = new BMap.Point(s_lng, s_lat);
            var p2 = new BMap.Point(e_lng, e_lat);
            var routePolicy = [BMAP_TRANSIT_POLICY_LEAST_TIME,BMAP_TRANSIT_POLICY_LEAST_TRANSFER,BMAP_TRANSIT_POLICY_LEAST_WALKING,BMAP_TRANSIT_POLICY_AVOID_SUBWAYS];
     
            var transit = new BMap.TransitRoute(map, {
                renderOptions: { map: map, panel: "r-result"},
policy:0
            });
map.clearOverlays(); 

search(p1, p2,routePolicy[i]);
function search(p1,p2,route){ 
			transit.setPolicy(route);
			transit.search(p1,p2);}




        }

        function drivingRoute(i) {

          
            var map = new BMap.Map("navigation_map");
            map.centerAndZoom(new BMap.Point(e_lng, e_lat), 11);
            //var s_lng = document.getElementById("Label_Lng").innerText;
            //var s_lat = document.getElementById("Label_Lat").innerText;
            var p1 = new BMap.Point(s_lng, s_lat);
            var p2 = new BMap.Point(e_lng, e_lat);
var routePolicy = [BMAP_DRIVING_POLICY_LEAST_TIME,BMAP_DRIVING_POLICY_LEAST_DISTANCE,BMAP_DRIVING_POLICY_AVOID_HIGHWAYS];
            var driving = new BMap.DrivingRoute(map, {
                renderOptions: { map: map, panel: "r-result"}, 
                policy: 0
            });
map.clearOverlays(); 
            search(p1, p2,routePolicy[i]);
function search(p1,p2,route){ 
			driving.setPolicy(route);
			driving.search(p1,p2);}
        }
    </script>
</body>
</html>
