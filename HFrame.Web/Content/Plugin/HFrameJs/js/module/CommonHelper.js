define(function(require, exports) {
	exports.ready = function() {
		require.async(["HttpHelper","AlertHelper"],
		 function(HttpHelper, AlertHelper) {
			interceptform(HttpHelper, AlertHelper);
			interceptdelete(HttpHelper, AlertHelper);
		}); //拦截表单
	}
	exports.IsNullOrEmpty = IsNullOrEmpty;
	exports.getParam = getParam;
});

//拦截表单
function interceptform(HttpHelper, AlertHelper) {
	$("form").on("submit", function(event) {
		event.preventDefault(); //此处阻止提交表单
		let _Form = $(this);
		let d = _Form.serializeArray();
		let u = _Form.attr("action");
		let m = _Form.attr("method");
		HttpHelper.ajax(u, d, m, function(r) {
			AlertHelper.msg(r.ErrorMsg, function() {
				if (r.ErrorCode == 0 && !IsNullOrEmpty(r.CallbackPage)) {
					location.href = r.CallbackPage;
				}
			});
		});
	});
}
//拦截删除按钮点击事件
function interceptdelete(HttpHelper, AlertHelper) {
	$(".delete").on("click", function(event) {
		event.preventDefault(); //此处阻止提交表单
		let _Item = $(this);
		let u = _Item.attr("href");
		HttpHelper.post(u, {}, function(r) {
			if (r.ErrorCode == 0) {
				$(_Item.parents("tr")).remove();
			}
			AlertHelper.msg(r.ErrorMsg);
		});
	});
}


//判断字符是否为空的方法
function IsNullOrEmpty(obj) {
	if (typeof obj == "undefined" || obj == null || obj == "") {
		return true;
	} else {
		return false;
	}
}
//获取指定的URL参数值
function getParam(paramName) {
	paramValue = "", isFound = !1;
	if (this.location.search.indexOf("?") == 0 && this.location.search.indexOf("=") > 1) {
		arrSource = unescape(this.location.search).substring(1, this.location.search.length).split("&"), i = 0;
		while (i < arrSource.length && !isFound) arrSource[i].indexOf("=") > 0 && arrSource[i].split("=")[0].toLowerCase() ==
			paramName.toLowerCase() && (paramValue = arrSource[i].split("=")[1], isFound = !0), i++
	}
	return paramValue == "" && (paramValue = null), paramValue
}
//占位符
String.prototype.Format=function()
{
  if(arguments.length==0) return this;
  for(var s=this, i=0; i<arguments.length; i++)
    s=s.replace(new RegExp("\\{"+i+"\\}","g"), arguments[i]);
  return s;
};