$(function () {
    common.ready();
})

var common = {}

common = {
    _Data: {
    },
    ready: function () {
        common.importJs('/Content/Plugin/layer/layer.js');//默认引入Layer
        common.importJs('/Content/Plugin/HFrame/js/module/HttpHelper.js');//默认引入Http模块
        common.interceptform();//默认拦截表单
    },
    interceptform: function (callback) {//拦截表单
        $(":submit").click(function (check) {
            check.preventDefault();//此处阻止提交表单
            var d = $('form').serializeArray();
            var u = $('form').attr("action");
            var m = $('form').attr("method");
            common.Http.ajax(u, d, m,function (r) {
                layer.msg(r.ErrorMsg, { anim:0 }, function () {
                    if (callback) {
                        callback(r);
                    }
                });
            });
        });
    },
    importJs: function importJs(url) {//封装引入JS
        var newscript = document.createElement('script');
        newscript.setAttribute('type', 'text/javascript');
        newscript.setAttribute('src', url);
        var head = document.getElementsByTagName('head')[0];
        head.appendChild(newscript);
    }
}
