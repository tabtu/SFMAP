using System.Collections.Generic;
using ttxy.Model;

namespace ttxy.BLL
{
    /// <summary>
    /// Powered By Tab Tu
    /// 2016.04.26
    /// Baidu Map LBS local address map function library, exchange from LanMap 2015
    /// </summary>
    public class LbsMaker
    {
        private const string mainurl = StrUtil.mainurl;
        //private static string iconurl = StrUtil.mainurl + "Upload/icon/";
        //private static string mapurl = StrUtil.mainurl + "Upload/map/";

        /// <summary>
        /// 翻译节点信息文档到html
        /// </summary>
        /// <param name="ld">节点信息</param>
        /// <returns>html文档，配合MakeMap使用</returns>
        public static string MakeMapPoints(IList<LocalData> ld)
        {
            string points = "";
            for (int i = 0; i < ld.Count; i++)
            {
                // 图标展现
                //string jxtmp = "";
                //if (ld[i].Type == 1) jxtmp += "<img style='float:left;margin:0px 5px 0px 0px' id='img1' src='" + mapurl + "dx.png' width='300' height='200'/>";
                //if (ld[i].Type == 2) jxtmp += "<img style='float:left;margin:0px 5px 0px 0px' id='img1' src='" + mapurl + "lt.png' width='300' height='200'/>";
                //if (ld[i].Type == 3) jxtmp += "<img style='float:left;margin:0px 5px 0px 0px' id='img1' src='" + mapurl + "yd.png' width='300' height='200'/>";
                //if (jxtmp.Length > 0) jxtmp = jxtmp.Substring(0, jxtmp.Length - 1);

                // 图标设置
                string icontmp = "";
                if (ld[i].Group == "司法行政机关")
                {
                    //jztmp = "较差";
                    icontmp = "w:23,h:25,l:46,t:21,x:9,lb:12";   // set red icon
                }
                else if (ld[i].Group == "基层法律服务所")
                {
                    //jztmp = "合格";
                    icontmp = "w:23,h:25,l:23,t:21,x:9,lb:12";   // set blue icon
                }
                else
                {
                    //jztmp = "优秀";
                    icontmp = "w:23,h:25,l:0,t:21,x:9,lb:12";  // set green icon
                }

                // 节点制造
                string temp = "{title:\"" + "" + //ld[i].Name + 
                    "\",content:\"<br/>" + ld[i].Name + 
                    //jxtmp + "<br/>" + 
                    "<p style='font-weight:600;'>" +
                    "<br/><a href=tel:" + ld[i].Tele + ">拨打电话</a></p>" +
                    "<br/>详细地址：" + ld[i].Address + 
                    "<br/>其他信息：" + ld[i].OCW + 
                    "<br/><a href=" + mainurl + "NodeDetail.aspx?" + ld[i].ID + ">显示详情</a></p>" + 
                    "</p>\",point:\"" + ld[i].Lng + "|" + ld[i].Lat + 
                    "\",isOpen:0,icon:{" + icontmp + 
                    "}}\r\n\t\t ,";
                points += temp;
            }
            return points.Substring(0, points.Length - 1);
        }

        /// <summary>
        /// 翻译热力图指标数据
        /// </summary>
        /// <param name="ld">指标数组</param>
        /// <returns>html文档，配合MakeHeat使用</returns>
        public static string MakeHeatPoints(IList<LocalData> ld)
        {
            string points = "";
            for (int i = 0; i < ld.Count; i++)
            {
                string tmpcount = "";
                if (ld[i].Key_W == "0")
                {
                    tmpcount = "1";
                }
                else if (ld[i].Key_W == "1")
                {
                    tmpcount = "50";
                }
                else
                {
                    tmpcount = "99";
                }
                string temp = "{\"lng\":" + ld[i].Lng + ",\"lat\":" + ld[i].Lat + ",\"count\":" + tmpcount + "},\r\n";
                points += temp;
            }
            return points.Substring(0, points.Length - 3);
        }

