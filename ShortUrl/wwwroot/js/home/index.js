var _apis = (function () {
    var _code_success = "SUCCESS";
    function Apis() {
        this.zipping = false;
        this.unzipping = false;
    }
    Apis.prototype.zip = function (long, before, error, success, complete) {
        var _self = this;
        if (_self.zipping) {
            if (typeof error == typeof $.ajax) {
                error("正在缩短URL，请等待当前任务完成！");
                return;
            }
        }
        $.ajax({
            url: "/api/zip",
            type: "post",
            data: { url: long },
            dataType: "json",
            beforeSend: function () {
                _self.zipping = true;
                if (typeof before == typeof $.ajax) {
                    before();
                }
            },
            error: function (err) {

                _self.zipping = false;
                if (typeof error == typeof $.ajax) {
                    error(err);
                }
            },
            success: function (data) {
                _self.zipping = false;
                if (typeof success == typeof $.ajax) {
                    if (data.Return_Code == _code_success) {
                        success(data.Result);
                    }
                    else {
                        error(data.Return_Msg);
                    }
                }
            },
            complete: function () {
                if (typeof complete == typeof $.ajax) {
                    complete();
                }
            }
        });
    }
    Apis.prototype.unzip = function (short, before, error, success, complete) {
        var _self = this;
        if (_self.unzipping) {
            if (typeof error == typeof $.ajax) {
                error("正在还原URL，请等待当前任务完成！");
                return;
            }
        }
        $.ajax({
            url: "/api/unzip",
            type: "post",
            data: { surl: short },
            dataType: "json",
            beforeSend: function () {
                _self.unzipping = true;
                if (typeof before == typeof $.ajax) {
                    before();
                }
            },
            error: function (err) {
                _self.unzipping = false;
                if (typeof error == typeof $.ajax) {
                    error(err);
                }
            },
            success: function (data) {
                _self.unzipping = false;
                if (typeof success == typeof $.ajax) {
                    if (data.Return_Code == _code_success) {
                        success(data.Result);
                    }
                    else {
                        error(data.Return_Msg);
                    }
                }
            },
            complete: function () {
                if (typeof complete == typeof $.ajax) {
                    complete();
                }
            }
        });
    }
    return new Apis();
})();
var _regShort = /^[0-9a-zA-Z]{1,8}$/;

$.fn.extend({
    enter: function (callback) {
        if (typeof callback == typeof $.noop) {
            this.bind("keydown", function (e) {
                e = e || window.event;
                if (e.keyCode == 13) {
                    return callback();
                }
            });
        }
        return this;
    }
});

function zip_before() {
    _$zipText.attr("readonly", "readonly");
    _$zipResult.text("请稍后...").removeClass("success").removeClass("error");
}
function zip_error(err) {
    _$zipResult.text(err).addClass("error").removeClass("success");
}
function zip_success(result) {
    _$zipResult.text(result).addClass("success").removeClass("error");
}
function zip_complete() {
    _$zipText.removeAttr("readonly");
}
function unzip_before() {
    _$unzipText.attr("readonly", "readonly");
    _$unzipResult.text("请稍后...").removeClass("success").removeClass("error");
}
function unzip_error(err) {
    _$unzipResult.text(err).addClass("error").removeClass("success");
}
function unzip_success(result) {
    _$unzipResult.text(result).addClass("success").removeClass("error");
}
function unzip_complete() {
    _$unzipText.removeAttr("readonly");
}
function go() {
    window.open(this.innerHTML);
}
function isShort(surl) {
    return _regShort.test(surl);
}
function button_zip_click() {
    var _long = _$zipText.val();
    if (!_long) {
        _$zipResult.text("请输入要压缩的网址");
        _$zipText.focus();
        return;
    }
    if (!$.utils.Regex.isHttp(_long)
        && !$.utils.Regex.isHttps(_long)) {
        _$zipResult.text("您输入的网址不合法，仅支持http与https");
        _$zipText.focus();
        return;
    }
    _apis.zip(_long, zip_before, zip_error, zip_success, zip_complete);
}
function button_unzip_click() {
    var _short = _$unzipText.val();
    if (!_short) {
        _$unzipResult.text("请输入要解压的网址");
        _$unzipText.focus();
        return;
    }
    if (!isShort(_short)) {
        _$unzipResult.text("您输入的短网址不合法，只能是英文字母（区分大小写）与数字");
        _$unzipText.focus();
        return;
    }
    _apis.unzip(_short, unzip_before, unzip_error, unzip_success, unzip_complete);
}


var _$zipText = $(".zip input")
    .change(function () { _$zipResult.html(""); })
    .bind("input", function () { _$zipResult.html(""); })
    .enter(button_zip_click);
var _$zipResult = $(".zip .result")
    .click(go);
var _$unzipText = $(".unzip input")
    .change(function () { _$unzipResult.html(""); })
    .bind("input", function () { _$unzipResult.html(""); })
    .bind("keyup", function () { _$unzipText.val(_$unzipText.val().replace(/[^\w]/ig, "")); })
    .bind("afterpaste", function () { _$unzipText.val(_$unzipText.val().replace(/[^\w]/ig, "")); })
    .enter(button_unzip_click);
var _$unzipResult = $(".unzip .result")
    .click(go);
var _$tabHeaders = $(".tab-header")
    .click(function () {
    $(this).addClass("active").siblings().removeClass("active");
    $(".tab-body").hide().filter(`.${$(this).data("target")}`).show();
});
var _$zipButton = $(".zip .submit .button")
    .click(button_zip_click);
var _$unzipButton = $(".unzip .submit .button")
    .click(button_unzip_click);