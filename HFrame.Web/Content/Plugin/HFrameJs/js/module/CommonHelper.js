var HFHttp,Layer;
define(function(require, exports) {
	Layer=require("layer");
	HFHttp = require("HttpHelper");
	
	exports.ready=function(){
		interceptform();
	}
	
	exports.IsNullOrEmpty = IsNullOrEmpty;
});
//拦截表单
function interceptform(callback) {
	$(":submit").click(function(check) {
		check.preventDefault(); //此处阻止提交表单
		var d = $('form').serializeArray();
		var u = $('form').attr("action");
		var m = $('form').attr("method");
		HFHttp.ajax(u, d, m, function(r) {
			layer.msg(r.ErrorMsg, {
				anim: 0
			}, function() {
				if (callback) {
					callback(r);
				}
				if (r.ErrorCode == 0 && !common.IsNullOrEmpty(r.CallbackPage)) {
					location.href = r.CallbackPage;
				}
			});
		});
	});
}

//判断字符是否为空的方法
function IsNullOrEmpty(obj) {
	function isEmpty(obj) {
		if (typeof obj == "undefined" || obj == null || obj == "") {
			return true;
		} else {
			return false;
		}
	}
}