        /// <summary>
        /// 翻译标记参数数据
        /// </summary>
        /// <param name="ld">指标数组</param>
        /// <param name="ad">区域数组</param>
        /// <returns>html文档，配合MakeLabel使用</returns>
        public static string MakeLabelPoints(IList<LocalData> ld, IList<BGroup> ad)
        {
            //int[,] sumtmp = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, };

            string result = "";
            for (int i = 0; i < ad.Count; i++)
            {
                int sum = 0;
                int et_sum = 0;
                for (int j = 0; j < ld.Count; j++)
                {
                    if (ld[j].Group == ad[i].ID.ToString())
                    {
                        sum++;
                        if (ld[j].Name != null)
                        {
                            et_sum++;
                        }
                    }
                }

            string temp = "\r\n\r\nvar point" + i +
                    " = new BMap.Point(" + ad[i].Lng + "," + ad[i].Lat + 
                    ");\r\nvar opts" + i +
                    " = {\r\nposition : point" + i +
                    ",\r\noffset : new BMap.Size(-9, -16)\r\n}\r\nvar label" + i +
                    " = new BMap.Label(\"" + ad[i].Name + ", 总数" + sum + ", 高竞争" + et_sum + 
                    "\", opts" + i +
                    ");\r\nlabel" + i +
                    ".setStyle({\r\ncolor : \"red\",\r\nfontSize : \"16px\",\r\nheight : \"20px\",\r\nlineHeight : \"20px\",\r\nfontFamily:\"微软雅黑\"\r\n});\r\nmap.addOverlay(label" + i + 
                    ");\r\n\r\n";

                result += temp;
            }
            return result;
        }

