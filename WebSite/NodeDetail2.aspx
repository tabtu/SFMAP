<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NodeDetail2.aspx.cs" Inherits="NodeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>贵阳法治地图</title>
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/NodeDetail.js"></script>
    <script src="Scripts/jquery.js"></script>
    <script type="text/javascript" src="http://api.tianditu.com/api?v=4.0"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=7jX0fH8U0LAyWrd6Lp4HQXYalxfXvZvk"></script>
    <link rel="stylesheet" type="text/css" href="Styles/NodeDetail.css" />
    <link  rel="stylesheet"type="text/css" href="Styles/bootstrap.min.css" media="all" />
</head>
<body onload="onLoad()">
    <div class="container" style="width:100%; height:inherit">
		<div class="org-title">
            <h3 id="org_title">
                <asp:label ID="label_title" runat="server" Font-Bold="True" Font-Size="Medium"></asp:label>
            </h3>
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
								<li><a onclick="searchBusRoute(1)">较快捷</a></li>
								<li><a onclick="searchBusRoute(2)">少换乘</a></li>
								<li><a onclick="searchBusRoute(4)">少步行</a></li>
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
        <label id="Label_Lng"></label>
        <label id="Label_Lat"></label>
	</div>
    <script>
        var e_lng = "<%=Get_e_Lng()%>";
        var e_lat = "<%=Get_e_Lat()%>";
        var s_lng;
        var s_lat;
		var zoom = 12;

		var map, drivingRoute, transitRoute, obj;
        var startLngLat, endLngLat;

        var startIcon = "http://lbs.tianditu.com/images/bus/start.png";	//起点图标
        var endIcon = "http://lbs.tianditu.com/images/bus/end.png";		//终点图标
        var map_bus = "http://lbs.tianditu.com/images/bus/map_bus.png";
        var map_metro = "http://lbs.tianditu.com/images/bus/map_metro.png";

        function onLoad() {
            getLocation();

            map = new T.Map('navigation_map');
            map.centerAndZoom(new T.LngLat(e_lng, e_lat), zoom);

            var marker = new T.Marker(new T.LngLat(e_lng, e_lat));
            map.addOverLay(marker);
        }

        function searchBusRoute(policy) {
            var config = {
                policy: policy,	//公交导航的策略参数
                onSearchComplete: busSearchResult	//检索完成后的回调函数
            };
            //创建公交搜索对象
            transitRoute = new T.TransitRoute(map, config);
            searchBus();
        }

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
            var pointArr = [];
            pointArr.push(ggpoint);
            convertor.translate(pointArr, 1, 5, translateCallback)
        }

        translateCallback = function (data) {
            if (data.status === 0) {
                s_lng = data.points[0].lng;
                s_lat = data.points[0].lat;

                var lng_lat_2 = gcj02tobd09(data.points[0].lng, data.points[0].lat);

                var marker = new T.Marker(new T.LngLat(lng_lat_2[0], lng_lat_2[1]));
                map.addOverLay(marker);

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

        // 转换BD09到GCJ02
        function bd09togcj02(bd_lon, bd_lat) {
            var x_PI = 3.14159265358979324 * 3000.0 / 180.0;
            var PI = 3.1415926535897932384626;
            var a = 6378245.0;
            var ee = 0.00669342162296594323;

            var x_pi = 3.14159265358979324 * 3000.0 / 180.0;
            var x = bd_lon - 0.0065;
            var y = bd_lat - 0.006;
            var z = Math.sqrt(x * x + y * y) - 0.00002 * Math.sin(y * x_pi);
            var theta = Math.atan2(y, x) - 0.000003 * Math.cos(x * x_pi);
            var gg_lng = z * Math.cos(theta);
            var gg_lat = z * Math.sin(theta);
            return [gg_lng, gg_lat]
        }

        // 驾车搜索
        function searchDrivingRoute(policy) {
            map.clearOverLays();
            startLngLat = new T.LngLat(s_lng, s_lat);
            endLngLat = new T.LngLat(e_lng, e_lat);

            var configdrive = {
                policy: 0,	//驾车策略
                onSearchComplete: searchResult	//检索完成后的回调函数
            };
            drivingRoute = new T.DrivingRoute(map, configdrive);

            //设置驾车策略
            drivingRoute.setPolicy(policy);
            //驾车路线搜索
            drivingRoute.search(startLngLat, endLngLat);
        }

        function createRouteDrive(lnglats, lineColor) {
            //创建线对象
            var line = new T.Polyline(lnglats, { color: "#2C64A7", weight: 5, opacity: 0.9 });
            //向地图上添加线
            map.addOverLay(line);
        }

        //添加起始点
        function createStartMarkerDrive(result) {
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

        function searchResult(result) {
            //添加起始点
            createStartMarkerDrive(result);
            obj = result;
            //获取方案个数
            var routes = result.getNumPlans();
            for (var i = 0; i < routes; i++) {
                //获得单条驾车方案结果对象
                var plan = result.getPlan(i);
                createRouteDrive(plan.getPath());
                //显示最佳级别
                map.setViewport(plan.getPath());
            }
        }



        //公交搜索
        function searchBus() {
            //清空地图
            map.clearOverLays();

            startLngLat = new T.LngLat(s_lng, s_lat);
            endLngLat = new T.LngLat(e_lng, e_lat);

            transitRoute.search(startLngLat, endLngLat);
        }

        //显示公交搜索结果
        function busSearchResult(result) {

            if (transitRoute.getStatus() == 0) {
                //添加起始点
                createStartMarkerBus();
                obj = result;
                //获取方案个数
                var plans = result.getNumPlans();
                for (var i = 0; i < plans; i++) {
                    //获得单条公交结果对象
                    var plan = result.getPlan(i);

                    //清空地图
                    map.clearOverLays();
                    //添加起始点
                    createStartMarkerBus();
                    //显示线路
                    createSegments(obj.getPlan(i));

                    //在地图上默认显示方案一的线路
                    if (i == 0) {
                        createSegments(result.getPlan(0));
                    }
                }

            }
        }

        //显示公交线路
        function createSegments(plan, planNum) {
            var segmentNum = plan.getNumSegments();
            for (var m = 0; m < segmentNum; m++) {
                var line = plan.getDetails(m);
                var segmentLine = line.getSegmentLine()[0];
                //显示线路
                createRouteBus(segmentLine.linePoint, line.getSegmentType(), line.getStationStart().lonlat, line.getStationEnd().lonlat);
                //显示换乘图标
                createMarker(line.getStationStart().lonlat, line.getStationEnd().lonlat, line.getSegmentType());
            }
        }

        //显示公交换乘图标,lnglatStartStr表示该线路的起始点，lnglatEndStr表示该线路的终点，type表示线路类型
        function createMarker(lnglatStartStr, lnglatEndStr, type) {
            var icon1;
            if (type == 2)	//公交
            {
                //公交标注
                icon1 = new T.Icon({
                    iconUrl: map_bus,
                    iconSize: new T.Point(23, 23),
                    iconAnchor: new T.Point(12, 12)
                })
            }
            else if (type == 3)	//地铁
            {
                //地铁标注
                icon1 = new T.Icon({
                    iconUrl: map_metro,
                    iconSize: new T.Point(23, 23),
                    iconAnchor: new T.Point(12, 12)
                })
            }
            else	//地铁站内换乘
            {
                //地铁标注
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

        //公交线路，pointsStr表示经纬度字符串，type表示线路类型1，步行；2，公交；3，地铁；4， 地铁站内换乘，lnglat表示显示公交或地铁图标的经纬度
        function createRouteBus(pointsStr, type, lnglatStartStr, lnglatEndStr) {

            //去掉经纬度字符串最后一个分号，并存储在一个数据中。
            var points = pointsStr.substring(0, pointsStr.length - 1).split(";");
            //存储经纬度的数组
            var lnglatArr = [];
            for (var i = 0; i < points.length; i++) {
                var lnglat = points[i].split(",");
                lnglatArr.push(new T.LngLat(lnglat[0], lnglat[1]));
            }

            //步行
            if (type == 1) {
                var lineColor = "#2E9531";	//线的颜色
                var lineStyle = "dashed";	//线的样式
            }
            else if (type == 2)	//公交
            {
                var lineColor = "#2C64A7";	//线的颜色
                var lineStyle = "solid";	//线的样式
            }
            else if (type == 3)	//地铁
            {
                var lineColor = "#2C64A7";	//线的颜色
                var lineStyle = "solid";	//线的样式
            }
            else	//地铁站内换乘
            {
                var lineColor = "#2E9531";	//线的颜色
                var lineStyle = "dashed";	//线的样式
            }

            //创建线对象
            var line = new T.Polyline(lnglatArr, {
                color: lineColor,
                weight: 4,
                opacity: 1,
                lineStyle: lineStyle
            });
            //向地图上添加线
            map.addOverLay(line);
        }

        //添加起始点
        function createStartMarkerBus() {
            //向地图上添加起点
            var icon = new T.Icon({
                iconUrl: startIcon,
                iconSize: new T.Point(44, 34),
                iconAnchor: new T.Point(12, 31)
            })
            var startMarker = new T.Marker(startLngLat, { icon: icon });
            map.addOverLay(startMarker);
            //向地图上添加终点
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
