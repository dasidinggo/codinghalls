$(document).ready(function () {
    var aa01 = document.getElementById("swatbox1").getElementsByTagName("li").length;
    var aa02 = document.getElementById("swatbox2").getElementsByTagName("li").length;
    var aa03 = document.getElementById("swatbox3").getElementsByTagName("li").length;
    $("#ScrCont").jCarouselLite({
        btnNext: "#LeftBotton",
        btnPrev: "#RightBotton",
        speed: 1000,
        auto: null,
        visible: 6
    });
    $("#ScrCont2").jCarouselLite({
        btnNext: "#LeftBotton2",
        btnPrev: "#RightBotton2",
        speed: 1000,
        auto: null,
        visible: 6
    });
    if (aa01 > 1) {
        $("#swatbox1").jCarouselLite({
            speed: 1000,
            auto: 4000,
            visible: 1
        });
    }
    if (aa02 > 1) {
        $("#swatbox2").jCarouselLite({
            btnNext: "#LeftBotton01",
            btnPrev: "#RightBotton01",
            speed: 1000,
            auto: null,
            visible: 1
        });
    }
    if (aa03 > 1) {
        $("#swatbox3").jCarouselLite({
            speed: 1000,
            auto: 4000,
            visible: 1
        });
    }
});

function showMen1(n) {
    for (var i = 4; i <= 6; i++) {
        var curCon = document.getElementById("a2_" + i);
        var curBon = document.getElementById("picqh" + i);
        if (n == i) {
            curBon.style.display = "block";
            curCon.src = "http://news.southcn.com/gdnews/xwxc/2013/gdqzlx/images/h" + i + i + ".jpg";
        } else {
            curBon.style.display = "none";
            curCon.src = "http://news.southcn.com/gdnews/xwxc/2013/gdqzlx/images/h" + i + ".jpg";
        }
    }
}


$(function () {
    var len = $("#box ul li").length;
    var index = 0;
    var timer;

    for (i = 0; i < len; i++) {
        var arr = [];
        arr.push("<ol>")
        for (i = 1; i <= len; i++) {
            arr.push("<li>" + "</li>");
        };
        arr.push("</ol>");
        var _IndexBtnHtml = $(arr.join(''));
        $("#box").append(_IndexBtnHtml);
    }

    $("#box ol li").click(function () {
        index = $("ol li").index(this);
        showPic(index);
    }).eq(0).click();

    $("#box").hover(function () {
        clearInterval(timer);
    }, function () {
        timer = setInterval(function () {
            showPic(index);
            index++;
            if (index == len) { index = 0; }
        }, 3000)
    }).trigger("mouseleave");

    function showPic(index) {
        $("#box ol li").removeClass("active").eq(index).addClass("active");
        $("#box ul li").hide().eq(index).show();
    };
});

$(function () {
    var len2 = $("#box2 ul li").length;
    var index2 = 0;
    var timer2;

    for (i = 0; i < len2; i++) {
        var arr2 = [];
        arr2.push("<ol>")
        for (i = 1; i <= len2; i++) {
            arr2.push("<li>" + "</li>");
        };
        arr2.push("</ol>");
        var _IndexBtnHtml2 = $(arr2.join(''));
        $("#box2").append(_IndexBtnHtml2);
    }

    $("#box2 ol li").click(function () {
        index2 = $("#box2 ol li").index(this);
        showPic2(index2);
    }).eq(0).click();

    $("#box2").hover(function () {
        clearInterval(timer2);
    }, function () {
        timer2 = setInterval(function () {
            showPic2(index2);
            index2++;
            if (index2 == len2) { index2 = 0; }
        }, 4000)
    }).trigger("mouseleave");

    function showPic2(index2) {
        $("#box2 ol li").removeClass("active").eq(index2).addClass("active");
        $("#box2 ul li").eq(index2).stop(true, true).fadeIn(600).siblings("li").fadeOut(600);
    };
});

function showMen(n) {
    for (var i = 1; i <= 5; i++) {
        var curCon = document.getElementById("a1_" + i);
        if (n == i) {
            curCon.src = "http://news.southcn.com/gdnews/xwxc/2013/gdqzlx/images/w" + i + i + ".jpg"
        } else {
            curCon.src = "http://news.southcn.com/gdnews/xwxc/2013/gdqzlx/images/w" + i + ".jpg"
        }
    }
}