        /// <summary>
        /// 制造标记点地图
        /// </summary>
        /// <param name="gpscenter">地图中心GPS</param>
        /// <param name="zoom">缩放等级</param>
        /// <param name="points">标记点数据</param>
        /// <returns>HTML发布文档</returns>
        public static string MakeMap(string gpscenter, string zoom, string points)
        {
            string h0 = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" />\r\n<meta name=\"keywords\" content=\"贵阳法治地图\" />\r\n<meta name=\"description\" content=\"贵阳法治地图\" />\r\n<title>贵阳法治地图</title>\r\n\r\n<style type=\"text/css\">\r\n    html,body{margin:0;padding:0;}\r\n    .iw_poi_title {color:#CC5522;font-size:14px;font-weight:bold;overflow:hidden;padding-right:13px;white-space:nowrap}\r\n    .iw_poi_content {font:12px arial,sans-serif;overflow:visible;padding-top:4px;white-space:-moz-pre-wrap;word-wrap:break-word}\r\n</style>\r\n<script type=\"text/javascript\" src=\"http://api.map.baidu.com/api?v=2.0&ak=7jX0fH8U0LAyWrd6Lp4HQXYalxfXvZvk\"></script>\r\n</head>\r\n\r\n<body>\r\n  \r\n  <div style=\"width:100%;height:600px;border:#ccc solid 1px;\" id=\"dituContent\"></div>\r\n</body>\r\n<script type=\"text/javascript\">\r\n    \r\n    function initMap(){\r\n        createMap();\r\n        setMapEvent();\r\n        addMapControl();\r\n        addMarker();\r\n    }\r\n    \r\n    \r\n    function createMap(){\r\n        var map = new BMap.Map(\"dituContent\");\r\n        var point = new BMap.Point(";
            string h1 = ");\r\nmap.centerAndZoom(point,";
            string h2 = ");\r\nwindow.map = map;\r\n    }\r\n    \r\n    \r\n    function setMapEvent(){\r\n        map.enableDragging();\r\n        map.enableScrollWheelZoom();\r\n        map.enableDoubleClickZoom();\r\n        map.enableKeyboard();\r\n    }\r\n    \r\n    \r\n    function addMapControl(){\r\n       \r\n\tvar ctrl_nav = new BMap.NavigationControl({anchor:BMAP_ANCHOR_TOP_LEFT,type:BMAP_NAVIGATION_CONTROL_LARGE});\r\n\tmap.addControl(ctrl_nav);\r\n        \r\n\tvar ctrl_ove = new BMap.OverviewMapControl({anchor:BMAP_ANCHOR_BOTTOM_RIGHT,isOpen:1});\r\n\tmap.addControl(ctrl_ove);\r\n        \r\n\tvar ctrl_sca = new BMap.ScaleControl({anchor:BMAP_ANCHOR_BOTTOM_LEFT});\r\n\tmap.addControl(ctrl_sca);\r\n    }\r\n    \r\n    \r\n    var markerArr = [";
            string h3 = "];\r\nfunction addMarker(){\r\n        for(var i=0;i<markerArr.length;i++){\r\n            var json = markerArr[i];\r\n            var p0 = json.point.split(\"|\")[0];\r\n            var p1 = json.point.split(\"|\")[1];\r\n            var point = new BMap.Point(p0,p1);\r\n\t\t\tvar iconImg = createIcon(json.icon);\r\n            var marker = new BMap.Marker(point,{icon:iconImg});\r\n\t\t\tvar iw = createInfoWindow(i);\r\n\t\t\tvar label = new BMap.Label(json.title,{\"offset\":new BMap.Size(json.icon.lb-json.icon.x+4,7)});\r\n\t\t\tmarker.setLabel(label);\r\n            map.addOverlay(marker);\r\n            label.setStyle({\r\n                        borderColor:\"#808080\",\r\n                        color:\"#333\",\r\n                        cursor:\"pointer\"\r\n            });\r\n\t\t\t\r\n\t\t\t(function(){\r\n\t\t\t\tvar index = i;\r\n\t\t\t\tvar _iw = createInfoWindow(i);\r\n\t\t\t\tvar _marker = marker;\r\n\t\t\t\t_marker.addEventListener(\"click\",function(){\r\n\t\t\t\t    this.openInfoWindow(_iw);\r\n\t\t\t    });\r\n\t\t\t    _iw.addEventListener(\"open\",function(){\r\n\t\t\t\t    _marker.getLabel().hide();\r\n\t\t\t    })\r\n\t\t\t    _iw.addEventListener(\"close\",function(){\r\n\t\t\t\t    _marker.getLabel().show();\r\n\t\t\t    })\r\n\t\t\t\tlabel.addEventListener(\"click\",function(){\r\n\t\t\t\t    _marker.openInfoWindow(_iw);\r\n\t\t\t    })\r\n\t\t\t\tif(!!json.isOpen){\r\n\t\t\t\t\tlabel.hide();\r\n\t\t\t\t\t_marker.openInfoWindow(_iw);\r\n\t\t\t\t}\r\n\t\t\t})()\r\n        }\r\n    }\r\n    \r\n    function createInfoWindow(i){\r\n        var json = markerArr[i];\r\n        var iw = new BMap.InfoWindow(\"<b class='iw_poi_title' title='\" + json.title + \"'>\" + json.title + \"</b><div class='iw_poi_content'>\"+json.content+\"</div>\");\r\n        return iw;\r\n    }\r\n    \r\n    function createIcon(json){\r\n        var icon = new BMap.Icon(\"" + StrUtil.mainurl + "Pic/icon.png\", new BMap.Size(json.w,json.h),{imageOffset: new BMap.Size(-json.l,-json.t),infoWindowOffset:new BMap.Size(json.lb+5,1),offset:new BMap.Size(json.x,json.h)})\r\n        return icon;\r\n    }\r\n    \r\n    initMap();\r\n</script>\r\n</html>";
            return h0 + gpscenter + h1 + zoom + h2 + points + h3;
        }

