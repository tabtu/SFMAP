<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detail.aspx.cs" Inherits="NodeDetail" %>

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
    <script type="text/javascript" src="http://api.tianditu.com/api?v=4.0"></script>
    <link rel="stylesheet" type="text/css" href="Styles/NodeDetail.css" />
    <link rel="stylesheet" type="text/css" href="Styles/bootstrap.min.css" media="all" />
</head>
<body onload="onLoad()">
    <div class="container" style="width:100%; height:inherit">
		<div class="org-title">
            <h3 id="org_title">
                <asp:label ID="label_title" runat="server" Font-Bold="True" Font-Size="Medium"></asp:label>
            </h3>
		</div>
        <div id="navigation_map" style="height:300px; width:100%"></div>
        <div id="resultDiv"></div>
	<input type="text" id="start" value="" />
	<input type="text" id="end" value="" />
        <table class="table">
            <tr>
				<td id="org_addr">地址:<asp:Label ID="label_addr" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td id="org_tel">电话:<strong><asp:Literal ID="Literal_tel" runat="server"></asp:Literal></strong><small>(点击直接拔打)</small></td>
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
								<li><a href="#" onclick="searchBusRoute(1)">较快捷</a></li>
								<li><a href="#" onclick="searchBusRoute(2)">少换乘</a></li>
								<li><a href="#" onclick="searchBusRoute(4)">少步行</a></li>
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
								<li><a href="#" onclick="searchDrivingRoute(0)">最少时间</a></li>
								<li><a href="#" onclick="searchDrivingRoute(1)">最短距离</a></li>
								<li><a href="#" onclick="searchDrivingRoute(2)">避开高速</a></li>
							</ul>
						</div>
					</div>
					<div class="col-xs-4">
						<div class="btn-group">
							<button class="btn btn-default  btn-outline" onclick="searchBusRoute(8)">
							    <i class="fa fa-male"></i>步 行
							</button>
						</div>
					</div>
				</div>
			</td>
			</tr>
        </table>
	</div>
    <script>
        document.getElementById("end").value = "<%=Get_e_Lng()%>" + "," + "<%=Get_e_Lat()%>";

        var zoom = 12;
        var map, drivingRoute;
        var startLngLat, endLngLat;

        var startIcon = "http://lbs.tianditu.com/images/bus/start.png";	//起点图标
        var endIcon = "http://lbs.tianditu.com/images/bus/end.png";		//终点图标
        var map_bus = "http://lbs.tianditu.com/images/bus/map_bus.png";
        var map_metro = "http://lbs.tianditu.com/images/bus/map_metro.png";

        document.getElementById("start").style.display = "none";
        document.getElementById("end").style.display = "none";

        function onLoad() {
            //document.getElementById("start").value = "106.713783,26.581161";
            //document.getElementById("end").value = "106.681557,26.565083";
			
            // H5 GPS
            var lo = new T.Geolocation();
            fn = function (e) {
                if (this.getStatus() == 0) {
                    document.getElementById("start").value = e.lnglat.lng + "," + e.lnglat.lat;
                    var marker = new T.Marker(e.lnglat);
                    map.addOverLay(marker);
                }
                if (this.getStatus() == 1) {
                    document.getElementById("start").value = e.lnglat.lng + "," + e.lnglat.lat;
                    var marker = new T.Marker(e.lnglat);
                    map.addOverLay(marker);
                }
            }
            lo.getCurrentPosition(fn);
            
            map = new T.Map("navigation_map");
            var tmp = document.getElementById("end").value.split(",");
            endLngLat = new T.LngLat(tmp[0], tmp[1]);
            map.centerAndZoom(endLngLat, zoom);
            var marker = new T.Marker(endLngLat);
            map.addOverLay(marker);

            var configdrive = { policy: 0, onSearchComplete: searchResult };
            drivingRoute = new T.DrivingRoute(map, configdrive);

            var configbus = { policy: 1, onSearchComplete: busSearchResult };
            transitRoute = new T.TransitRoute(map, configbus);
        }

        // 驾车导航
        function searchDrivingRoute(policy) {
            document.getElementById("resultDiv").innerHTML = "";
            map.clearOverLays();
            var startVal = document.getElementById("start").value.split(",");
            startLngLat = new T.LngLat(startVal[0], startVal[1]);
            var endVal = document.getElementById("end").value.split(",");
            endLngLat = new T.LngLat(endVal[0], endVal[1]);

            drivingRoute.setPolicy(policy);
            drivingRoute.search(startLngLat, endLngLat);
        }

        function searchResult(result) {
            createStartMarker(result);

            obj = result;
            var resultList = document.createElement("div");
            var routes = result.getNumPlans();
            for (var i = 0; i < routes; i++) {
                var plan = result.getPlan(i);
                var div = document.createElement("div");
                div.style.cssText = "font-size:12px; cursor:pointer; border:1px solid #999999";
                var describeStr = "<strong>总时间：" + plan.getDuration() + "秒，总距离：" + Math.round(plan.getDistance()) + "公里</strong>";
                describeStr += "<div><img src='" + startIcon + "'/>" + document.getElementById("start").value + "</div>";
                var numRoutes = plan.getNumRoutes();
                for (var m = 0; m < numRoutes; m++) {
                    var route = plan.getRoute(m);
                    describeStr += (m + 1) + ".<span>" + route.getDescription() + "</span><br/>"
                    var numStepsStr = "";
                    var numSteps = route.getNumSteps();
                    for (var n = 0; n < numSteps; n++) {
                        var step = route.getStep(n);
                        numStepsStr += "<p>" + (n + 1) + ")<a href='javascript://' onclick='showPosition(\"" + step.getPosition().getLng() + "\",\"" + step.getPosition().getLat() + "\",\"" + step.getDescription() + "\");'>" + step.getDescription() + "</a></p>";
                    }
                    describeStr += numStepsStr;
                }
                describeStr += "<div><img src='" + endIcon + "'/>" + document.getElementById("end").value + "</div>";
                div.innerHTML = describeStr;
                resultList.appendChild(div);
                createRouteDrive(plan.getPath());
                map.setViewport(plan.getPath());
            }
            document.getElementById("resultDiv").appendChild(resultList);
        }

        function createRouteDrive(lnglats, lineColor) {
            var line = new T.Polyline(lnglats, { color: "#2C64A7", weight: 5, opacity: 0.9 });
            map.addOverLay(line);
        }

        function createStartMarker(result) {
            var startMarker = new T.Marker(result.getStart(), {
                icon: new T.Icon({
                    iconUrl: startIcon,
                    iconSize: new T.Point(44, 34),
                    iconAnchor: new T.Point(12, 31)
                })
            });
            map.addOverLay(startMarker);
            var endMarker = new T.Marker(result.getEnd(), {
                icon: new T.Icon({
                    iconUrl: endIcon,
                    iconSize: new T.Point(44, 34),
                    iconAnchor: new T.Point(12, 31)
                })
            });
            map.addOverLay(endMarker);
        }

        function showPosition(lng, lat, des) {
            if (infoWin) {
                map.removeOverLay(infoWin);
                infoWin = null;
            }
            var lnglat = new T.LngLat(lng, lat);
            infoWin = new T.InfoWindow(des, new T.Point([0, 0]));
            infoWin.setLngLat(lnglat);
            map.addOverLay(infoWin);
        }

        // 公交搜索
        function searchBusRoute(policy) {
            document.getElementById("resultDiv").innerHTML = "";
            map.clearOverLays();

            var startVal = document.getElementById("start").value.split(",");
            startLngLat = new T.LngLat(startVal[0], startVal[1]);
            var endVal = document.getElementById("end").value.split(",");
            endLngLat = new T.LngLat(endVal[0], endVal[1]);

            transitRoute.setPolicy(policy);
            transitRoute.search(startLngLat, endLngLat);
        }

        function busSearchResult(result) {
            if (transitRoute.getStatus() == 0) {
                createStartMarker();
                obj = result;
                var resultList = document.createElement("div");
                var plans = result.getNumPlans();
                for (var i = 0; i < plans; i++) {
                    var plan = result.getPlan(i);
                    map.clearOverLays();
                    createStartMarker();
                    createSegments(obj.getPlan(i));
                    if (i == 0) {
                        createSegments(result.getPlan(0));
                    }
                }
            }
        }

        function createSegments(plan, planNum) {
            var segmentNum = plan.getNumSegments();
            for (var m = 0; m < segmentNum; m++) {
                var line = plan.getDetails(m);
                var segmentLine = line.getSegmentLine()[0];
                createRouteBus(segmentLine.linePoint, line.getSegmentType(), line.getStationStart().lonlat, line.getStationEnd().lonlat);
                createMarker(line.getStationStart().lonlat, line.getStationEnd().lonlat, line.getSegmentType());
            }
        }

        function createMarker(lnglatStartStr, lnglatEndStr, type) {
            var icon1;
            if (type == 2)
            {
                icon1 = new T.Icon({
                    iconUrl: map_bus,
                    iconSize: new T.Point(23, 23),
                    iconAnchor: new T.Point(12, 12)
                })
            }
            else if (type == 3)
            {
                icon1 = new T.Icon({
                    iconUrl: map_metro,
                    iconSize: new T.Point(23, 23),
                    iconAnchor: new T.Point(12, 12)
                })
            }
            else
            {
                icon1 = new T.Icon({
                    iconUrl: map_metro,
                    iconSize: new T.Point(23, 23),
                    iconAnchor: new T.Point(12, 12)
                })

            }
            if (type != 1) {
                var lnglatStartArr = lnglatStartStr.split(",");
                var lnglatStart = new T.LngLat(lnglatStartArr[0], lnglatStartArr[1]);
                var lnglatEndArr = lnglatEndStr.split(",");
                var lnglatEnd = new T.LngLat(lnglatEndArr[0], lnglatEndArr[1]);
                var startMarker = new T.Marker(lnglatStart, { icon: icon1 });
                map.addOverLay(startMarker);
                var endMarker = new T.Marker(lnglatEnd, { icon: icon1 });
                map.addOverLay(endMarker);
            }
        }

        function createRouteBus(pointsStr, type, lnglatStartStr, lnglatEndStr) {
            var points = pointsStr.substring(0, pointsStr.length - 1).split(";");
            var lnglatArr = [];
            for (var i = 0; i < points.length; i++) {
                var lnglat = points[i].split(",");
                lnglatArr.push(new T.LngLat(lnglat[0], lnglat[1]));
            }
            if (type == 1) {
                var lineColor = "#2E9531";
                var lineStyle = "dashed";
            }
            else if (type == 2)
            {
                var lineColor = "#2C64A7";
                var lineStyle = "solid";
            }
            else if (type == 3)
            {
                var lineColor = "#2C64A7";
                var lineStyle = "solid";
            }
            else
            {
                var lineColor = "#2E9531";
                var lineStyle = "dashed";
            }
            var line = new T.Polyline(lnglatArr, {
                color: lineColor,
                weight: 4,
                opacity: 1,
                lineStyle: lineStyle
            });
            map.addOverLay(line);
        }

        function createStartMarker() {
            var icon = new T.Icon({
                iconUrl: startIcon,
                iconSize: new T.Point(44, 34),
                iconAnchor: new T.Point(12, 31)
            })
            var startMarker = new T.Marker(startLngLat, { icon: icon });
            map.addOverLay(startMarker);
            var icon = new T.Icon({
                iconUrl: endIcon,
                iconSize: new T.Point(44, 34),
                iconAnchor: new T.Point(12, 31)
            })
            var endMarker = new T.Marker(endLngLat, { icon: icon });
            map.addOverLay(endMarker);
        }
    </script>
</body>
</html>
