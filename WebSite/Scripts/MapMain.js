//var queryTypes = new Array("司法行政机关", "基层法律服务所");
	
//var querySubTypes = new Array("法律援助中心", "司法鉴定机构", "律师事务所", "公证处");
	
$(document).ready(function () {

    //初始化一级菜单
    var menuItems = $("#menu").children(".item");
    $(menuItems).each(function (index, item) {
        $(item).bind("click", function () {
            $("div").children(".item").css("border-bottom", "4px solid #F9F9F9");
            $("div").children(".item").css("color", "#000000");
            $(item).css("color", "#2C81FF");
            $(item).css("border-bottom", "3px solid #2C81FF");

            if (index == 0) {
                $("#sub_menu").toggle();
            } else {
                $("#sub_menu").hide();
            }

        });
    });
    //$(menuItems[2]).css("color", "#2C81FF");
    //$(menuItems[2]).css("border-bottom", "3px solid #2C81FF");

    //初始化二级菜单
    var subMenuItems = $("#sub_menu").children();
    $(subMenuItems).each(function (index, item) {
        $(item).bind("click", function () {
            $("#sub_menu").hide();
        });

        $(item).bind("mouseover", function () {
            $(item).css("color", "#2C81FF");
        });

        $(item).bind("mouseout", function () {
            $(item).css("color", "#000000");
        });
    });

    $("#map").css("height", $(window).height() - 90);

    userlocation();
});

/*
* 
*/
function searchByKw() {
    document.getElementById("btn_epn").click();
}

function gzjg() {
    document.getElementById("btn_cate6").click();
    //document.getElementById('Label_title').innerHTML = "公证处";
}

function lssws() {
    document.getElementById("btn_cate5").click();
    //document.getElementById('Label_title').innerHTML = "律师事务所";
}

function sfjd() {
    document.getElementById("btn_cate4").click();
    //document.getElementById('Label_title').innerHTML = "司法鉴定机构";
}

function flyz() {
    document.getElementById("btn_cate3").click();
    //document.getElementById('Label_title').innerHTML = "法律援助中心";
}

function flfws() {
    document.getElementById("btn_cate1").click();
    //document.getElementById('Label_title').innerHTML = "基层法律服务所";
}

function sfxzjg() {
    document.getElementById("btn_cate2").click();
    //document.getElementById('Label_title').innerHTML = "司法行政机关";
}


function userlocation() {

    //API设置
    wx.config({
        debug: false,
        appId: 'wxea3a7dd533a085eb',
        timestamp: timestamp,
        nonceStr: noncestr, 
        signature: resp,
        jsApiList: [ 'getLocation' ]
    });

    wx.error(function(res) {
					
    });

    wx.ready(function() {

        wx.getLocation({
            type : 'wgs84', //
            success : function(res) {
							
                loadLbs = true;
							
                userLat = res.latitude; // 纬度，浮点数，范围为90 ~ -90
                userLng = res.longitude; // 经度，浮点数，范围为180 ~ -180。

                var convertor = new BMap.Convertor();
                var pointArr = [];

                //座标转换成功后的处理
                var translateCallback = function(data) {

                    userLat = data.points[0].lat;
                    userLng = data.points[0].lng;
                    centerLat = userLat;
                    centerLng = userLng;
								
						        
                    var userPoint = new BMap.Point(userLng, userLat);
                    map.centerAndZoom(userPoint, 16);
                }

                var user = new BMap.Point(userLng, userLat);
                pointArr.push(user);
                convertor.translate(pointArr, 1, 5,translateCallback)
				            
            }
        });

    });
				
    //设定10延时
    setTimeout("equalize()",5000);
    //End
}