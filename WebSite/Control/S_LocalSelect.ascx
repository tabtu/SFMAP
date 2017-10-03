<%@ Control Language="C#" AutoEventWireup="true" CodeFile="S_LocalSelect.ascx.cs" Inherits="S_Control_LocalSelect" %>

<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
	<style type="text/css">
		#allmap {width: 300px;height: 200px;overflow: hidden;margin:0;font-family:"微软雅黑";}
	</style>
	<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=cL6WkBLcRxcyBvS1ShW8HYh8"></script>
	<title>双击获取点击的经纬度</title>
</head>
<body>
    <input id="hidden_lng" type="hidden" name="hidden_lng" />
    <input id="hidden_lat" type="hidden" name="hidden_lat" />
	<div id="allmap" style="width:100%;"></div>
</body>

<script type="text/javascript">
    var map = new BMap.Map("allmap");
    map.disableDoubleClickZoom();
    map.enableScrollWheelZoom();
    map.enableKeyboard();

    map.addEventListener("click", function (e) {
        deletePoint();
        if (map.getOverlays.length == 0) {
            var pt = new BMap.Point(e.point.lng, e.point.lat);
            var marker = new BMap.Marker(pt, {
                icon: new BMap.Icon("http://api.map.baidu.com/lbsapi/createmap/images/icon.png", new BMap.Size(20, 25), {
                    imageOffset: new BMap.Size(-92, -21)
                })
            });
            //marker.enableDragging();
            map.addOverlay(marker);
            document.getElementById("hidden_lng").value = pt.lng;
            document.getElementById("hidden_lat").value = pt.lat;
        }
    });

    function deletePoint() {
        var allOverlay = map.getOverlays();
        for (var i = 0; i < allOverlay.length - 1; i++) {
            map.removeOverlay(allOverlay[i]);
        }
    }

    function setup(alng, alat, azoom) {
        var pt = new BMap.Point(alng, alat);
        map.centerAndZoom(pt, azoom);
    }

    function addPoint(alng, alat) {
        var lng = alng;
        var lat = alat;
        if (map.getOverlays.length == 0) {
            var pt = new BMap.Point(lng, lat);
            map.centerAndZoom(pt, 14);
            var marker = new BMap.Marker(pt, {
                icon: new BMap.Icon("http://api.map.baidu.com/lbsapi/createmap/images/icon.png", new BMap.Size(20, 25), {
                    imageOffset: new BMap.Size(-92, -21)
                })
            });
            //marker.enableDragging();
            map.addOverlay(marker);
            document.getElementById("hidden_lng").value = pt.lng;
            document.getElementById("hidden_lat").value = pt.lat;
        }
    }
</script>