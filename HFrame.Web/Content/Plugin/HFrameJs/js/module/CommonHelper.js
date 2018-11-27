define(function(require, exports) {
	exports.ready = function() {
		require.async(["HttpHelper", "layer"], function(HttpHelper) {
			interceptform(HttpHelper);
			interceptdelete(HttpHelper);
		}); //拦截表单
	}
	exports.IsNullOrEmpty = IsNullOrEmpty;
});

//拦截表单
function interceptform(HttpHelper) {
	$("form").on("submit", function(event) {
		event.preventDefault(); //此处阻止提交表单
		let _Form = $(this);
		let d = _Form.serializeArray();
		let u = _Form.attr("action");
		let m = _Form.attr("method");
		HttpHelper.ajax(u, d, m, function(r) {
			layer.msg(r.ErrorMsg, {
				anim: 0,
				time:1000
			}, function() {
				if (r.ErrorCode == 0 && !IsNullOrEmpty(r.CallbackPage)) {
					location.href = r.CallbackPage;
				}
			});
		});
	});
}

function interceptdelete(HttpHelper) {
	$(".delete").on("click", function(event) {
		event.preventDefault(); //此处阻止提交表单
		let _Item = $(this);
		let u = _Item.attr("href");
		HttpHelper.post(u, {}, function(r) {
			if (r.ErrorCode == 0) {
				$(_Item.parents("tr")).remove();
			}
			layer.msg(r.ErrorMsg);
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
/** 
 * 获取指定的URL参数值 
 * URL:http://www.quwan.com/index?name=tyler 
 * 参数：paramName URL参数 
 * 调用方法:getParam("name") 
 * 返回值:tyler 
 */
function getParam(paramName) {
	paramValue = "", isFound = !1;
	if (this.location.search.indexOf("?") == 0 && this.location.search.indexOf("=") > 1) {
		arrSource = unescape(this.location.search).substring(1, this.location.search.length).split("&"), i = 0;
		while (i < arrSource.length && !isFound) arrSource[i].indexOf("=") > 0 && arrSource[i].split("=")[0].toLowerCase() ==
			paramName.toLowerCase() && (paramValue = arrSource[i].split("=")[1], isFound = !0), i++
	}
	return paramValue == "" && (paramValue = null), paramValue
}
