function showupdate(id,ty) {
    $("#editarea").css({ display: "block" });
    if (ty == "protype") {
        $.ajax({
            //要用post方式
            type: "Post",
            //方法所在页面和方法名
            url: "ProType_list.aspx/getProtype",
            data: "{'tid':'" + id + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //返回的数据用data.d获取内容
                $("#txttname").val(data.d);
                $("#hidtid").val(id);
                $("#isupdate").val('1');
            },
            error: function (err) {
                alert(err);
            }
        });
    }
    if (ty == "product") {
        $("#pucimg").attr({ src: "" });
        $.ajax({
            //要用post方式
            type: "Post",
            //方法所在页面和方法名
            url: "Pro_List.aspx/getProduct",
            data: "{'pid':'" + id + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //返回的数据用data.d获取内容
                var str = data.d;
                $("#txttname").val(str.split("*")[0]);
                $("#txtmemo").val(str.split("*")[1]);
                $("#hidfup").val(str.split("*")[2]);
                $("#pucimg").attr({ src: "products/" + str.split("*")[2] });
                $("#hidpicurl").val(str.split("*")[2]);
                $("#dltype").val(str.split("*")[3]);
                $("#hidtid").val(id);
                $("#isupdate").val('1');
            },
            error: function (err) {
                alert(333);
            }
        });
    }
    if (ty == "member") {
        $.ajax({
            //要用post方式
            type: "Post",
            //方法所在页面和方法名
            url: "Emp_Man.aspx/getMember",
            data: "{'id':'" + id + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //返回的数据用data.d获取内容
                var str = data.d;
                $(".chid").css({ display: "" });
                //$("#txtuser").attr({ readonly: "true" });
                $("#txtuser").css({ display: "none" });
                $("#lbluser").val(str.split("*")[0]);
                $("#txtopwd").val(str.split("*")[1]);
                $("#txtnpwd").val('');
                $("#txtnpwd2").val('');
                $("#hidtid").val(id);
                $("#isupdate").val('1');
            },
            error: function (err) {
                alert(333);
            }
        });
    }
}

function checklogin() {
    if ($("#txtuser").val().length == 0) {
        alert("請輸入用戶名！");
        return false;
    }
    if ($("#txtpwd").val().length == 0) {
        alert("請輸入密碼！");
        return false;
    }
    return true;
}

function checkpwdman() {
    if ($("#txtopwd").val().length == 0) {
        alert("請輸入舊密碼！");
        return false;
    }
    if ($("#txtnpwd").val().length == 0) {
        alert("請輸入新密碼！");
        return false;
    }
    if ($("#txtnpwd2").val().length == 0) {
        alert("請輸入確認密碼！");
        return false;
    }
    if ($("#txtnpwd").val() != $("#txtnpwd2").val()) {
        alert("兩次密碼輸入不一致！");
        return false;
    }
    return true;
}

function checkpwdup() {
    if ($("#txtnpwd").val().length == 0) {
        alert("請輸入新密碼！");
        return false;
    }
    if ($("#txtnpwd2").val().length == 0) {
        alert("請輸入確認密碼！");
        return false;
    }
    if ($("#txtnpwd").val() != $("#txtnpwd2").val()) {
        alert("兩次密碼輸入不一致！");
        return false;
    }
    return true;
}

function test() {
    alert($("#form1").find("#upfilename").val());
}

function bigshowdiv(e) {
    var str = $(e).attr("src");
    if (str.length != 0) {
        $("#bigshow").attr({ src: str });
        $("#bigimg").css({ display: "block" });
    }
}

function showadd(ty) {
    $("#editarea").css({ display: "block" });
    if (ty == "protype") {
        $("#txttname").val('');
        $("#hidtid").val('');
        $("#isupdate").val('0');
        $("#txtmemo").val('');
        $("#pucimg").attr({ src: "" });
    }
    if (ty == "member") {
        $(".chid").css({ display: "none" });

        $("#txtuser").css({ display: "" });
        //$("#txtuser").attr({ readonly: "false" });
        $("#lbluser").val('');
        $("#txtuser").val('');
        $("#hidtid").val('');
        $("#isupdate").val('0');
        $("#txtnpwd").val('');
        $("#txtnpwd2").val('');
    }
}