        /// <summary>
        /// 天地图API生成地图
        /// </summary>
        /// <param name="gpscenter"></param>
        /// <param name="zoom"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public static string MakeMapTDT(string gpscenter, string zoom, string tdtpoints)
        {
            string h0 = "<html>\r\n<head>\r\n    <meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\"/>\r\n    <title>贵阳法治地图</title>\r\n    <script type=\"text/javascript\" src=\"http://api.tianditu.com/api?v=4.0\"></script>\r\n    <style type=\"text/css\">\r\n        body, html {\r\n            width: 100%;\r\n            height: 100%;\r\n            margin: 0;\r\n            font-family: \"微软雅黑\";\r\n        }\r\n        #mapDiv {\r\n            height: 100%;\r\n            width: 100%;\r\n        }\r\n    </style>\r\n    <script>\r\n        var map;\r\n        function onLoad() {\r\n            map = new T.Map(\"mapDiv\");\r\n            map.centerAndZoom(new T.LngLat(";
            string h1 = "), ";
            string h2 = ");\r\n\r\n\t\t\t\r\n";
            string h3 = "\t\t\t\r\n        }\r\n    </script>\r\n</head>\r\n<body onLoad=\"onLoad()\">\r\n<div id=\"mapDiv\"></div>\r\n</body>\r\n</html>";
            return h0 + gpscenter + h1 + zoom + h2 + tdtpoints + h3;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ld"></param>
        /// <returns></returns>
        public static string MakeMapPointsTDT(IList<LocalData> ld)
        {
            string points = "";
            for (int i = 0; i < ld.Count; i++)
            {
                string temp = "{title:\"" + "" + //ld[i].Name + 
                    "\",content:\"<br/>" + ld[i].Name +
                    //jxtmp + "<br/>" + 
                    "<p style='font-weight:600;'>" +
                    "<br/><a href=tel:" + ld[i].Tele + ">拨打电话</a></p>" +
                    "<br/>详细地址：" + ld[i].Address +
                    "<br/>其他信息：" + ld[i].OCW +
                    "<br/><a href=" + mainurl + "NodeDetail2.aspx?" + ld[i].ID + ">显示详情</a></p>" +
                    "</p>\",point:\"" + ld[i].Lng + "|" + ld[i].Lat + "\",isOpen:0},";
                points += temp;
            }
            string ldtmp = points.Substring(0, points.Length - 1);
            string tmp = "var markerArr = [" + ldtmp + "];";
            string labels = "";
            for (int i = 0; i < ld.Count; i++)
            {
                labels += "var _json" + i + " = markerArr[" + i + "]; var marker" + i + " = new T.Marker(T.LngLat(_json" + i + ".point.split(\"|\")[0],_json" + i + ".point.split(\"|\")[1]));var content" + i + " =\"<div>\" + _json" + i + ".content + \"</div>\";var _infoWin" + i + " = new T.InfoWindow(); map.addOverLay(marker" + i + "); _infoWin" + i + ".setContent(content" + i + "); marker" + i + ".addEventListener(\"click\", function () {marker" + i + ".openInfoWindow(_infoWin" + i + "); });";
            }
            return tmp + labels;
        }

        /// <summary>
        /// 制造热力图
        /// </summary>
        /// <param name="gpscenter">地图中心GPS</param>
        /// <param name="zoom">缩放等级</param>
        /// <param name="points">标记点数据</param>
        /// <returns>HTML发布文档</returns>
        public static string MakeHeat(string gpscenter, string zoom, string points)
        {
            string h0 = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <meta name=\"viewport\" content=\"initial-scale=1.0, user-scalable=no\" />\r\n    <script type=\"text/javascript\" src=\"http://api.map.baidu.com/api?v=2.0&ak=7jX0fH8U0LAyWrd6Lp4HQXYalxfXvZvk\"></script>\r\n    <script type=\"text/javascript\" src=\"http://api.map.baidu.com/library/Heatmap/2.0/src/Heatmap_min.js\"></script>\r\n    <title>热力图功能示例</title>\r\n    <style type=\"text/css\">\r\n\t\tul,li{list-style: none;margin:0;padding:0;float:left;}\r\n\t\thtml{height:100%}\r\n\t\tbody{height:600;margin:0px;padding:0px;font-family:\"微软雅黑\";}\r\n\t\t#container{height:580px;width:100%;}\r\n\t\t#r-result{width:100%;}\r\n    </style>\t\r\n</head>\r\n<body>\r\n\t<div id=\"container\"></div>\r\n\t<div id=\"r-result\">\r\n\t\t<input type=\"button\"  onclick=\"openHeatmap();\" value=\"显示热力图\"/><input type=\"button\"  onclick=\"closeHeatmap();\" value=\"关闭热力图\"/>\r\n\t</div>\r\n</body>\r\n</html>\r\n<script type=\"text/javascript\">\r\n    var map = new BMap.Map(\"container\");          // 创建地图实例\r\n\r\n    var point = new BMap.Point(";
            string h1 = ");\r\n    map.centerAndZoom(point, ";
            string h2 = ");         // 初始化地图，设置中心点坐标和地图级别\r\n    map.enableScrollWheelZoom(); // 允许滚轮缩放\r\n  \r\n   var points =[\r\n    ";
            string h3 = "];\r\n   \r\n    if(!isSupportCanvas()){\r\n    \talert('热力图目前只支持有canvas支持的浏览器,您所使用的浏览器不能使用热力图功能~')\r\n    }\r\n\t//详细的参数,可以查看heatmap.js的文档 https://github.com/pa7/heatmap.js/blob/master/README.md\r\n\t//参数说明如下:\r\n\t/* visible 热力图是否显示,默认为true\r\n     * opacity 热力的透明度,1-100\r\n     * radius 势力图的每个点的半径大小   \r\n     * gradient  {JSON} 热力图的渐变区间 . gradient如下所示\r\n     *\t{\r\n\t\t\t.2:'rgb(0, 255, 255)',\r\n\t\t\t.5:'rgb(0, 110, 255)',\r\n\t\t\t.8:'rgb(100, 0, 255)'\r\n\t\t}\r\n\t\t其中 key 表示插值的位置, 0~1. \r\n\t\t    value 为颜色值. \r\n     */\r\n\theatmapOverlay = new BMapLib.HeatmapOverlay({\"radius\":20});\r\n\tmap.addOverlay(heatmapOverlay);\r\n\theatmapOverlay.setDataSet({data:points,max:100});\r\n\t//是否显示热力图\r\n    function openHeatmap(){\r\n        heatmapOverlay.show();\r\n    }\r\n\tfunction closeHeatmap(){\r\n        heatmapOverlay.hide();\r\n    }\r\n\tcloseHeatmap();\r\n    function setGradient(){\r\n     \t/*格式如下所示:\r\n\t\t{\r\n\t  \t\t0:'rgb(102, 255, 0)',\r\n\t \t \t.5:'rgb(255, 170, 0)',\r\n\t\t  \t1:'rgb(255, 0, 0)'\r\n\t\t}*/\r\n     \tvar gradient = {};\r\n     \tvar colors = document.querySelectorAll(\"input[type='color']\");\r\n     \tcolors = [].slice.call(colors,0);\r\n     \tcolors.forEach(function(ele){\r\n\t\t\tgradient[ele.getAttribute(\"data-key\")] = ele.value; \r\n     \t});\r\n        heatmapOverlay.setOptions({\"gradient\":gradient});\r\n    }\r\n\t//判断浏览区是否支持canvas\r\n    function isSupportCanvas(){\r\n        var elem = document.createElement('canvas');\r\n        return !!(elem.getContext && elem.getContext('2d'));\r\n    }\r\n</script>";
            return h0 + gpscenter + h1 + zoom + h2 + points + h3;
        }

        /// <summary>
        /// 制造标签地图
        /// </summary>
        /// <param name="gpscenter">地图中心GPS</param>
        /// <param name="zoom">缩放等级</param>
        /// <param name="points">标记点数据</param>
        /// <returns>HTML发布文档</returns>
        public static string MakeLabel(string gpscenter, string zoom, string points)
        {
            string h0 = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n\t<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n\t<meta name=\"viewport\" content=\"initial-scale=1.0, user-scalable=no\" />\r\n\t<style type=\"text/css\">\r\n\t\tbody, html{width: 100%;height: 100%;margin:0;font-family:\"微软雅黑\";}\r\n\t\t#allmap{height:600px;width:100%;}\r\n\t\t#r-result{width:100%;}\r\n\t</style>\r\n\t<script type=\"text/javascript\" src=\"http://api.map.baidu.com/api?v=2.0&ak=7jX0fH8U0LAyWrd6Lp4HQXYalxfXvZvk\"></script>\r\n\t<title>区域信息地图</title>\r\n</head>\r\n<body>\r\n\t<div id=\"allmap\"></div>\r\n</body>\r\n</html>\r\n<script type=\"text/javascript\">\r\n\t// 百度地图API功能\r\n\tvar map = new BMap.Map(\"allmap\");\r\n\tvar point = new BMap.Point(";
            string h1 = ");\r\n\tmap.centerAndZoom(point, ";
            string h2 = ");map.enableScrollWheelZoom(true);\r\n\r\n";
            string h3 = "</script>";
            return h0 + gpscenter + h1 + zoom + h2 + points + h3;
        }
    }
}
